using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
/************************************************************************
 *       Assignment 2 Practice Good Form                                *
 * Name: Luis Aguinaga  Alexander Adams                                 *
 * Date: 09/27/2018                                                     *
 *     the purpose of this program is to recreate assignment 1          *
 *  but to create using forms. it has almost the same functionaly       *
 *  as assignment 1 with some added methods like add new student        *
 *  and adding a new course.                                             *
 *                                                                      *
 *                                                                      *
 *                                                                      *
 * *********************************************************************/
namespace TeamProject
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e) // populates some form controls
        {
            // set up rich textbox stream writer (forces console.write stream to rich textbox)
            RTBStreamWriter _writer = new RTBStreamWriter(outRTB);
            Console.SetOut(_writer);

            // populate student listbox
            foreach (Student s in Globals.StudentPool)
            {
                studentLB.Items.Add(s);
            }

            // populate course listbox
            foreach (Course c in Globals.CoursePool)
            {
                courseLB.Items.Add(c);
            }

            // populate major combobox
            foreach (string m in Globals.MajorPool)
            {
                majorCB.Items.Add(m);
            }

            // populate year combobox
            foreach (Student.Year y in Enum.GetValues(typeof(Student.Year)))
            {
                yearCB.Items.Add(y.ToString());
            }
        }
        
        private void Form1_Paint(object sender, PaintEventArgs e) // change the color of the form
        {
            BackColor = Color.DarkRed;
        }

        private void PrintRosterOperation(object sender, EventArgs e) // prints the roster of the selected course
        {
            outRTB.Clear();
            
            if (courseLB.SelectedItem != null) // provided a course was selected
            {
                string selected = courseLB.SelectedItem.ToString(), // the selected course
                       dept,
                       sectNum;

                courseLB.ClearSelected();

                uint courseNum;

                string[] tokens1 = selected.Split(' ');
                string[] tokens2 = tokens1[1].Split('-');

                // parse the selected course info
                dept = tokens1[0];
                courseNum = UInt32.Parse(tokens2[0]);
                sectNum = tokens2[1];
                
                // find the course in the pool and print its roster
                foreach (Course c in Globals.CoursePool)
                {
                    if (c.Dept.Equals(dept) && c.CourseNumber == courseNum && c.SectionNumber.Equals(sectNum))
                    {
                        c.PrintRoster();
                        return;
                    }
                }
            }
            else
            {
                outRTB.AppendText("Please select a course from the list.");
            }
        }

        private void EnrollmentOperation(object sender, EventArgs e) // enroll/drop the selected student given button clicked
        {
            outRTB.Clear();

            // provided a student and a course were selected
            if (studentLB.SelectedItem != null && courseLB.SelectedItem != null)
            {
                string selectedCourse = courseLB.SelectedItem.ToString(),
                       selectedStudent = studentLB.SelectedItem.ToString();

                courseLB.ClearSelected();
                studentLB.ClearSelected();

                string[] courseSearch = selectedCourse.Split(' ', '-'),
                         studentSearch = selectedStudent.Split(' ', 'z');

                // parse the selected student and course info
                UInt32 zInput = UInt32.Parse(studentSearch[1]);

                string dept = courseSearch[0],
                       sectionNum = courseSearch[2];

                uint courseNum = UInt32.Parse(courseSearch[1]);

                // objects from the pools that match the items selected
                Student studentObj = new Student();
                Course courseObj = new Course();
                
                foreach (Student s in Globals.StudentPool) // get the matching object from the student pool
                {
                    if (s.ZID == zInput) studentObj = s;
                }
                
                foreach (Course c in Globals.CoursePool) // get the matching object from the course pool
                {
                    if (c.CourseNumber == courseNum && c.SectionNumber.Equals(sectionNum) && c.Dept.Equals(dept)) courseObj = c;
                }

                #region enroll
                if (sender.Equals(enrollBtn)) // check if enroll, or otherwise drop, was clicked
                {
                    int result = studentObj.Enroll(courseObj); // attempt enroll and store result
                    
                    switch (result) // display message based on result
                    {
                        case 5:
                            outRTB.AppendText("That course is full.");
                            break;
                        case 10:
                            outRTB.AppendText("This student is already enrolled in this course.");
                            break;
                        case 15:
                            outRTB.AppendText("This student will have to many credit hours.");
                            break;
                        case 0:
                            outRTB.AppendText("Student Successfully Enrolled!!");
                            courseLB.Items.Clear();

                            // update the course listbox if successful
                            foreach (Course c in Globals.CoursePool)
                            {
                                courseLB.Items.Add(c);
                                deptTB.Clear();
                                courseNumTB.Clear();
                                secNumTB.Clear();
                                capacityUpDown.Value = 1;
                            }

                            break;
                    }// end switch
                }// end if
                #endregion enroll

                #region drop
                else
                {
                    int result = studentObj.Drop(courseObj); // attempt drop and store result

                    switch(result) // display message based on result
                    {
                        case 20:
                            outRTB.AppendText("This student is not enrolled in this course.");
                            break;
                        case 0:
                            outRTB.AppendText("Student Successfully Dropped!!");
                            courseLB.Items.Clear();

                            // update the listbox if successful
                            foreach (Course c in Globals.CoursePool)
                            {
                                courseLB.Items.Add(c);
                                deptTB.Clear();
                                courseNumTB.Clear();
                                secNumTB.Clear();
                                capacityUpDown.Value = 1;
                            }

                            break;
                    }
                }
                #endregion drop
            }// end if
            else
            {
                outRTB.AppendText("Please select a student and a course from the list.");
            }
        }

        private void AddOperation(object sender, EventArgs e) // add a student/course given button pressed
        {
            outRTB.Clear();

            #region student
            if (sender.Equals(addStudentBtn))
            {
                bool validName = false,
                     validZID = false,
                     validMajor = false,
                     validYear = false;

                string[] data = nameTB.Text.Split(',');
                string lastName = "",
                       firstName = "";

                if (validName = data.Length == 2)
                {
                     lastName = data[0];
                     firstName = data[1];
                }
                else outRTB.AppendText("Please enter both the first and last name in the format 'LastName,FirstName'.\n");

                uint zID = 0;
                string id = zidTB.Text;
                string[] data1 = id.ToLower().Split('z');

                if (data1.Length == 2)
                {
                    id = data1[1];
                }
                //checking for zid lenght
                if (validZID = id.Length == 7)
                {
                    validZID = UInt32.TryParse(id, out zID);
                }
                //print error msg 
                else outRTB.AppendText("The Z-ID must be 7 digits long (excluding the 'z' if typed).\n");

                string major = "";
                //if no major is selected
                if (validMajor = majorCB.SelectedIndex > -1) major = majorCB.Text;
                else outRTB.AppendText("Please select a major from the drop down list.\n");

                int year = 0;
                //if no year is selected
                if (validYear = yearCB.SelectedIndex > -1) year = yearCB.SelectedIndex;
                else outRTB.AppendText("Please select a year from the drop down list.\n");
                //add student into the sutdent pool
                if (validName && validZID && validMajor && validYear)
                {
                    studentLB.Items.Clear();
                    Globals.StudentPool.Add(new Student(zID, firstName, lastName, major, (Student.Year) year, 0.00f));
                    //getting the sutdent
                    foreach (Student s in Globals.StudentPool)
                    {
                        studentLB.Items.Add(s);
                        nameTB.Clear();
                        zidTB.Clear();
                        majorCB.ResetText();
                        yearCB.ResetText();
                    }
                }
            }
            #endregion student

            #region course
            else
            {
                bool validDeptCode,
                     validCourseNum,
                     validSecNum;

                string deptCode = "",
                       secNum = "";

                uint courseNum = 0;
                //check if the dept code is valid
                Regex alphaNum_l4 = new Regex("^[a-zA-Z0-9]{4}$"); // alphanumeric length 4

                if (validDeptCode = alphaNum_l4.IsMatch(deptTB.Text)) deptCode = deptTB.Text;
                else outRTB.AppendText("The department code must be exactly 4 alphanumeric characters long.\n");
                //check if the section is valid
                Regex digit_l3 = new Regex("^[1-4][0-9]{2}$"); // digit length 3 starting with any number 1 through 4

                if (validCourseNum = digit_l3.IsMatch(courseNumTB.Text)) courseNum = UInt32.Parse(courseNumTB.Text);
                else outRTB.AppendText("The course number must be exactly 3 digits long, and must be anywhere from 100 min to 499 max.\n");

                if (validSecNum = alphaNum_l4.IsMatch(secNumTB.Text)) secNum = secNumTB.Text;
                else outRTB.AppendText("The section number must be exactly 4 alphanumeric charcters long.\n");
                //adding the course to the course pool
                if (validDeptCode && validCourseNum && validSecNum)
                {
                    courseLB.Items.Clear();
                    Globals.CoursePool.Add(new Course(deptCode, courseNum, secNum, 0, (ushort) capacityUpDown.Value));

                    foreach (Course c in Globals.CoursePool)
                    {
                        courseLB.Items.Add(c);
                        deptTB.Clear();
                        courseNumTB.Clear();
                        secNumTB.Clear();
                        capacityUpDown.Value = 1;

                    }
                }
            }
            #endregion course
        }

        private void SelectedItemOperation(object sender, EventArgs e) // do something when list item selected
        {
            outRTB.Clear();

            #region student
            //if a student is pick from the studnent list
            if (sender.Equals(studentLB))
            {
                string student = studentLB.SelectedItem.ToString();
                string[] token = student.Split('z', ' ');

                int zid = int.Parse(token[1]);
                bool courseFound = false;
                //finding the student in the pool
                foreach (Student s in Globals.StudentPool)
                {
                    if (s.ZID == zid)
                    {
                        Console.WriteLine("z{0} -- {1,15}, {2} {3,15} ({4}) |{5}|", s.ZID, s.LastName, s.FirstName, s.AcademicYear, s.Major, s.GPA);
                        Console.WriteLine("------------------------------------------------------------------------------------------------------------------");
                        //gettinf the course the student is enrolled in
                        foreach (Course c in Globals.CoursePool)
                        {
                            if (c.ZIDs.Contains(zid))
                            {
                                Console.WriteLine(c);
                                courseFound = true;
                            }
                        }
                    }
                }
                if (!courseFound)
                    Console.WriteLine("Student is not Enrolled in any Classes at the moment.");
            }
            #endregion student

            #region course
            else
            {
                //getting the course to add to
                string selected = courseLB.SelectedItem.ToString(),
                       dept,
                       sectNum;

                uint courseNum;

                string[] tokens1 = selected.Split(' ');
                string[] tokens2 = tokens1[1].Split('-');

                dept = tokens1[0];
                courseNum = UInt32.Parse(tokens2[0]);
                sectNum = tokens2[1];

                foreach (Course c in Globals.CoursePool)
                {
                    if (c.Dept.Equals(dept) && c.CourseNumber == courseNum && c.SectionNumber.Equals(sectNum))
                    {
                        outRTB.AppendText(c.ToString());
                        outRTB.AppendText(String.Format(" |{0}|", c.CreditHours.ToString()));
                        return;
                    }
                }
            }
            #endregion course
        }

        private void SearchOperation(object sender, EventArgs e) // search when button clicked
        {
            //if both the search boxes ar empty return
            if (searchZidTxt.Text == "" && searchCourseTxt.Text == "")
            {
                Console.WriteLine("Enter value to search By!!!");
                return;
            }
            bool studentFound = false;
            if (searchZidTxt.Text != "")
            {
                string token = searchZidTxt.Text;
                string[] token2;
                string zid = token;
                //cheching for a leading z
                if (token.Contains('z'))
                {
                    token2 = token.Split('z');
                    zid = token2[1];
                }

                studentLB.Items.Clear();
                //searching for all the students based on the search criteria
                foreach (Student s in Globals.StudentPool)
                {
                    if (s.ZID.ToString().StartsWith(zid))
                    {
                        outRTB.Clear();
                        searchZidTxt.Clear();
                        studentFound = true;
                        studentLB.Items.Add(s);
                    }
                }
                //if student is not found based on search criteria print all the students
                if (!studentFound)
                {
                    outRTB.Clear();
                    searchZidTxt.Clear();
                    Console.WriteLine("No Searches Was Found base on search Criteria!!");
                    foreach (Student s in Globals.StudentPool)
                        studentLB.Items.Add(s);
                }

            }
            bool courseFound = false;
            string course = searchCourseTxt.Text;

            //only if the textbox for course is not empty
            if (searchCourseTxt.Text != "")
            {
                courseLB.Items.Clear();
                //search the courses based on the search criteria
                foreach (Course c in Globals.CoursePool)
                {
                    if (c.Dept == (course.ToUpper()))
                    {
                        outRTB.Clear();
                        searchCourseTxt.Clear();
                        courseLB.Items.Add(c);
                        courseFound = true;
                    }
                }
                if (!courseFound) //if no courses were found print error msg
                {
                    outRTB.Clear();
                    searchCourseTxt.Clear();
                    Console.WriteLine("No Searches were Found base on the search Criteria!!");
                    foreach (Course c in Globals.CoursePool)
                        courseLB.Items.Add(c);
                }
            }
        }
    }
}
