using System;

namespace StudentManagementSystem
{
    class App
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("--------------Welcome to Student Management System-------------");
            while (true)
            {               
                Console.WriteLine("\nMenu:");
                Console.WriteLine("1. Student");
                Console.WriteLine("2. Admin");
                Console.WriteLine("3. Exit");
                Console.Write("Enter your choice: ");

                int choice;
                if (int.TryParse(Console.ReadLine(), out choice))
                {
                    switch (choice)
                    {
                        case 1:
                            StudentMenu();
                            break;
                        case 2:
                            AdminMenu();
                            break;
                        case 3:
                            // Exit the program
                            Console.WriteLine("Exiting...");
                            return;
                        default:
                            Console.WriteLine("Invalid choice. Please try again.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                }

                Console.WriteLine(); // Add a new line for readability
            }
        }

        static void StudentMenu()
        {
            Console.WriteLine("Student Menu:");
            Console.WriteLine("1. Register New Student");
            Console.WriteLine("2. View Available Courses");
            Console.WriteLine("3. Enroll in a Course");
            Console.WriteLine("4. Back to Main Menu");
            Console.Write("Enter your choice: ");

            int choice;
            if (int.TryParse(Console.ReadLine(), out choice))
            {
                switch (choice)
                {
                    case 1:
                        Student student = new Student();
                        student.AddStudentDetails();
                       Console.WriteLine("Student details added to the database successfully.");
                            break;
           
                    case 2:
                         Console.WriteLine("All Courses:");
                         var courses = AppEngine.GetAllCourses();
                         foreach (var c in courses)
                           {
                                Console.WriteLine($"ID: {c.CourseId}, Course Name: {c.CourseName}");
                            }
                            Console.ReadLine();
                            break;
                    case 3:
                        // Enroll student in a course
                            Console.WriteLine("Enter Student ID: ");
                            int studentId;
                            if (int.TryParse(Console.ReadLine(), out studentId))
                            {
                                // Implement logic to retrieve student from database by ID
                                Student stud = AppEngine.RetrieveStudentById(studentId);

                                if (stud != null)
                                {
                                    Console.WriteLine("All Courses:");
                                    var courses2 = AppEngine.GetAllCourses();
                                    foreach (var c in courses2)
                                      {
                                Console.WriteLine($"ID: {c.CourseId}, Course Name: {c.CourseName}");
                                     }
                            Console.ReadLine();
                                    Console.WriteLine("Enter Course ID to enroll: ");
                                    int courseId;
                                    if (int.TryParse(Console.ReadLine(), out courseId))
                                    {
                                        // Implement logic to retrieve course from database by ID
                                        Course cour = AppEngine.RetrieveCourseById(courseId);

                                        if (cour != null)
                                        {
                                            // Enroll the student in the course
                                            AppEngine.EnrollStudentInCourse(stud.Id, cour.CourseId);
                                            Console.WriteLine($"Student {stud.Name} enrolled in the course {cour.CourseName}.");
                                        }
                                        else
                                        {
                                            Console.WriteLine("Course not found.");
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("Invalid Course ID.");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Student not found.");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Invalid Student ID.");
                            }
                            break;
                    case 4:
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a number.");
            }
        }

        static void AdminMenu()
        {
            Console.WriteLine("Admin Menu:");
            Console.WriteLine("1. View All Students");
            Console.WriteLine("2. View All Courses");
            Console.WriteLine("3. View All Enrollments");
            Console.WriteLine("4. Back to Main Menu");
            Console.Write("Enter your choice: ");

            int choice;
            if (int.TryParse(Console.ReadLine(), out choice))
            {
                switch (choice)
                {
                    case 1:
                        // Show all students
                            Console.WriteLine("All Students:");
                            var students = AppEngine.GetAllStudents();
                            foreach (var s in students)
                            {
                                Console.WriteLine($"ID: {s.Id}, Name: {s.Name}, Date of Birth: {s.DateOfBirth:yyyy-MM-dd}");
                            }
                            Console.ReadLine();
                            break;
                    case 2:
                            Console.WriteLine("All Courses:");
                            var courses = AppEngine.GetAllCourses();
                            foreach (var c in courses)
                            {
                                Console.WriteLine($"ID: {c.CourseId}, Course Name: {c.CourseName}");
                            }
                            Console.ReadLine();
                            break;
                    case 3:
                        // Show enrollments
                            Console.WriteLine("Enrollments:");
                            var enrollments = AppEngine.GetAllEnrollmentsWithDetails();
                            foreach (var enrollment in enrollments)
                            {
                                Console.WriteLine($"Student ID: {enrollment.StudentId}, Student Name: {enrollment.StudentName}, Course ID: {enrollment.CourseId} ,Course Name :{enrollment.coursename}");
                            }
                            Console.ReadLine();
                            break;
                    case 4:
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a number.");
            }
        }
    }
}
