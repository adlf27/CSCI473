using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assign3
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            GetStudents("2188_a3_input01.txt"); // gets StudentPool from file
            GetCourses("2188_a3_input02.txt"); // gets CoursePool from file
            GetMajors("2188_a3_input03.txt"); // gets MajorPool from file
            GetGrades("2188_a3_input04.txt"); // gets Grades from file

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }

        #region file parsers

        public static void GetStudents(string file) // parses file and fills StudentPool
        {
            string line;

            if (File.Exists(file)) // make sure file exists
            {
                using (StreamReader studentInFile = new StreamReader(file))
                {
                    line = studentInFile.ReadLine();
                    string[] data;

                    // read and parse each line of data into StudentPool
                    while (line != null)
                    {
                        data = line.Split(',');
                        Globals.StudentPool.Add(new Student(UInt32.Parse(data[0]), data[2], data[1], data[3], (Student.Year)UInt32.Parse(data[4]), float.Parse(data[5])));
                        line = studentInFile.ReadLine();
                    }
                } // end using
            } // end if
            else
            {
                // let user know the file failed to open and exit
                Console.WriteLine(String.Format("Failed to open: {0}", file));
                Environment.Exit(2);
            }
        }

        public static void GetCourses(string file) // parses file and fills CoursePool
        {
            string line;

            if (File.Exists(file)) // make sure file exists
            {
                using (StreamReader courseInFile = new StreamReader(file))
                {
                    line = courseInFile.ReadLine();
                    string[] data;

                    // read and parse each line of data into CoursePool
                    while (line != null)
                    {
                        data = line.Split(',');
                        Globals.CoursePool.Add(new Course(data[0], uint.Parse(data[1]), data[2], ushort.Parse(data[3]), ushort.Parse(data[4])));
                        line = courseInFile.ReadLine();
                    }
                } // end using
            } // end if
            else
            {
                // let user know the file failed to open and exit
                Console.WriteLine(String.Format("Failed to open: {0}", file));
                Environment.Exit(2);
            }
        }

        public static void GetMajors(string file) // parses file and fills MajorPool
        {
            string line;

            if (File.Exists(file)) // make sure file exists
            {
                using (StreamReader majorInFile = new StreamReader(file))
                {
                    line = majorInFile.ReadLine();

                    // read and parse each line of data into MajorPool
                    while (line != null)
                    {
                        Globals.MajorPool.Add(line);
                        line = majorInFile.ReadLine();
                    }
                } // end using
            } // end if
            else
            {
                // let user know the file failed to open and exit
                Console.WriteLine(String.Format("Failed to open: {0}", file));
                Environment.Exit(2);
            }
        }

        public static void GetGrades(string file) // parses file and adds grades to courses in CoursePool
        {
            string line;

            if (File.Exists(file)) // make sure file exists
            {
                using (StreamReader gradeInFile = new StreamReader(file))
                {
                    line = gradeInFile.ReadLine();
                    string[] data;

                    // read and parse each line of data into a course
                    while (line != null)
                    {
                        data = line.Split(',');

                        int zid = Int32.Parse(data[0]);

                        string dept = data[1],
                               grade = data[3];

                        uint courseNum = UInt32.Parse(data[2]);


                        foreach (Student s in Globals.StudentPool) // find the student
                        {
                            if (s.ZID == zid)
                            {
                                foreach (Course c in Globals.CoursePool) // find the course
                                {
                                    if (c.Dept.Equals(dept) && c.CourseNumber == courseNum)
                                    {
                                        // attempt to enroll the student
                                        int enrollStatus = s.Enroll(c);

                                        // check to see if student is enrolled and give grade
                                        if (enrollStatus == 0 || enrollStatus == 10) c.Grades[zid] = grade;
                                    }
                                }
                            }
                        }

                        line = gradeInFile.ReadLine();
                    }
                } // end using
            } // end if
            else
            {
                // let user know the file failed to open and exit
                Console.WriteLine(String.Format("Failed to open: {0}", file));
                Environment.Exit(2);
            }
        }

        #endregion file parsers

    }

    public static class Globals
    {
        private static SortedSet<Student> studentPool = new SortedSet<Student>();
        private static SortedSet<Course> coursePool = new SortedSet<Course>();
        private static SortedSet<string> majorPool = new SortedSet<string>();

        internal static SortedSet<Student> StudentPool { get => studentPool; set => studentPool = value; }
        internal static SortedSet<Course> CoursePool { get => coursePool; set => coursePool = value; }
        internal static SortedSet<string> MajorPool { get => majorPool; set => majorPool = value; }
    }

    public class Student : IComparable
    {
        public enum Year { Freshman, Sophomore, Junior, Senior, PostBacc }

        #region student attributes

        private readonly uint zID;

        private string firstName,
                       lastName,
                       major;

        private Nullable<Year> academicYear;

        private Nullable<float> gpa;

        private Nullable<ushort> creditHours;

        #endregion student attributes

        #region student constructors

        public Student()
        {
            FirstName = null;
            LastName = null;
            Major = null;
            AcademicYear = null;
            CreditHours = null;
        }

        public Student(uint zID, string firstName, string lastName, string major, Year academicYear, float gpa)
        {
            if (!(zID < 1000000)) this.zID = zID;

            FirstName = firstName;
            LastName = lastName;
            Major = major;
            AcademicYear = academicYear;
            GPA = gpa;
            CreditHours = 0;
        }

        #endregion student constructors

        public int CompareTo(object alpha)
        {
            if (alpha == null)
            {
                return 1;
            }

            Student rightOp = alpha as Student;

            if (rightOp != null)
            {
                if (zID < rightOp.ZID) return -1;
                else if (zID == rightOp.ZID) return 0;
                else return 1;
            }
            else throw new ArgumentException("[Student]:CompareTo argument is not a Student");
        }

        public int Enroll(Course newCourse)
        {
            // check if course is full
            if (newCourse.Count == newCourse.Capacity || newCourse.Count > newCourse.Capacity) return 5;

            // check if student allready enrolled
            else if (newCourse.ZIDs.Contains((int)zID)) return 10;

            // check that student willnot exceed credit limit
            else if (CreditHours + newCourse.CreditHours > 18) return 15;

            // enroll the student and increase course enrollment count
            newCourse.ZIDs.Add((int)zID);
            newCourse.Count++;
            return 0;
        }

        public int Drop(Course newCourse)
        {
            // check if student is enrolled
            if (!newCourse.ZIDs.Contains((int)zID)) return 20;

            // remove student from course and decrease enrollment count
            newCourse.ZIDs.Remove((int)zID);
            newCourse.Count--;
            return 0;
        }

        public override string ToString()
        {
            return string.Format("z{0, -7} -- {1}, {2}", ZID, LastName, FirstName);
        }

        #region student properties

        public uint ZID
        {
            get { return zID; }
            private set { }
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Major { get; set; }

        public Nullable<Year> AcademicYear { get; set; }

        public Nullable<float> GPA
        {
            get { return gpa; }
            set { if (value >= 0 && value <= 4) gpa = value; } // make sure gpa within range
        }

        public Nullable<ushort> CreditHours
        {
            get { return creditHours; }
            set { if (value >= 0 && value <= 18) creditHours = value; } // make sure credit hours within range
        }

        #endregion student properties
    }

    public class Course : IComparable
    {
        #region course attributes

        private string dept,
                       sectionNumber;

        private Nullable<uint> courseNumber;

        private Nullable<ushort> creditHours,
                                 count,
                                 capacity;

        private SortedSet<int> zIDs;

        private Dictionary<int, string> grades;

        #endregion course attributes

        #region course constructors

        public Course()
        {
            Dept = null;
            SectionNumber = null;
            CourseNumber = null;
            CreditHours = null;
            Count = null;
            Capacity = null;
            ZIDs = null;
            Grades = null;
        }

        public Course(string dept, uint courseNumber, string sectionNumber, ushort creditHours, ushort capacity)
        {
            Dept = dept;
            CourseNumber = courseNumber;
            SectionNumber = sectionNumber;
            CreditHours = creditHours;
            Count = 0;
            Capacity = capacity;
            ZIDs = new SortedSet<int>();
            Grades = new Dictionary<int, string>();
        }

        #endregion course constructors

        public int CompareTo(object alpha)
        {
            if (alpha == null)
            {
                return 1;
            }

            Course rightOp = alpha as Course;

            if (rightOp != null)
            {
                int result = dept.CompareTo(rightOp.Dept);

                if (result != 0) return result;
                else if (courseNumber > rightOp.CourseNumber) return 1;
                else if (courseNumber < rightOp.CourseNumber) return -1;
                else return 0;
            }
            else throw new ArgumentException("[Course]:CompareTo argument is not a Course");
        }

        public void PrintRoster() // print enrolled students
        {
            // header
            Console.Write(String.Format("Course: {0}\n", ToString()));
            Console.WriteLine("--------------------------------------------------------");

            if (Count > 0) // check to make sure students are enrolled
            {
                // print enrolled students
                foreach (int student in ZIDs)
                {
                    foreach (Student s in Globals.StudentPool)
                    {
                        if (student == s.ZID)
                            Console.Write(String.Format("{0} {1} {2} {3}\n", s.ZID, s.LastName, s.FirstName, s.Major));
                    }

                }
            }
            else // let user know nobody enrolled
            {
                Console.Write(String.Format("There isn't anyone enrolled into {0} {1}-{2}.", Dept, CourseNumber, SectionNumber));
            }
        }

        public override string ToString()
        {
            return String.Format("{0} {1, 3}-{2,4} ({3}/{4})", Dept, CourseNumber, SectionNumber, Count, Capacity);
        }

        #region course properties

        public string Dept
        {
            get { return dept; }
            set
            {
                bool isValid = true;

                if (value != null)
                {
                    if (value.Length <= 4)
                    {
                        foreach (char c in value)
                        {
                            if (!(Char.IsLetter(c) && Char.IsUpper(c))) isValid = false;
                        }

                        if (isValid) dept = value;
                    }
                }
            }
        }

        public string SectionNumber
        {
            get { return sectionNumber; }
            set
            {
                bool isValid = true;

                if (value != null)
                {
                    if (value.Length == 4)
                    {
                        foreach (char c in value)
                        {
                            if (!Char.IsLetterOrDigit(c)) isValid = false;
                        }

                        if (isValid) sectionNumber = value;
                    }
                }
            }
        }

        public Nullable<uint> CourseNumber
        {
            get { return courseNumber; }
            set
            {
                if (value >= 100 && value <= 499) courseNumber = value; // make sure course number within range
            }
        }

        public Nullable<ushort> CreditHours
        {
            get { return creditHours; }
            set
            {
                if (value >= 0 && value <= 6) creditHours = value; // make sure credit hours within range
            }
        }

        public Nullable<ushort> Count { get; set; }

        public Nullable<ushort> Capacity { get; set; }

        public SortedSet<int> ZIDs { get; set; }

        public Dictionary<int, string> Grades { get; set; }

        #endregion course properties
    }

    public class RTBStreamWriter : TextWriter
    {
        RichTextBox _output = null; // object to which output will be streamed

        public RTBStreamWriter(RichTextBox output)
        {
            _output = output;
        }

        public override void Write(char value)
        {
            base.Write(value);
            _output.AppendText(value.ToString()); // When character data is written, append it to the text box.
        }

        public override Encoding Encoding
        {
            get { return System.Text.Encoding.UTF8; }
        }
    }

    public class GradeComparer : StringComparer
    {
        private Dictionary<string, int> grades = new Dictionary<string, int>()
        {
            { "A", 9 },
            { "A-", 8 },
            { "B+", 7 },
            { "B", 6 },
            { "B-", 5 },
            { "C++", 4 },
            { "C", 3 },
            { "C-", 2 },
            { "D", 1 },
            { "F", 0 }
        };

        public override int Compare(string x, string y)
        {
            if (grades[x] > grades[y]) return 1;
            else if (grades[x] == grades[y]) return 0;
            else if (grades[x] < grades[y]) return -1;
            else throw new InvalidDataException();
        }

        public override bool Equals(string x, string y)
        {
            if (this.Compare(x, y) == 0) return true;
            else return false;
        }

        public override int GetHashCode(string obj)
        {
            return obj.GetHashCode() * 761;
        }
    }
}