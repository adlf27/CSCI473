namespace TeamProject
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.enrollBtn = new System.Windows.Forms.Button();
            this.dropBtn = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.addStudentBtn = new System.Windows.Forms.Button();
            this.addCourseBtn = new System.Windows.Forms.Button();
            this.majorCB = new System.Windows.Forms.ComboBox();
            this.zidTB = new System.Windows.Forms.TextBox();
            this.capacityUpDown = new System.Windows.Forms.NumericUpDown();
            this.yearCB = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.searchZidTxt = new System.Windows.Forms.TextBox();
            this.nameTB = new System.Windows.Forms.TextBox();
            this.searchCourseTxt = new System.Windows.Forms.TextBox();
            this.secNumTB = new System.Windows.Forms.TextBox();
            this.courseNumTB = new System.Windows.Forms.TextBox();
            this.outRTB = new System.Windows.Forms.RichTextBox();
            this.studentLB = new System.Windows.Forms.ListBox();
            this.courseLB = new System.Windows.Forms.ListBox();
            this.deptTB = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.capacityUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button1.ForeColor = System.Drawing.SystemColors.Window;
            this.button1.Location = new System.Drawing.Point(12, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(134, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Print Course Roster";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.PrintRosterOperation);
            // 
            // enrollBtn
            // 
            this.enrollBtn.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.enrollBtn.ForeColor = System.Drawing.SystemColors.Window;
            this.enrollBtn.Location = new System.Drawing.Point(12, 41);
            this.enrollBtn.Name = "enrollBtn";
            this.enrollBtn.Size = new System.Drawing.Size(134, 23);
            this.enrollBtn.TabIndex = 1;
            this.enrollBtn.Text = "Enroll Student";
            this.enrollBtn.UseVisualStyleBackColor = false;
            this.enrollBtn.Click += new System.EventHandler(this.EnrollmentOperation);
            // 
            // dropBtn
            // 
            this.dropBtn.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dropBtn.ForeColor = System.Drawing.SystemColors.Window;
            this.dropBtn.Location = new System.Drawing.Point(12, 70);
            this.dropBtn.Name = "dropBtn";
            this.dropBtn.Size = new System.Drawing.Size(134, 23);
            this.dropBtn.TabIndex = 2;
            this.dropBtn.Text = "Drop Student";
            this.dropBtn.UseVisualStyleBackColor = false;
            this.dropBtn.Click += new System.EventHandler(this.EnrollmentOperation);
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button4.ForeColor = System.Drawing.SystemColors.Window;
            this.button4.Location = new System.Drawing.Point(12, 99);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(134, 23);
            this.button4.TabIndex = 3;
            this.button4.Text = "Apply Search Criteria";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.SearchOperation);
            // 
            // addStudentBtn
            // 
            this.addStudentBtn.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.addStudentBtn.ForeColor = System.Drawing.SystemColors.Window;
            this.addStudentBtn.Location = new System.Drawing.Point(12, 254);
            this.addStudentBtn.Name = "addStudentBtn";
            this.addStudentBtn.Size = new System.Drawing.Size(88, 23);
            this.addStudentBtn.TabIndex = 4;
            this.addStudentBtn.Text = "Add Student";
            this.addStudentBtn.UseVisualStyleBackColor = false;
            this.addStudentBtn.Click += new System.EventHandler(this.AddOperation);
            // 
            // addCourseBtn
            // 
            this.addCourseBtn.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.addCourseBtn.ForeColor = System.Drawing.SystemColors.Window;
            this.addCourseBtn.Location = new System.Drawing.Point(12, 392);
            this.addCourseBtn.Name = "addCourseBtn";
            this.addCourseBtn.Size = new System.Drawing.Size(88, 23);
            this.addCourseBtn.TabIndex = 5;
            this.addCourseBtn.Text = "Add Course";
            this.addCourseBtn.UseVisualStyleBackColor = false;
            this.addCourseBtn.Click += new System.EventHandler(this.AddOperation);
            // 
            // majorCB
            // 
            this.majorCB.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.majorCB.ForeColor = System.Drawing.SystemColors.Window;
            this.majorCB.FormattingEnabled = true;
            this.majorCB.Location = new System.Drawing.Point(8, 227);
            this.majorCB.Name = "majorCB";
            this.majorCB.Size = new System.Drawing.Size(138, 21);
            this.majorCB.TabIndex = 8;
            // 
            // zidTB
            // 
            this.zidTB.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.zidTB.ForeColor = System.Drawing.SystemColors.Window;
            this.zidTB.Location = new System.Drawing.Point(150, 188);
            this.zidTB.Name = "zidTB";
            this.zidTB.Size = new System.Drawing.Size(138, 20);
            this.zidTB.TabIndex = 11;
            // 
            // capacityUpDown
            // 
            this.capacityUpDown.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.capacityUpDown.ForeColor = System.Drawing.SystemColors.Window;
            this.capacityUpDown.Location = new System.Drawing.Point(150, 366);
            this.capacityUpDown.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.capacityUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.capacityUpDown.Name = "capacityUpDown";
            this.capacityUpDown.Size = new System.Drawing.Size(138, 20);
            this.capacityUpDown.TabIndex = 0;
            this.capacityUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // yearCB
            // 
            this.yearCB.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.yearCB.ForeColor = System.Drawing.SystemColors.Window;
            this.yearCB.Location = new System.Drawing.Point(150, 227);
            this.yearCB.Name = "yearCB";
            this.yearCB.Size = new System.Drawing.Size(138, 21);
            this.yearCB.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.Window;
            this.label1.Location = new System.Drawing.Point(150, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Search Student (by Z-ID)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.Window;
            this.label2.Location = new System.Drawing.Point(150, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "Filter Course (by Dept)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.SystemColors.Window;
            this.label3.Location = new System.Drawing.Point(12, 172);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(111, 13);
            this.label3.TabIndex = 16;
            this.label3.Text = "Last Name,First Name";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.SystemColors.Window;
            this.label4.Location = new System.Drawing.Point(150, 172);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(28, 13);
            this.label4.TabIndex = 17;
            this.label4.Text = "Z-ID";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.SystemColors.Window;
            this.label5.Location = new System.Drawing.Point(12, 211);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(33, 13);
            this.label5.TabIndex = 18;
            this.label5.Text = "Major";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.SystemColors.Window;
            this.label6.Location = new System.Drawing.Point(150, 211);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(79, 13);
            this.label6.TabIndex = 19;
            this.label6.Text = "Academic Year";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.SystemColors.Window;
            this.label7.Location = new System.Drawing.Point(12, 311);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(90, 13);
            this.label7.TabIndex = 20;
            this.label7.Text = "Department Code";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.SystemColors.Window;
            this.label8.Location = new System.Drawing.Point(150, 311);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(80, 13);
            this.label8.TabIndex = 21;
            this.label8.Text = "Course Number";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.SystemColors.Window;
            this.label9.Location = new System.Drawing.Point(12, 350);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(83, 13);
            this.label9.TabIndex = 22;
            this.label9.Text = "Section Number";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.ForeColor = System.Drawing.SystemColors.Window;
            this.label10.Location = new System.Drawing.Point(150, 350);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(48, 13);
            this.label10.TabIndex = 23;
            this.label10.Text = "Capacity";
            // 
            // searchZidTxt
            // 
            this.searchZidTxt.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.searchZidTxt.ForeColor = System.Drawing.SystemColors.Window;
            this.searchZidTxt.Location = new System.Drawing.Point(150, 33);
            this.searchZidTxt.Name = "searchZidTxt";
            this.searchZidTxt.Size = new System.Drawing.Size(138, 20);
            this.searchZidTxt.TabIndex = 24;
            // 
            // nameTB
            // 
            this.nameTB.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.nameTB.ForeColor = System.Drawing.SystemColors.Window;
            this.nameTB.Location = new System.Drawing.Point(8, 188);
            this.nameTB.Name = "nameTB";
            this.nameTB.Size = new System.Drawing.Size(138, 20);
            this.nameTB.TabIndex = 25;
            // 
            // searchCourseTxt
            // 
            this.searchCourseTxt.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.searchCourseTxt.ForeColor = System.Drawing.SystemColors.Window;
            this.searchCourseTxt.Location = new System.Drawing.Point(150, 72);
            this.searchCourseTxt.Name = "searchCourseTxt";
            this.searchCourseTxt.Size = new System.Drawing.Size(138, 20);
            this.searchCourseTxt.TabIndex = 26;
            // 
            // secNumTB
            // 
            this.secNumTB.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.secNumTB.ForeColor = System.Drawing.SystemColors.Window;
            this.secNumTB.Location = new System.Drawing.Point(8, 366);
            this.secNumTB.Name = "secNumTB";
            this.secNumTB.Size = new System.Drawing.Size(138, 20);
            this.secNumTB.TabIndex = 27;
            // 
            // courseNumTB
            // 
            this.courseNumTB.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.courseNumTB.ForeColor = System.Drawing.SystemColors.Window;
            this.courseNumTB.Location = new System.Drawing.Point(150, 327);
            this.courseNumTB.Name = "courseNumTB";
            this.courseNumTB.Size = new System.Drawing.Size(138, 20);
            this.courseNumTB.TabIndex = 28;
            // 
            // outRTB
            // 
            this.outRTB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.outRTB.BackColor = System.Drawing.SystemColors.MenuText;
            this.outRTB.ForeColor = System.Drawing.SystemColors.Window;
            this.outRTB.Location = new System.Drawing.Point(8, 450);
            this.outRTB.Name = "outRTB";
            this.outRTB.ReadOnly = true;
            this.outRTB.Size = new System.Drawing.Size(820, 152);
            this.outRTB.TabIndex = 29;
            this.outRTB.Text = "";
            // 
            // studentLB
            // 
            this.studentLB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.studentLB.BackColor = System.Drawing.SystemColors.MenuText;
            this.studentLB.ForeColor = System.Drawing.SystemColors.Window;
            this.studentLB.FormattingEnabled = true;
            this.studentLB.Location = new System.Drawing.Point(337, 21);
            this.studentLB.Name = "studentLB";
            this.studentLB.Size = new System.Drawing.Size(218, 394);
            this.studentLB.TabIndex = 30;
            this.studentLB.Click += new System.EventHandler(this.SelectedItemOperation);
            // 
            // courseLB
            // 
            this.courseLB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.courseLB.BackColor = System.Drawing.SystemColors.MenuText;
            this.courseLB.ForeColor = System.Drawing.SystemColors.Window;
            this.courseLB.FormattingEnabled = true;
            this.courseLB.Location = new System.Drawing.Point(608, 21);
            this.courseLB.Name = "courseLB";
            this.courseLB.Size = new System.Drawing.Size(218, 394);
            this.courseLB.TabIndex = 31;
            this.courseLB.Click += new System.EventHandler(this.SelectedItemOperation);
            // 
            // deptTB
            // 
            this.deptTB.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.deptTB.ForeColor = System.Drawing.SystemColors.Window;
            this.deptTB.Location = new System.Drawing.Point(8, 327);
            this.deptTB.Name = "deptTB";
            this.deptTB.Size = new System.Drawing.Size(138, 20);
            this.deptTB.TabIndex = 32;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.ClientSize = new System.Drawing.Size(838, 614);
            this.Controls.Add(this.deptTB);
            this.Controls.Add(this.courseLB);
            this.Controls.Add(this.studentLB);
            this.Controls.Add(this.outRTB);
            this.Controls.Add(this.courseNumTB);
            this.Controls.Add(this.secNumTB);
            this.Controls.Add(this.searchCourseTxt);
            this.Controls.Add(this.nameTB);
            this.Controls.Add(this.searchZidTxt);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.yearCB);
            this.Controls.Add(this.capacityUpDown);
            this.Controls.Add(this.zidTB);
            this.Controls.Add(this.majorCB);
            this.Controls.Add(this.addCourseBtn);
            this.Controls.Add(this.addStudentBtn);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.dropBtn);
            this.Controls.Add(this.enrollBtn);
            this.Controls.Add(this.button1);
            this.ForeColor = System.Drawing.SystemColors.Window;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "NIU Enrollment Management System";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.capacityUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button enrollBtn;
        private System.Windows.Forms.Button dropBtn;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button addStudentBtn;
        private System.Windows.Forms.Button addCourseBtn;
        private System.Windows.Forms.ComboBox majorCB;
        private System.Windows.Forms.ComboBox yearCB;
        private System.Windows.Forms.NumericUpDown capacityUpDown;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox searchZidTxt;
        private System.Windows.Forms.TextBox nameTB;
        private System.Windows.Forms.TextBox zidTB;
        private System.Windows.Forms.TextBox searchCourseTxt;
        private System.Windows.Forms.TextBox secNumTB;
        private System.Windows.Forms.TextBox courseNumTB;
        private System.Windows.Forms.RichTextBox outRTB;
        private System.Windows.Forms.ListBox studentLB;
        private System.Windows.Forms.ListBox courseLB;
        private System.Windows.Forms.TextBox deptTB;
    }
}

