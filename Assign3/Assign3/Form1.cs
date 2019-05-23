using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;


namespace Assign3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // set up rich textbox stream writer (forces console.write stream to rich textbox)
            RTBStreamWriter _writer = new RTBStreamWriter(queryResultRTBox);
            Console.SetOut(_writer);

            // populate major combobox
            foreach (string m in Globals.MajorPool)
            {
                majorCBox.Items.Add(m);
            }

            string[] grades = new string[] { "A", "A-", "B+", "B", "B-", "C++", "C", "C-", "D", "F" };

            // populate the grade comboboxes
            gradeCBox1.Items.AddRange(grades);
            gradeCBox2.Items.AddRange(grades);
        }

        //gets all the grades from an zid type in the textbox
        private void ShowStudentGrades(object sender, EventArgs e)
        {
            queryResultRTBox.Clear();

            bool validZID = false;

            // store Z-ID and separate from 'z'
            int zID = 0;
            string id = zidTBox.Text;

            zidTBox.Clear();

            string[] data1 = id.ToLower().Split('z');

            // check if there was a z in front
            if (data1.Length == 2)
            {
                id = data1[1];
            }

            // check validity of Z-ID
            if (validZID = id.Length == 7)
            {
                validZID = Int32.TryParse(id, out zID);
            }
            else queryResultRTBox.AppendText("The Z-ID must be 7 digits long (excluding the 'z' if typed).\n");

            if (validZID)
            {
                queryResultRTBox.AppendText(String.Format("Single Student Grade Report ({0})\n", zID));
                queryResultRTBox.AppendText("-----------------------------------\n");
                //query that gets all the grades from the zid from the input box
                var gradeQuery =
                    from course in Globals.CoursePool
                    from grade in course.Grades
                    where grade.Key == zID
                    select new { ID = zID, course.Dept, course.CourseNumber, Grade = grade.Value };
                //print only if the query has more than one
                if (gradeQuery.Count() > 0)
                {
                    //foreach loop to go thru the query
                    foreach (var courseGrade in gradeQuery)
                    {
                        queryResultRTBox.AppendText(String.Format("z{0, 7} | {1, 4}-{2, 3} | {3, -3}\n", courseGrade.ID, courseGrade.Dept, courseGrade.CourseNumber, courseGrade.Grade));
                    }
                }
                else
                {
                    queryResultRTBox.AppendText("This Z-ID does not exist.\n");
                }

                queryResultRTBox.AppendText("\n### END RESULTS ###");
            }
        }
        //show the grades based on the radio boxes input and textfields
        private void ShowThresholdGrades(object sender, EventArgs e)
        {
            queryResultRTBox.Clear();
            bool greater = false;
            bool less = false;
            bool validDept = false,
                 validCourseNum = false;

            if (courseTBox1.Text.Count() == 0)
            {
                queryResultRTBox.AppendText("Enter Course to Look For.");
                return;
            }
       
            //split the data and set it to the corresponding variable
            string course = courseTBox1.Text;
            string[] token1 = course.ToUpper().Split(' ','-');
            if(token1.Length < 2)
            {
                queryResultRTBox.AppendText("Enter Course in the Format DEPT 100");
                courseTBox1.Clear();
                return;
            }
            string dept = token1[0];
            uint courseNumber = UInt32.Parse(token1[1]);
            if(dept.Length <= 4)
            {
                validDept = true;

            }
            //get the grade from the combo box
            string grade;
            if(gradeCBox1.SelectedIndex > -1)
                grade = gradeCBox1.Text;
            else
            {
                queryResultRTBox.AppendText("Select Grade to search for.");
                return; 
            }
            //validate the course number to between 100 and 500
            if (courseNumber >= 100 && courseNumber < 500)
            {
                validCourseNum = true;
            }
            else
            {
                queryResultRTBox.AppendText("Enter Valid Course Number between 100 and 500.");
                return;
            }
            //get whichever radio button is checked
            if (radioButton2.Checked == true)
                greater = true;
            if (radioButton1.Checked == true)
                less = true;
            //set up string comparer
            StringComparer gradeComparer = new GradeComparer();

            if (validDept && validCourseNum)
            {
                queryResultRTBox.AppendText(String.Format("Grade Threshold Report for({0} {1})", dept, courseNumber));
                queryResultRTBox.AppendText("\n----------------------------------\n");

                if (greater)
                {
                    //query to get get grades greater or equal to grade form drop down
                    var gradeQuery =
                        from c in Globals.CoursePool
                        from g in c.Grades
                        where dept == c.Dept && c.CourseNumber == courseNumber && gradeComparer.Compare(grade, g.Value) >= 0
                        select new
                        { ID = g.Key, c.Dept, c.CourseNumber, Grade = g.Value };

                    if (gradeQuery.Count() > 0)
                    {
                        //print out results
                        foreach (var courseGrade in gradeQuery)
                        {
                            queryResultRTBox.AppendText(String.Format("z{0, 7} | {1, 4}-{2, 3} | {3, -3}\n", courseGrade.ID, courseGrade.Dept, courseGrade.CourseNumber, courseGrade.Grade));
                        }
                    }
                    else if (gradeQuery.Count() == 0)
                        queryResultRTBox.AppendText(String.Format("No results for the Class {0} {1}", dept, courseNumber));
                }
                if (less)
                {
                    //query to print out grades less than the grade in combo box
                    var gradeQuery =
                        from c in Globals.CoursePool
                        from g in c.Grades
                        where c.Dept == dept && c.CourseNumber == courseNumber && gradeComparer.Compare(grade, g.Value) <= 0
                        select new
                        { ID = g.Key, c.Dept, c.CourseNumber, Grade = g.Value };

                    if (gradeQuery.Count() > 0)
                    {
                        //print out results
                        foreach (var courseGrade in gradeQuery)
                        {
                            queryResultRTBox.AppendText(String.Format("z{0, 7} | {1, 4}-{2, 3} | {3, -3}\n", courseGrade.ID, courseGrade.Dept, courseGrade.CourseNumber, courseGrade.Grade));
                        }
                    }
                }
                queryResultRTBox.AppendText("\n### END RESULTS ###");

            }
            courseTBox1.Clear();
            gradeCBox1.ResetText(); 
        }

        private void PrintMajorStudentFailCourse(object sender, EventArgs e)
        {
            queryResultRTBox.Clear();
            bool courseFound = false;
            //if no selection from the combo box
            if(majorCBox.SelectedIndex == -1)
            {
                queryResultRTBox.AppendText("Select Major from DropDown Menu.\n");
                return;
            }
            string major = majorCBox.Text;
            if(majorCBox.SelectedItem == null)
            {
                queryResultRTBox.AppendText("Select a Major from Drop Down Box.");
                return;
            }
            //empty combo box
            if(!string.IsNullOrEmpty(courseTBox2.Text))
            {
                string course = courseTBox2.Text;
                string[] token = course.ToUpper().Split(' ','-');
                if(token.Length < 2)
                {
                    queryResultRTBox.AppendText("Enter Course in Format DEPT 100");
                    return;
                }
                string dept = token[0];
                uint courseNum = UInt32.Parse(token[1]);
                //query to get all the students that failed the class
                var failedCourse =
                    from c in Globals.CoursePool
                    from g in c.Grades
                    where dept == c.Dept && courseNum == c.CourseNumber && g.Value.Equals("F")
                    select new {
                        failed =
                        (from z in Globals.StudentPool
                        where major == z.Major 
                        select z).Count(),

                        ID = g.Key,
                        Grade = g.Value
                    };

                if (failedCourse.Count() > 0)
               {
                    queryResultRTBox.AppendText(string.Format("Fail Report of Majors ({0}) in {1} {2}\n", major, dept, courseNum));
                    queryResultRTBox.AppendText(string.Format("---------------------------------\n"));
                    //print out the results
                    foreach (var fail in failedCourse)
                    {
                        if (fail.failed > 0)
                            courseFound = true;
                        if(courseFound)
                            queryResultRTBox.AppendText(string.Format("z{0} | {1}-{2} | {3}\n", fail.ID, dept, courseNum, fail.Grade));
                      
                    }
                    queryResultRTBox.AppendText("\n### END RESULTS ###");
                    //no course found
                    if (!courseFound)
                    {
                        queryResultRTBox.Clear();
                        queryResultRTBox.AppendText(string.Format("No course {0}-{1} found in Major {2}\n", dept, courseNum, major));
                    }
                }
                else
                    queryResultRTBox.AppendText("No results found!!");
               
            }
            else
            {
                queryResultRTBox.AppendText("Enter a Course to Print out.");
                return;
            }
            
            courseTBox2.Clear();
            majorCBox.ResetText();
        }

        private void ShowCourseGrades(object sender, EventArgs e)
        {
            queryResultRTBox.Clear();

            bool validDept = false,
                 validCourseNum = false;

            string course = courseTBox3.Text,
                   dept = "";

            courseTBox3.Clear();

            uint courseNum = 0;
            //split the data set it to corresponding variable
            string[] tokens = course.ToUpper().Split(' ', '-');
            //if theres is no space between course
            if (tokens.Length == 2)
            {
                dept = tokens[0];

                validDept = dept.ToUpper().Length == 4;
                validCourseNum = UInt32.TryParse(tokens[1], out courseNum);
            }

            if (validDept && validCourseNum)
            {
                queryResultRTBox.AppendText(String.Format("Grade Report for ({0} {1})\n", dept, courseNum));
                queryResultRTBox.AppendText("-----------------------------------\n");
                //query to get the all the grades from certain class
                var gradeQuerry =
                    from c in Globals.CoursePool
                    from g in c.Grades
                    where c.Dept == dept && c.CourseNumber == courseNum
                    select new { ID = g.Key, c.Dept, c.CourseNumber, Grade = g.Value };

                if (gradeQuerry.Count() > 0)
                {
                    //print out results in query
                    foreach (var courseGrade in gradeQuerry)
                    {
                        queryResultRTBox.AppendText(String.Format("z{0, 7} | {1, 4}-{2, 3} | {3, -3}\n", courseGrade.ID, courseGrade.Dept, courseGrade.CourseNumber, courseGrade.Grade));
                    }
                }
                else
                {
                    queryResultRTBox.AppendText("This course does not exist.\n");
                }

                queryResultRTBox.AppendText("\n### END RESULTS ###");
            }
            else
            {
                queryResultRTBox.AppendText("Please enter a course in the format 'DEPT 100'.");
            }
        }

        private void ShowAllFailedCourses(object sender, EventArgs e)
        {
            queryResultRTBox.Clear();
            float totalPercent;
            bool less = false;
            bool great = false;
            bool found = false;
            //check which radio button is clicked
            if (radioButton4.Checked == true)
                less = true;
            if (radioButton3.Checked == true)
                great = true;
            //get the percent form numeric up and down option
            int percent = Convert.ToInt32(percentageUpDown.Value);
            //query to get the grades who equal an F

            var queryGrade =
                  from c in Globals.CoursePool
                  select new
                  {
                      fail =
                      (from g in c.Grades
                       where g.Value.Equals("F")
                       select g).Count(),
                      c.Dept,
                      c.CourseNumber,
                      c.Count
                  };

            if (less)
            {
                queryResultRTBox.AppendText(string.Format("Failed Percentage (<= {0}%) Report for Classes.\n", percent));
                queryResultRTBox.AppendText("---------------------------------------\n");
                
                //prin out the resuls
                foreach (var studentReport in queryGrade)
                {
                    //print if the total percetn is less than the percent from input
                    totalPercent = (float)studentReport.fail / (float)studentReport.Count;
                    if ((totalPercent * 100) <= percent)
                    {
                        queryResultRTBox.AppendText(string.Format("Out of {0} enrolled in {1}-{2}, {3} failed ({4:P})\n", studentReport.Count, studentReport.Dept, studentReport.CourseNumber, studentReport.fail, totalPercent));
                        found = true;
                    }
                        
                }
             
                if(!found)
                    queryResultRTBox.AppendText("No courses matched the serach criteria");
            }
            if (great)
            {
                //print results if the radio button greater is clicked
                queryResultRTBox.AppendText(string.Format("Failed Percentage (>= {0}%) Report for Classes.\n", percent));
                queryResultRTBox.AppendText("---------------------------------------\n");
                //going thru the query to get the results
                foreach (var studentReport in queryGrade)
                {
                    totalPercent = (float)studentReport.fail / (float)studentReport.Count;
                    if ((totalPercent * 100) >= percent)
                    {
                        queryResultRTBox.AppendText(string.Format("Out of {0} enrolled in {1}-{2}, {3} failed ({4:P})\n", studentReport.Count, studentReport.Dept, studentReport.CourseNumber, studentReport.fail, totalPercent));
                        found = true;
                    }
                }
                if (!found)
                    queryResultRTBox.AppendText("No courses matched the search criteria");
            }
            queryResultRTBox.AppendText("\n### END RESULTS ###");
            percentageUpDown.Value = 0;

        }

        private void ShowPassReport(object sender, EventArgs e)
        {
            queryResultRTBox.Clear();

            string grade = gradeCBox2.Text,
                   operation = ">=";
            gradeCBox2.ResetText();
            bool lessOrEqual = radioButton6.Checked;
            //check which option was clicked
            if (lessOrEqual)
            {
                operation = "<=";
            }

            if (grade.Count() > 0)
            {
                // set up grade comparer
                StringComparer gradeComparer = new GradeComparer();

                queryResultRTBox.AppendText(String.Format("Pass Percentage ({0} {1}%) Report for Classes.\n", operation, grade));
                queryResultRTBox.AppendText("-----------------------------------\n");

                if (lessOrEqual)
                {
                    //query to get the grades less than the grade from combo box
                    var queryGrade =
                        from c in Globals.CoursePool
                        select new
                        {
                            Passed =
                            (from g in c.Grades
                             where gradeComparer.Compare(g.Value, grade) <= 0 &&
                             gradeComparer.Compare(g.Value, "F") > 0
                             select g).Count(),
                             c.Count,
                             c.Dept,
                             c.CourseNumber
                        };
                    //goinging in the query to get the results
                    foreach (var passReport in queryGrade)
                    {
                        float passPercent = (float)passReport.Passed / (float)passReport.Count;
                        queryResultRTBox.AppendText(String.Format("Out of {0} enrolled in {1}-{2}, {3} passed at or below this threshold ( {4: 0.00%})\n", passReport.Count, passReport.Dept, passReport.CourseNumber, passReport.Passed, passPercent));
                    }
                }
                else
                {
                    //query to get the grade less than a the grade from combo box
                    var queryGrade =
                        from c in Globals.CoursePool
                        select new
                        {
                            Passed =
                            (from g in c.Grades
                             where gradeComparer.Compare(g.Value, grade) >= 0 &&
                             gradeComparer.Compare(g.Value, "F") > 0
                             select g.Value).Count(),
                            c.Count,
                            c.Dept,
                            c.CourseNumber
                        };

                    //print out results from the query
                    foreach (var passReport in queryGrade)
                    {
                        float passPercent = (float)passReport.Passed / (float)passReport.Count;
                        queryResultRTBox.AppendText(String.Format("Out of {0} enrolled in {1}-{2}, {3} passed at or above this threshold ( {4: 0.00%})\n", passReport.Count, passReport.Dept, passReport.CourseNumber, passReport.Passed, passPercent));
                    }
                }
                
                queryResultRTBox.AppendText("\n### END RESULTS ###");
            }
            else
            {
                queryResultRTBox.AppendText("Please select a grade to compare to.");
            }
        }
    }
}