using System;
using System.Windows.Forms;


namespace assign6
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 Form2 = new Form2();
            Form2.StartPosition = FormStartPosition.Manual;
            Form2.Location = this.Location;
            Form2.Size = this.Size;
            Form2.FormClosed += OtherForm_Closed;
            Form2.LocationChanged += OtherForm_Changed;
            Form2.SizeChanged += OtherForm_Changed;
            Form2.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form3 Form3 = new Form3();
            Form3.StartPosition = FormStartPosition.Manual;
            Form3.Location = this.Location;
            Form3.Size = this.Size;
            Form3.FormClosed += OtherForm_Closed;
            Form3.LocationChanged += OtherForm_Changed;
            Form3.SizeChanged += OtherForm_Changed;
            Form3.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form4 Form4 = new Form4();
            Form4.StartPosition = FormStartPosition.Manual;
            Form4.Location = this.Location;
            Form4.Size = this.Size;
            Form4.FormClosed += OtherForm_Closed;
            Form4.LocationChanged += OtherForm_Changed;
            Form4.SizeChanged += OtherForm_Changed;
            Form4.Show();
            this.Hide();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            Form5 Form5 = new Form5();
            Form5.StartPosition = FormStartPosition.Manual;
            Form5.Location = this.Location;
            Form5.Size = this.Size;
            Form5.FormClosed += OtherForm_Closed;
            Form5.LocationChanged += OtherForm_Changed;
            Form5.SizeChanged += OtherForm_Changed;
            Form5.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void OtherForm_Closed(object sender, FormClosedEventArgs e)
        {
            this.Show();
        }

        private void OtherForm_Changed(object sender, EventArgs e)
        {
            Form form = sender as Form;

            if (form != null)
            {
                this.Location = form.Location;
                this.Size = form.Size;
            }
        }

    }

}
