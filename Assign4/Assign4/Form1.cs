using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Imaging;

namespace Assign4
{
    public partial class Form1 : Form
    {
        private Bitmap _canvas;
        private Point _startPoint;
        private Point _endpoint;
        private List<Point> _mousePoints;
        private Brush _previewBrush;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            _mousePoints = new List<Point>();
            _previewBrush = new SolidBrush(foregroundColor.BackColor);
            UpdateCanvasSize();
        }

        #region color pickers
        private void PickColor(object sender, MouseEventArgs e)
        {
            if (sender is Label)
            {
                Label newColor = (Label)sender;

                if (e.Button == MouseButtons.Left)
                {
                    foregroundColor.BackColor = newColor.BackColor;
                    _previewBrush = new SolidBrush(newColor.BackColor);
                }
                else if (e.Button == MouseButtons.Right) backgroundColor.BackColor = newColor.BackColor;
            }
        }

        private void PickCustomColor(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() != DialogResult.Cancel)
            {
                if (sender.Equals(foregroundColor))
                {
                    foregroundColor.BackColor = colorDialog1.Color;
                    _previewBrush = new SolidBrush(colorDialog1.Color);
                }
                else if (sender.Equals(backgroundColor)) backgroundColor.BackColor = colorDialog1.Color;
            }
        }
        #endregion color pickers

        #region utilities
        private void UpdateCanvasSize()
        {
            Bitmap tmp = new Bitmap(canvas.Size.Width, canvas.Size.Height, PixelFormat.Format32bppRgb);

            using (Graphics g = Graphics.FromImage(tmp))
            {
                g.Clear(canvas.BackColor);

                if (_canvas != null)
                {
                    g.DrawImage(_canvas, 0, 0);
                    _canvas.Dispose();
                }
            }

            _canvas = tmp;
            _canvas.MakeTransparent(canvas.BackColor);
        }

        private void DrawActions(Bitmap tmp)
        {
            using (Graphics g = Graphics.FromImage(tmp))
            {
                float size = (float)toolSize.Value;
                Brush drawBrush = new SolidBrush(foregroundColor.BackColor);
                Brush eraseBrush = new SolidBrush(canvas.BackColor);

                if (pencilBtn.Checked)
                {
                    g.FillRectangle(drawBrush, _startPoint.X, _startPoint.Y, size, size);

                    if (_mousePoints.Count > 1)
                    {
                        g.DrawLines(new Pen(drawBrush, size), _mousePoints.ToArray());
                    }
                }
                else if (brushBtn.Checked)
                {
                    g.FillEllipse(drawBrush, _startPoint.X, _startPoint.Y, size, size);

                    foreach (Point p in _mousePoints)
                    {
                        g.FillEllipse(drawBrush, p.X, p.Y, size, size);
                    }
                }
                else if (eraserBtn.Checked)
                {
                    g.FillRectangle(eraseBrush, _startPoint.X, _startPoint.Y, size, size);

                    foreach (Point p in _mousePoints)
                    {
                        g.FillRectangle(eraseBrush, p.X, p.Y, size, size);
                    }
                }
                else if (lineBtn.Checked)
                {
                    g.DrawLine(new Pen(_previewBrush, size), _startPoint, _endpoint);
                }

                tmp.MakeTransparent(canvas.BackColor);
            }
        }

        #endregion utilities

        #region canvas
        #region mouse
        private void Canvas_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                _startPoint = e.Location;
                _mousePoints = new List<Point>();
                _mousePoints.Add(_startPoint);
            }
        }

        private void Canvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                _endpoint = e.Location;
                _mousePoints.Add(e.Location);
                canvas.Invalidate();
            }
        }

        private void Canvas_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (_mousePoints != null)
                {
                    DrawActions(_canvas);

                    _mousePoints = null;
                    canvas.Invalidate();
                }
            }
        }
        #endregion mouse

        private void Canvas_Paint(object sender, PaintEventArgs e)
        {
            if (_mousePoints != null)
            {
                using (Bitmap tmp = new Bitmap(_canvas))
                {
                    DrawActions(tmp);
                    e.Graphics.DrawImage(tmp, 0, 0);
                }
            }
            else
            {
                e.Graphics.DrawImage(_canvas, 0, 0);
            }
        }

        private void Canvas_Resize(object sender, EventArgs e)
        {
            UpdateCanvasSize();
        }

        private void ChangeBackgroundColor(object sender, EventArgs e)
        {
            canvas.BackColor = backgroundColor.BackColor;
        }
        #endregion canvas

        private void SelectedTool(object sender, EventArgs e)
        {
            if (pencilBtn.Checked || lineBtn.Checked)
            {
                toolSize.Maximum = 3;
                toolSize.Minimum = 1;
            }
            else if (brushBtn.Checked)
            {
                toolSize.Maximum = 8;
                toolSize.Minimum = 5;
            }
            else if (eraserBtn.Checked)
            {
                toolSize.Maximum = 8;
                toolSize.Minimum = 1;
            }

            toolSize.Value = toolSize.Minimum;
        }
    }
}
