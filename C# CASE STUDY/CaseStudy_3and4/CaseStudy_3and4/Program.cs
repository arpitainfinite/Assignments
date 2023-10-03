using System;
using System.Collections.Generic;
using System.Linq;
using CaseStudy1;
using CaseStudy2;


namespace StudentManagementSystem
{
    public class AppEngine
    {
        private List<Student> students = new List<Student>();
        private List<Course> courses = new List<Course>();
        private List<Enroll> enrollments = new List<Enroll>();
        public void IntroduceCourse(Course course)
        {
            courses.Add(course);
            Console.WriteLine($"Course '{course.CourseName}' (ID: {course.CourseId}) introduced successfully.");
        }
        public void RegisterStudent(Student student)
        {
            students.Add(student);
            Console.WriteLine($"Student '{student.Name}' (ID: {student.Id}) registered successfully.");
        }
        public Student[] ListStudents()
        {
            return students.ToArray();
        }
        public Course[] ListCourses()
        {
            return courses.ToArray();
        }
        public void EnrollStudent(int studentId, int courseId)
        {
            Student studentToEnroll = students.FirstOrDefault(s => s.Id == studentId);
            Course courseToEnroll = courses.FirstOrDefault(c => c.CourseId == courseId);
            if (studentToEnroll != null && courseToEnroll != null)
            {
                enrollments.Add(new Enroll(studentToEnroll, courseToEnroll, DateTime.Now));
                Console.WriteLine($"Enrollment successful: '{studentToEnroll.Name}' in '{courseToEnroll.CourseName}'");
            }
            else
            {
                Console.WriteLine("Student or course not found.");
            }
        }
        public Enroll[] ListEnrollments()
        {
            return enrollments.ToArray();
        }
    }
    public abstract class UserInterface
    {
        protected AppEngine engine;
        public UserInterface(AppEngine engine)
        {
            this.engine = engine;
        }
        public void ShowMainMenu()
        {
            Console.Clear();
            Console.WriteLine("Welcome to My Student Management System (SMS)");
            Console.WriteLine("1. Student");
            Console.WriteLine("2. Admin");
            Console.WriteLine("3. Exit");
            Console.Write("Select an option: ");
        }
        public void ShowAdminMenu()
        {
            Console.Clear();
            Console.WriteLine("Admin Menu");
            Console.WriteLine("1. Introduce New Course");
            Console.WriteLine("2. Show All Courses");
            Console.WriteLine("3. Exit");
            Console.Write("Select an option: ");
        }
        public void ShowStudentMenu()
        {
            Console.Clear();
            Console.WriteLine("Student Menu");
            Console.WriteLine("1. Register Student");
            Console.WriteLine("2. Enroll Student in Course");
            Console.WriteLine("3. Show All Students");
            Console.WriteLine("4. Exit");
            Console.Write("Select an option: ");
        }
        public abstract void Run();
    }
    public class ConsoleUserInterface : UserInterface
    {
        public ConsoleUserInterface(AppEngine engine) : base(engine)
        {
        }
        public override void Run()
        {
            while (true)
            {
                ShowMainMenu();
                if (int.TryParse(Console.ReadLine(), out int choice))
                {
                    switch (choice)
                    {
                        case 1:
                            RunStudentMenu();
                            break;
                        case 2:
                            RunAdminMenu();
                            break;
                        case 3:
                            Environment.Exit(0);
                            break;
                        default:
                            Console.WriteLine("Invalid choice. Please select a valid option.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                }
            }
        }
        private void RunAdminMenu()
        {
            while (true)
            {
                ShowAdminMenu();
                if (int.TryParse(Console.ReadLine(), out int choice))
                {
                    switch (choice)
                    {
                        case 1:
                            IntroduceNewCourse();
                            break;
                        case 2:
                            ShowAllCourses();
                            break;
                        case 3:
                            return;
                        default:
                            Console.WriteLine("Invalid choice. Please select a valid option.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                }
            }
        }
        private void RunStudentMenu()
        {
            while (true)
            {
                ShowStudentMenu();
                if (int.TryParse(Console.ReadLine(), out int choice))
                {
                    switch (choice)
                    {
                        case 1:
                            RegisterStudent();
                            break;
                        case 2:
                            EnrollStudentInCourse();
                            break;
                        case 3:
                            ShowAllStudents();
                            break;
                        case 4:
                            return;
                        default:
                            Console.WriteLine("Invalid choice. Please select a valid option.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                }
            }
        }
        private void RegisterStudent()
        {
            Console.Clear();
            Console.Write("Enter Student ID: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                Console.Write("Enter Student Name: ");
                string name = Console.ReadLine();
                engine.RegisterStudent(new Student(id, name, DateTime.Now));
                Console.WriteLine("Press Enter to continue...");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid number.");
            }
        }
        private void IntroduceNewCourse()
        {
            Console.Clear();
            Console.Write("Enter Course ID: ");
            if (int.TryParse(Console.ReadLine(), out int courseId))
            {
                Console.Write("Enter Course Name: ");
                string courseName = Console.ReadLine();
                engine.IntroduceCourse(new Course(courseId, courseName));
                Console.WriteLine("Press Enter to continue...");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid number.");
            }
        }
        private void ShowAllCourses()
        {
            Console.Clear();
            Console.WriteLine("All Courses:");
            Course[] courses = engine.ListCourses();
            foreach (var course in courses)
            {
                Console.WriteLine($"Course ID: {course.CourseId}, Name: {course.CourseName}");
            }
            Console.WriteLine("Press Enter to continue...");
            Console.ReadLine();
        }
        private void EnrollStudentInCourse()
        {
            Console.Clear();
            Console.Write("Enter Student ID to enroll: ");
            if (int.TryParse(Console.ReadLine(), out int studentId))
            {
                Console.Write("Enter Course ID to enroll in: ");
                if (int.TryParse(Console.ReadLine(), out int courseId))
                {
                    engine.EnrollStudent(studentId, courseId);
                    Console.WriteLine("Press Enter to continue...");
                    Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid Course ID.");
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid Student ID.");
            }
        }
        private void ShowAllStudents()
        {
            Console.Clear();
            Console.WriteLine("All Students:");
            Student[] students = engine.ListStudents();
            foreach (var student in students)
            {
                Console.WriteLine($"Student ID: {student.Id}, Name: {student.Name}");
                Enroll[] studentEnrollments = engine.ListEnrollments().Where(e => e.Student.Id == student.Id).ToArray();
                if (studentEnrollments.Any())
                {
                    Console.WriteLine("Enrolled Courses:");
                    foreach (var enrollment in studentEnrollments)
                    {
                        Console.WriteLine($"  Course ID: {enrollment.Course.CourseId}, Name: {enrollment.Course.CourseName}, Enrollment Date: {enrollment.EnrollmentDate.ToShortDateString()}");
                    }
                }
                else
                {
                    Console.WriteLine("Student has not enrolled in any courses.");
                }
                Console.WriteLine();
            }
            Console.WriteLine("Press Enter to continue...");
            Console.ReadLine();
        }
    }
    public class App
    {
        public static void Main(string[] args)
        {
            AppEngine engine = new AppEngine();
            UserInterface userInterface = new ConsoleUserInterface(engine);
            userInterface.Run();
        }
    }
}