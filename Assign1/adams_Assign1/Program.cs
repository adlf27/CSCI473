using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assign1
{
    public static class Globals
    {
        private static SortedSet<Student> studentPool = new SortedSet<Student>();
        private static SortedSet<Course> coursePool = new SortedSet<Course>();

        internal static SortedSet<Student> StudentPool { get => studentPool; set => studentPool = value; }
        internal static SortedSet<Course> CoursePool { get => coursePool; set => coursePool = value; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            GetStudents("2188_a1_input01.txt");
            GetCourses("2188_a1_input02.txt");

            Console.WriteLine(String.Format("We have {0} students and {1} courses.\n", Globals.StudentPool.Count(), Globals.CoursePool.Count()));

            bool finished = false;

            do
            {
                PrintMenu();

                string input = Console.ReadLine();

                switch (input.ToLower())
                {
                    case "1":
                        PrintStudentList();
                        break;
                    case "2":
                        Console.Write("Which major list would you like printed? ");
                        input = Console.ReadLine();
                        PrintStudentList(input);
                        break;
                    case "3":
                        Console.WriteLine("Which Academic Year would you like printed?");
                        Console.Write("<Freshman, Sophmore, Junior, Senoir, PostBacc> ");
                        input = Console.ReadLine();
                        PrintStudentYear(input);
                        break;
                    case "4":
                        PrintCourseList();
                        break;
                    case "5":
                        PrintCourseRoster();
                        break;
                    case "6":
                        Console.Write("Enter the ZID of the Student you like to Enroll(Without the Z):  ");
                        uint zInput = UInt32.Parse(Console.ReadLine());
                        Console.WriteLine("Which course will this Student be enrolled into? ");
                        Console.Write("<DEPT-COURSENUM-SECTIONNUM>: ");
                        input = Console.ReadLine();
                        EnrollStudent(zInput, input);
                        break;
                    case "7":
                        Console.Write("Enter the ZID of the Student you like to Drop(Without the Z):  ");
                        zInput = UInt32.Parse(Console.ReadLine());
                        Console.WriteLine("Which course will this Student be Drop From? ");
                        Console.Write("<DEPT-COURSENUM-SECTIONNUM>: ");
                        input = Console.ReadLine();
                        DropStudent(zInput, input);
                        break;
                    case "8":
                        finished = true;
                        break;
                    case "h":
                        finished = true;
                        break;
                    case "q":
                        finished = true;
                        break;
                    case "quit":
                        finished = true;
                        break;
                    case "exit":
                        finished = true;
                        break;
                    default:
                        Console.WriteLine(String.Format("'{0}', isn't an acceptable response.", input));
                        break;
                }
            } while (!finished);
        }

        #region main print methods

        public static void PrintMenu()
        {
            Console.WriteLine("Please choose from the following options:\n");

            string[] options = new string[8]
            {
                "Print Student List (All)",
                "Print Student List (Major)",
                "Print Student List (Academic Year)",
                "Print Course List",
                "Print Course Roster",
                "Enroll Student",
                "Drop Student",
                "Quit\n"
            };

            for (int i = 0; i < options.Length; i++)
            {
                Console.WriteLine(String.Format("{0}. {1}", i + 1, options[i]));
            }
        }

        public static void PrintStudentList()
        {
            Console.WriteLine("\nStudent List (All Students):");
            Console.WriteLine("---------------------------------------------------");

            foreach (Student s in Globals.StudentPool)
            {
                Console.WriteLine(s.ToString());
            }

            Console.Write("\n\n");
        }

        public static void PrintStudentList(string major)
        {
            bool majorFound = false;

            Console.WriteLine(String.Format("\nStudent List ({0} Majors)", major));
            Console.WriteLine("---------------------------------------------------");

            foreach (Student s in Globals.StudentPool)
            {
                if (s.Major.Equals(major))
                {
                    Console.WriteLine(s.ToString());
                    majorFound = true;
                }
            }

            if (!majorFound)
            {
                Console.WriteLine(String.Format("There doesn't appear to be any students majoring in '{0}'", major));
            }

            Console.Write("\n\n");
        }

        public static void PrintStudentYear(string year)
        {
            int gradeLevel = -1;
            bool yearFound = false;
            if (year == "Freshman")
                gradeLevel = 0;
            else if (year == "Sophmore")
                gradeLevel = 1;
            else if (year == "Junior")
                gradeLevel = 2;
            else if (year == "Senior")
                gradeLevel = 3;
            else if (year == "PostBacc")
                gradeLevel = 4;

            Console.WriteLine(String.Format("\nStudent List ({0} Majors)", year));
            Console.WriteLine("---------------------------------------------------");

            foreach (Student s in Globals.StudentPool)
            {
                if ((int)s.AcademicYear == gradeLevel)
                {
                    Console.WriteLine(s.ToString());
                    yearFound = true;
                }
            }

            if (!yearFound)
            {
                Console.WriteLine(String.Format("There doesn't appear to be any students in the Year '{0}'", year));
            }

            Console.Write("\n\n");
        }

        public static void PrintCourseList()
        {
            Console.WriteLine("\nCourse List <All Courses>");
            Console.WriteLine("---------------------------------------------------");

            foreach (Course c in Globals.CoursePool)
            {
                Console.WriteLine(c.ToString());
            }

            Console.Write("\n\n");
        }

        public static void PrintCourseRoster()
        {
            Console.WriteLine("Which course roster would you like printed?");
            Console.Write("<DEPT COURSE_NUM-SECTION_NUM> ");

            string input = Console.ReadLine();

            if (input.Contains(" ") && input.Contains("-"))
            {
                string dept,
                   sectNum;

                uint courseNum;

                string[] tokens1 = input.Split(' ');
                string[] tokens2 = tokens1[1].Split('-');

                dept = tokens1[0];
                courseNum = UInt32.Parse(tokens2[0]);
                sectNum = tokens2[1];

                foreach (Course c in Globals.CoursePool)
                {
                    if (c.Dept.Equals(dept) && c.CourseNumber == courseNum && c.SectionNumber.Equals(sectNum))
                    {
                        Console.Write("\n");
                        c.PrintRoster();
                        Console.Write("\n\n");
                        return;
                    }
                }

                Console.WriteLine(String.Format("\nThe course '{0}' doesn't appear to exist.\n\n", input));
            }
            else Console.WriteLine(String.Format("\n'{0}', isn't an acceptable response.\n\n", input));
        }

        public static void EnrollStudent(uint zInput, string input)
        {
            bool courseFound = false;
            bool studentFound = false;
            string[] courseSearch = input.Split(' ','-');
            string dept = courseSearch[0];
            string sectionNum = courseSearch[2];
            uint courseNum = UInt32.Parse(courseSearch[1]);
            foreach (Student s in Globals.StudentPool)
            {
                if (s.ZID == zInput)
                {
                    foreach (Course c in Globals.CoursePool)
                    {
                        if (c.CourseNumber == courseNum && c.SectionNumber.Contains(sectionNum) && c.Dept.Contains(dept))
                        {
                            s.Enroll(c);
                            courseFound = true;
                        }
                    }
                }
                studentFound = true;
            }
            if (!studentFound)
                Console.WriteLine("Student Not Found!!");
            else if (!courseFound)
                Console.WriteLine("Course Was Not Found!!");
            else if (studentFound && courseFound)
                Console.WriteLine("\nStudent Successfully Enrolled!!\n\n");
        }

        public static void DropStudent(uint zInput, string input)
        {
            bool courseFound = false;
            bool studentFound = false;
            string[] courseSearch = input.Split(' ','-');
            string dept = courseSearch[0];
            string sectionNum = courseSearch[2];
            uint courseNum = UInt32.Parse(courseSearch[1]);

            foreach (Student s in Globals.StudentPool)
            {
                if (s.ZID == zInput)
                {
                    foreach (Course c in Globals.CoursePool)
                    {
                        if (c.CourseNumber == courseNum && c.SectionNumber.Contains(sectionNum) && c.Dept.Contains(dept))
                        {
                            s.Drop(c);
                            courseFound = true;
                        }
                    }
                }
                studentFound = true;
            }
            if (!studentFound)
                Console.WriteLine("Student Not Found!!");
            else if (!courseFound)
                Console.WriteLine("Course Was Not Found!!");
            else if (studentFound && courseFound)
                Console.WriteLine("\nStudent Successfully Dropped!!\n\n");
        }

        #endregion main print methods

        #region file parsers

        public static void GetStudents(string file)
        {
            string line;

            if (File.Exists(file))
            {
                using (StreamReader studentInFile = new StreamReader(file))
                {
                    line = studentInFile.ReadLine();
                    string[] data;

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
                Console.WriteLine(String.Format("Failed to open: {0}", file));
                Environment.Exit(2);
            }
        }

        public static void GetCourses(string file)
        {
             string line;

            if (File.Exists(file))
            {
                using (StreamReader courseInFile = new StreamReader(file))
                {
                    line = courseInFile.ReadLine();
                    string[] data;

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
                Console.WriteLine(String.Format("Failed to open: {0}", file));
                Environment.Exit(2);
            }
        }

        #endregion file parsers
    }

    class Student : IComparable
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
            if (newCourse.Count == newCourse.Capacity || newCourse.Count > newCourse.Capacity) return 5;
            else if (newCourse.ZIDs.Contains((int) zID)) return 10;
            else if (CreditHours + newCourse.CreditHours > 18) return 15;

            newCourse.ZIDs.Add((int) zID);
            newCourse.Count++;
            return 0;
        }

        public int Drop(Course newCourse)
        {
            if (!newCourse.ZIDs.Contains((int) zID)) return 20;

            newCourse.ZIDs.Remove((int) zID);
            newCourse.Count--;
            return 0;
        }

        public override string ToString()
        {
            return string.Format("z{0, -7} -- {1, 12}, {2, -12} [{3, 9}] ({4, 16}) | {5, 5:0.000} |", ZID, LastName, FirstName, AcademicYear, Major, GPA);
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
            set { if (value >= 0 && value <= 4) gpa = value; }
        }

        public Nullable<ushort> CreditHours
        {
            get { return creditHours; }
            set { if (value >= 0 && value <= 18) creditHours = value; }
        }

        #endregion student properties
    }

    class 
        Course : IComparable
    {
        #region course attributes

        private string dept,
                       sectionNumber;

        private Nullable<uint> courseNumber;

        private Nullable<ushort> creditHours,
                                 count,
                                 capacity;

        private SortedSet<int> zIDs;

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

        public void PrintRoster()
        {
            Console.WriteLine(String.Format("Course: {0}", ToString()));
            Console.WriteLine("--------------------------------------------------------");

            if (Count > 0)
            {
                foreach (int student in ZIDs)
                {
                    foreach (Student s in Globals.StudentPool)
                    {
                        if (student == s.ZID)
                            Console.WriteLine(String.Format("{0} {1} {2} {3}", s.ZID, s.LastName, s.FirstName, s.Major));
                    }
                    
                }
            }
            else
            {
                Console.WriteLine(String.Format("There isn't anyone enrolled into {0} {1}-{2}.", Dept, CourseNumber, SectionNumber));
            }
        }

        public override string ToString()
        {
            return String.Format("{0, 4} {1, 3}-{2,4} ({3}/{4})", Dept, CourseNumber, SectionNumber, Count, Capacity);


        }

        #region course properties

        public string Dept
        {
            get { return dept; }
            set
            {
                bool isValid = true;

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

        public string SectionNumber
        {
            get { return sectionNumber; }
            set
            {
                bool isValid = true;

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

        public Nullable<uint> CourseNumber
        {
            get { return courseNumber; }
            set
            {
                if (value >= 100 && value <= 499) courseNumber = value;
            }
        }

        public Nullable<ushort> CreditHours
        {
            get { return creditHours; }
            set
            {
                if (!(value >= 0 && value <= 6)) creditHours = value;
            }
        }

        public Nullable<ushort> Count { get; set; }

        public Nullable<ushort> Capacity { get; set; }

        public SortedSet<int> ZIDs { get; set; }

        #endregion course properties
    }
}
