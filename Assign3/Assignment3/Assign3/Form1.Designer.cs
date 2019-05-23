namespace Assign3
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.queryResultRTBox = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.showThresholdBtn = new System.Windows.Forms.Button();
            this.threshholdGBox = new System.Windows.Forms.GroupBox();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.courseTBox1 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.gradeCBox1 = new System.Windows.Forms.ComboBox();
            this.majorCBox = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.courseTBox2 = new System.Windows.Forms.TextBox();
            this.showFailByMajorBtn = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.courseTBox3 = new System.Windows.Forms.TextBox();
            this.showCourseGradesBtn = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.failGBox = new System.Windows.Forms.GroupBox();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton4 = new System.Windows.Forms.RadioButton();
            this.showAllFailingBtn = new System.Windows.Forms.Button();
            this.percentageUpDown = new System.Windows.Forms.NumericUpDown();
            this.showAllPassingBtn = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.passGBox = new System.Windows.Forms.GroupBox();
            this.radioButton5 = new System.Windows.Forms.RadioButton();
            this.radioButton6 = new System.Windows.Forms.RadioButton();
            this.gradeCBox2 = new System.Windows.Forms.ComboBox();
            this.showStudentGradesBtn = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.zidTBox = new System.Windows.Forms.TextBox();
            this.threshholdGBox.SuspendLayout();
            this.failGBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.percentageUpDown)).BeginInit();
            this.passGBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // queryResultRTBox
            // 
            this.queryResultRTBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.queryResultRTBox.BackColor = System.Drawing.Color.DimGray;
            this.queryResultRTBox.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.queryResultRTBox.ForeColor = System.Drawing.Color.White;
            this.queryResultRTBox.Location = new System.Drawing.Point(681, 74);
            this.queryResultRTBox.Name = "queryResultRTBox";
            this.queryResultRTBox.ReadOnly = true;
            this.queryResultRTBox.Size = new System.Drawing.Size(550, 875);
            this.queryResultRTBox.TabIndex = 100;
            this.queryResultRTBox.TabStop = false;
            this.queryResultRTBox.Text = "";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(675, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(164, 29);
            this.label1.TabIndex = 2;
            this.label1.Text = "Query Result";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(26, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(361, 29);
            this.label2.TabIndex = 3;
            this.label2.Text = "Grade Report for One Student";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(26, 125);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(396, 29);
            this.label4.TabIndex = 5;
            this.label4.Text = "Grade Threshold for One Course";
            // 
            // showThresholdBtn
            // 
            this.showThresholdBtn.AutoSize = true;
            this.showThresholdBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.showThresholdBtn.BackColor = System.Drawing.Color.Transparent;
            this.showThresholdBtn.Location = new System.Drawing.Point(507, 258);
            this.showThresholdBtn.Name = "showThresholdBtn";
            this.showThresholdBtn.Size = new System.Drawing.Size(109, 30);
            this.showThresholdBtn.TabIndex = 6;
            this.showThresholdBtn.Text = "Show Result";
            this.showThresholdBtn.UseVisualStyleBackColor = false;
            this.showThresholdBtn.Click += new System.EventHandler(this.ShowThresholdGrades);
            // 
            // threshholdGBox
            // 
            this.threshholdGBox.AutoSize = true;
            this.threshholdGBox.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.threshholdGBox.BackColor = System.Drawing.Color.Transparent;
            this.threshholdGBox.Controls.Add(this.radioButton2);
            this.threshholdGBox.Controls.Add(this.radioButton1);
            this.threshholdGBox.Location = new System.Drawing.Point(26, 180);
            this.threshholdGBox.Name = "threshholdGBox";
            this.threshholdGBox.Size = new System.Drawing.Size(242, 114);
            this.threshholdGBox.TabIndex = 2;
            this.threshholdGBox.TabStop = false;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.BackColor = System.Drawing.Color.Transparent;
            this.radioButton2.Checked = true;
            this.radioButton2.ForeColor = System.Drawing.Color.White;
            this.radioButton2.Location = new System.Drawing.Point(22, 65);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(214, 24);
            this.radioButton2.TabIndex = 3;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "Greater Than or Equal To";
            this.radioButton2.UseVisualStyleBackColor = false;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.BackColor = System.Drawing.Color.Transparent;
            this.radioButton1.ForeColor = System.Drawing.Color.White;
            this.radioButton1.Location = new System.Drawing.Point(22, 35);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(193, 24);
            this.radioButton1.TabIndex = 3;
            this.radioButton1.Text = "Less Than or Equal To";
            this.radioButton1.UseVisualStyleBackColor = false;
            // 
            // courseTBox1
            // 
            this.courseTBox1.BackColor = System.Drawing.Color.DimGray;
            this.courseTBox1.ForeColor = System.Drawing.Color.White;
            this.courseTBox1.Location = new System.Drawing.Point(370, 258);
            this.courseTBox1.Name = "courseTBox1";
            this.courseTBox1.Size = new System.Drawing.Size(128, 26);
            this.courseTBox1.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(298, 226);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 20);
            this.label5.TabIndex = 11;
            this.label5.Text = "Grade";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(368, 226);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(60, 20);
            this.label6.TabIndex = 12;
            this.label6.Text = "Course";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(26, 315);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(429, 29);
            this.label7.TabIndex = 13;
            this.label7.Text = "Major Student Who Failed A Course";
            // 
            // gradeCBox1
            // 
            this.gradeCBox1.BackColor = System.Drawing.Color.DimGray;
            this.gradeCBox1.ForeColor = System.Drawing.Color.White;
            this.gradeCBox1.FormattingEnabled = true;
            this.gradeCBox1.Location = new System.Drawing.Point(298, 258);
            this.gradeCBox1.Name = "gradeCBox1";
            this.gradeCBox1.Size = new System.Drawing.Size(66, 28);
            this.gradeCBox1.TabIndex = 4;
            // 
            // majorCBox
            // 
            this.majorCBox.BackColor = System.Drawing.Color.DimGray;
            this.majorCBox.ForeColor = System.Drawing.Color.White;
            this.majorCBox.FormattingEnabled = true;
            this.majorCBox.Location = new System.Drawing.Point(26, 415);
            this.majorCBox.Name = "majorCBox";
            this.majorCBox.Size = new System.Drawing.Size(232, 28);
            this.majorCBox.TabIndex = 7;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(368, 371);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(60, 20);
            this.label8.TabIndex = 17;
            this.label8.Text = "Course";
            // 
            // courseTBox2
            // 
            this.courseTBox2.BackColor = System.Drawing.Color.DimGray;
            this.courseTBox2.ForeColor = System.Drawing.Color.White;
            this.courseTBox2.Location = new System.Drawing.Point(368, 415);
            this.courseTBox2.Name = "courseTBox2";
            this.courseTBox2.Size = new System.Drawing.Size(128, 26);
            this.courseTBox2.TabIndex = 8;
            // 
            // showFailByMajorBtn
            // 
            this.showFailByMajorBtn.AutoSize = true;
            this.showFailByMajorBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.showFailByMajorBtn.BackColor = System.Drawing.Color.Transparent;
            this.showFailByMajorBtn.Location = new System.Drawing.Point(507, 415);
            this.showFailByMajorBtn.Name = "showFailByMajorBtn";
            this.showFailByMajorBtn.Size = new System.Drawing.Size(109, 30);
            this.showFailByMajorBtn.TabIndex = 9;
            this.showFailByMajorBtn.Text = "Show Result";
            this.showFailByMajorBtn.UseVisualStyleBackColor = false;
            this.showFailByMajorBtn.Click += new System.EventHandler(this.PrintMajorStudentFailCourse);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(26, 371);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(48, 20);
            this.label9.TabIndex = 18;
            this.label9.Text = "Major";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(26, 472);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(343, 29);
            this.label10.TabIndex = 19;
            this.label10.Text = "Grade Report for One Coure";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(26, 528);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(60, 20);
            this.label11.TabIndex = 22;
            this.label11.Text = "Course";
            // 
            // courseTBox3
            // 
            this.courseTBox3.BackColor = System.Drawing.Color.DimGray;
            this.courseTBox3.ForeColor = System.Drawing.Color.White;
            this.courseTBox3.Location = new System.Drawing.Point(92, 522);
            this.courseTBox3.Name = "courseTBox3";
            this.courseTBox3.Size = new System.Drawing.Size(170, 26);
            this.courseTBox3.TabIndex = 10;
            // 
            // showCourseGradesBtn
            // 
            this.showCourseGradesBtn.AutoSize = true;
            this.showCourseGradesBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.showCourseGradesBtn.BackColor = System.Drawing.Color.Transparent;
            this.showCourseGradesBtn.Location = new System.Drawing.Point(507, 522);
            this.showCourseGradesBtn.Name = "showCourseGradesBtn";
            this.showCourseGradesBtn.Size = new System.Drawing.Size(109, 30);
            this.showCourseGradesBtn.TabIndex = 11;
            this.showCourseGradesBtn.Text = "Show Result";
            this.showCourseGradesBtn.UseVisualStyleBackColor = false;
            this.showCourseGradesBtn.Click += new System.EventHandler(this.ShowCourseGrades);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.White;
            this.label12.Location = new System.Drawing.Point(26, 572);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(331, 29);
            this.label12.TabIndex = 26;
            this.label12.Text = "Fail Report For All Courses";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.Transparent;
            this.label13.ForeColor = System.Drawing.Color.White;
            this.label13.Location = new System.Drawing.Point(298, 674);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(91, 20);
            this.label13.TabIndex = 25;
            this.label13.Text = "Percentage";
            // 
            // failGBox
            // 
            this.failGBox.AutoSize = true;
            this.failGBox.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.failGBox.BackColor = System.Drawing.Color.Transparent;
            this.failGBox.Controls.Add(this.radioButton3);
            this.failGBox.Controls.Add(this.radioButton4);
            this.failGBox.Location = new System.Drawing.Point(26, 628);
            this.failGBox.Name = "failGBox";
            this.failGBox.Size = new System.Drawing.Size(242, 114);
            this.failGBox.TabIndex = 12;
            this.failGBox.TabStop = false;
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.BackColor = System.Drawing.Color.Transparent;
            this.radioButton3.Checked = true;
            this.radioButton3.ForeColor = System.Drawing.Color.White;
            this.radioButton3.Location = new System.Drawing.Point(22, 65);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(214, 24);
            this.radioButton3.TabIndex = 13;
            this.radioButton3.TabStop = true;
            this.radioButton3.Text = "Greater Than or Equal To";
            this.radioButton3.UseVisualStyleBackColor = false;
            // 
            // radioButton4
            // 
            this.radioButton4.AutoSize = true;
            this.radioButton4.BackColor = System.Drawing.Color.Transparent;
            this.radioButton4.ForeColor = System.Drawing.Color.White;
            this.radioButton4.Location = new System.Drawing.Point(22, 35);
            this.radioButton4.Name = "radioButton4";
            this.radioButton4.Size = new System.Drawing.Size(193, 24);
            this.radioButton4.TabIndex = 13;
            this.radioButton4.Text = "Less Than or Equal To";
            this.radioButton4.UseVisualStyleBackColor = false;
            // 
            // showAllFailingBtn
            // 
            this.showAllFailingBtn.AutoSize = true;
            this.showAllFailingBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.showAllFailingBtn.BackColor = System.Drawing.Color.Transparent;
            this.showAllFailingBtn.Location = new System.Drawing.Point(507, 708);
            this.showAllFailingBtn.Name = "showAllFailingBtn";
            this.showAllFailingBtn.Size = new System.Drawing.Size(109, 30);
            this.showAllFailingBtn.TabIndex = 15;
            this.showAllFailingBtn.Text = "Show Result";
            this.showAllFailingBtn.UseVisualStyleBackColor = false;
            this.showAllFailingBtn.Click += new System.EventHandler(this.ShowAllFailedCourses);
            // 
            // percentageUpDown
            // 
            this.percentageUpDown.AutoSize = true;
            this.percentageUpDown.BackColor = System.Drawing.Color.DimGray;
            this.percentageUpDown.ForeColor = System.Drawing.Color.White;
            this.percentageUpDown.Location = new System.Drawing.Point(298, 708);
            this.percentageUpDown.Name = "percentageUpDown";
            this.percentageUpDown.Size = new System.Drawing.Size(86, 26);
            this.percentageUpDown.TabIndex = 14;
            // 
            // showAllPassingBtn
            // 
            this.showAllPassingBtn.AutoSize = true;
            this.showAllPassingBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.showAllPassingBtn.BackColor = System.Drawing.Color.Transparent;
            this.showAllPassingBtn.Location = new System.Drawing.Point(507, 897);
            this.showAllPassingBtn.Name = "showAllPassingBtn";
            this.showAllPassingBtn.Size = new System.Drawing.Size(109, 30);
            this.showAllPassingBtn.TabIndex = 19;
            this.showAllPassingBtn.Text = "Show Result";
            this.showAllPassingBtn.UseVisualStyleBackColor = false;
            this.showAllPassingBtn.Click += new System.EventHandler(this.ShowPassReport);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.Transparent;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.White;
            this.label14.Location = new System.Drawing.Point(26, 763);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(344, 29);
            this.label14.TabIndex = 31;
            this.label14.Text = "Pass Report For All Courses";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.BackColor = System.Drawing.Color.Transparent;
            this.label15.ForeColor = System.Drawing.Color.White;
            this.label15.Location = new System.Drawing.Point(298, 865);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(54, 20);
            this.label15.TabIndex = 30;
            this.label15.Text = "Grade";
            // 
            // passGBox
            // 
            this.passGBox.AutoSize = true;
            this.passGBox.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.passGBox.BackColor = System.Drawing.Color.Transparent;
            this.passGBox.Controls.Add(this.radioButton5);
            this.passGBox.Controls.Add(this.radioButton6);
            this.passGBox.Location = new System.Drawing.Point(26, 818);
            this.passGBox.Name = "passGBox";
            this.passGBox.Size = new System.Drawing.Size(242, 114);
            this.passGBox.TabIndex = 16;
            this.passGBox.TabStop = false;
            // 
            // radioButton5
            // 
            this.radioButton5.AutoSize = true;
            this.radioButton5.BackColor = System.Drawing.Color.Transparent;
            this.radioButton5.Checked = true;
            this.radioButton5.ForeColor = System.Drawing.Color.White;
            this.radioButton5.Location = new System.Drawing.Point(22, 65);
            this.radioButton5.Name = "radioButton5";
            this.radioButton5.Size = new System.Drawing.Size(214, 24);
            this.radioButton5.TabIndex = 17;
            this.radioButton5.TabStop = true;
            this.radioButton5.Text = "Greater Than or Equal To";
            this.radioButton5.UseVisualStyleBackColor = false;
            // 
            // radioButton6
            // 
            this.radioButton6.AutoSize = true;
            this.radioButton6.BackColor = System.Drawing.Color.Transparent;
            this.radioButton6.ForeColor = System.Drawing.Color.White;
            this.radioButton6.Location = new System.Drawing.Point(22, 35);
            this.radioButton6.Name = "radioButton6";
            this.radioButton6.Size = new System.Drawing.Size(193, 24);
            this.radioButton6.TabIndex = 17;
            this.radioButton6.Text = "Less Than or Equal To";
            this.radioButton6.UseVisualStyleBackColor = false;
            // 
            // gradeCBox2
            // 
            this.gradeCBox2.BackColor = System.Drawing.Color.DimGray;
            this.gradeCBox2.ForeColor = System.Drawing.Color.White;
            this.gradeCBox2.FormattingEnabled = true;
            this.gradeCBox2.Location = new System.Drawing.Point(298, 897);
            this.gradeCBox2.Name = "gradeCBox2";
            this.gradeCBox2.Size = new System.Drawing.Size(66, 28);
            this.gradeCBox2.TabIndex = 18;
            // 
            // showStudentGradesBtn
            // 
            this.showStudentGradesBtn.AutoSize = true;
            this.showStudentGradesBtn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.showStudentGradesBtn.BackColor = System.Drawing.Color.Transparent;
            this.showStudentGradesBtn.Location = new System.Drawing.Point(507, 74);
            this.showStudentGradesBtn.Name = "showStudentGradesBtn";
            this.showStudentGradesBtn.Size = new System.Drawing.Size(109, 30);
            this.showStudentGradesBtn.TabIndex = 1;
            this.showStudentGradesBtn.Text = "Show Result";
            this.showStudentGradesBtn.UseVisualStyleBackColor = false;
            this.showStudentGradesBtn.Click += new System.EventHandler(this.ShowStudentGrades);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(26, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 20);
            this.label3.TabIndex = 35;
            this.label3.Text = "Z-ID";
            // 
            // zidTBox
            // 
            this.zidTBox.BackColor = System.Drawing.Color.DimGray;
            this.zidTBox.ForeColor = System.Drawing.Color.White;
            this.zidTBox.Location = new System.Drawing.Point(74, 74);
            this.zidTBox.Name = "zidTBox";
            this.zidTBox.Size = new System.Drawing.Size(128, 26);
            this.zidTBox.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(58)))), ((int)(((byte)(58)))));
            this.ClientSize = new System.Drawing.Size(1250, 968);
            this.Controls.Add(this.zidTBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.showStudentGradesBtn);
            this.Controls.Add(this.gradeCBox2);
            this.Controls.Add(this.showAllPassingBtn);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.passGBox);
            this.Controls.Add(this.percentageUpDown);
            this.Controls.Add(this.showAllFailingBtn);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.failGBox);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.courseTBox3);
            this.Controls.Add(this.showCourseGradesBtn);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.courseTBox2);
            this.Controls.Add(this.showFailByMajorBtn);
            this.Controls.Add(this.majorCBox);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.courseTBox1);
            this.Controls.Add(this.gradeCBox1);
            this.Controls.Add(this.threshholdGBox);
            this.Controls.Add(this.showThresholdBtn);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.queryResultRTBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(1262, 998);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "NIU Academic Performance Query System";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.threshholdGBox.ResumeLayout(false);
            this.threshholdGBox.PerformLayout();
            this.failGBox.ResumeLayout(false);
            this.failGBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.percentageUpDown)).EndInit();
            this.passGBox.ResumeLayout(false);
            this.passGBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.RichTextBox queryResultRTBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button showThresholdBtn;
        private System.Windows.Forms.GroupBox threshholdGBox;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.TextBox courseTBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox gradeCBox1;
        private System.Windows.Forms.ComboBox majorCBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox courseTBox2;
        private System.Windows.Forms.Button showFailByMajorBtn;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox courseTBox3;
        private System.Windows.Forms.Button showCourseGradesBtn;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.GroupBox failGBox;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.RadioButton radioButton4;
        private System.Windows.Forms.Button showAllFailingBtn;
        private System.Windows.Forms.NumericUpDown percentageUpDown;
        private System.Windows.Forms.Button showAllPassingBtn;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.GroupBox passGBox;
        private System.Windows.Forms.RadioButton radioButton5;
        private System.Windows.Forms.RadioButton radioButton6;
        private System.Windows.Forms.ComboBox gradeCBox2;
        private System.Windows.Forms.Button showStudentGradesBtn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox zidTBox;
    }
}

