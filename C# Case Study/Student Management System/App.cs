using System;
namespace Student_Management_System

{
    abstract class UserInterface

    {

        public abstract void ShowFirstScreen();
        public abstract void ShowStudentScreen();
        public abstract void ShowAdminScreen();
        public abstract void ShowAllStudentsScreen();
        public abstract void ShowStudentRegistrationScreen();
        public abstract void ShowEnrollStudents();
        public abstract void ShowAllCoursesScreen();

    }

    class ConsoleUserInterface : UserInterface
    {
        private AppEngine engine = new AppEngine();
        private Info info = new Info();
        public override void ShowFirstScreen()
        {
            bool exit = false;
            while (!exit)
            {
                Console.Clear(); // Clear the console on each iteration
                Console.WriteLine("Welcome to Student Management System: ");
                Console.WriteLine("=============================================");
                Console.WriteLine("Tell us who you are:\n1. Student\n2. Admin\n3. Exit");
                Console.WriteLine("Enter your choice (1, 2, or 3): ");

                int op = Convert.ToInt32(Console.ReadLine());

                switch (op)
                {
                    case 1:
                        ShowStudentScreen();
                        break;
                    case 2:
                        ShowAdminScreen();
                        break;
                    case 3:
                        exit = true; // Exit the loop and the application
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }
        public override void ShowStudentScreen()
        {
            bool backToMainMenu = false;
            while (!backToMainMenu)
            {
                Console.Clear();
                Console.WriteLine("========Student Screen=========");
                Console.WriteLine("1. Register New Student");
                Console.WriteLine("2. Show All Courses");
                Console.WriteLine("3. Back to Main Menu");
                Console.WriteLine("Enter your choice (1, 2, or 3): ");

                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        ShowStudentRegistrationScreen();
                        break;
                    case 2:
                        ShowAllCoursesScreen();
                        break;
                    case 3:
                        backToMainMenu = true;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }

        public override void ShowAdminScreen()
        {
            bool backToMainMenu = false;

            while (!backToMainMenu)
            {
                Console.Clear();
                Console.WriteLine("========Admin Screen==========");
                Console.WriteLine("1. Show All Students");
                Console.WriteLine("2. Show All Courses");
                Console.WriteLine("3. Show Enrolled Students");
                Console.WriteLine("4. Back to Main Menu");
                Console.WriteLine("Enter your choice (1, 2, 3, or 4): ");

                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        ShowAllStudentsScreen();
                        break;
                    case 2:
                        ShowAllCoursesScreen();
                        break;
                    case 3:
                        ShowEnrollStudents();
                        break;
                    case 4:
                        backToMainMenu = true;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }

        public override void ShowStudentRegistrationScreen()
        {

            Console.WriteLine("Registering a new student:");
            Student student = new Student();
            engine.RegisterStudent(student);

            Console.WriteLine($"Student {student.Name} registered.");
            Console.WriteLine("---------------------------------------------------");

            Console.WriteLine("Registering a new course:");
            Course course = new Course();
            engine.RegisterCourse(course);

            Console.WriteLine($"Course {course.CourseName} registered.");
            Console.WriteLine("---------------------------------------------------");

            if (course != null)
            {
                // Enroll the student in the specified course
                engine.Enroll(student, course);
                Console.WriteLine($"{student.Name} enrolled in {course.CourseName}.");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Course not found.");
            }
        }

        public override void ShowAllStudentsScreen()
        {
            Console.WriteLine("List of all students:");
            Student[] allStudents = engine.ListOfStudents();
            foreach (var student in allStudents)
            {
                Console.WriteLine($"ID: {student.Id}, Name: {student.Name}");
            }
            Console.ReadLine();
        }

        public override void ShowAllCoursesScreen()
        {
            Console.WriteLine("List of all courses:");
            Course[] allCourses = engine.ListOfCourses();
            foreach (var course in allCourses)
            {

                Console.WriteLine($"Course Name: {course.CourseName}, Course Code: {course.CourseId}");
            }
            Console.ReadLine();
        }
        public override void ShowEnrollStudents()
        {
            Console.WriteLine("List of Enrollments:");
            Enroll[] enroll = engine.ListOfEnrollments();
            foreach (var Enroll1 in enroll)
            {

                Console.WriteLine($"Student Name: {Enroll1.Student.Name}, Course Name: {Enroll1.Course.CourseName}");
            }
            Console.ReadLine();
        }

    }

        class App
        {
            static void Main()
            {
                new ConsoleUserInterface().ShowFirstScreen();
            }
        }

    }

