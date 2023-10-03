using System;
using System.Collections.Generic;
using System.Linq;
using CaseStudy1;

namespace CaseStudy2
{
    public class Course
    {
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public Course(int courseId, string courseName)
        {
            CourseId = courseId;
            CourseName = courseName;
        }
    }
    public class Enroll
    {
        public Student Student { get; set; }
        public Course Course { get; set; }
        public DateTime EnrollmentDate { get; set; }
        public Enroll(Student student, Course course, DateTime enrollmentDate)
        {
            Student = student;
            Course = course;
            EnrollmentDate = enrollmentDate;
        }
    }
    public class AppEngine
    {
        private List<Student> students = new List<Student>();
        private List<Course> courses = new List<Course>();
        private List<Enroll> enrollments = new List<Enroll>();
        public void Introduce(Course course)
        {
            courses.Add(course);
            Console.WriteLine($"Course '{course.CourseName}' with ID {course.CourseId} introduced.");
        }
        public void Register(Student student)
        {
            students.Add(student);
            Console.WriteLine($"Student '{student.Name}' with ID {student.Id} registered.");
        }
        public Student[] ListOfStudents()
        {
            return students.ToArray();
        }
        public Course[] ListOfCourses()
        {
            return courses.ToArray();
        }
        public void Enroll(int studentId, int courseId)
        {
            Student studentToEnroll = students.FirstOrDefault(s => s.Id == studentId);
            Course courseToEnroll = courses.FirstOrDefault(c => c.CourseId == courseId);
            if (studentToEnroll != null && courseToEnroll != null)
            {
                enrollments.Add(new Enroll(studentToEnroll, courseToEnroll, DateTime.Now));
                Console.WriteLine($"Enrollment of '{studentToEnroll.Name}' in '{courseToEnroll.CourseName}' successful!");
            }
            else
            {
                Console.WriteLine("Student or course not found.");
            }
        }
        public Enroll[] ListOfEnrollments()
        {
            return enrollments.ToArray();
        }
    }
    public class Info
    {
        public void DisplayEnrollments(Enroll[] enrollments)
        {
            Console.WriteLine("\nEnrollment Details:");
            Console.WriteLine("---------------------------------------------------------------------");
            foreach (Enroll enrollment in enrollments)
            {
                Console.WriteLine($"Student ID: {enrollment.Student.Id}");
                Console.WriteLine($"Student Name: {enrollment.Student.Name}");
                Console.WriteLine($"Course ID: {enrollment.Course.CourseId}");
                Console.WriteLine($"Course Name: {enrollment.Course.CourseName}");
                Console.WriteLine($"Enrollment Date: {enrollment.EnrollmentDate.ToShortDateString()}");
                Console.WriteLine("---------------------------------------------------------------------");
            }
        }
    }
    public class App
    {
        public static void Main(string[] args)
        {
            AppEngine engine = new AppEngine();
            Info info = new Info();
            while (true)
            {
                Console.WriteLine("Select an option:");
                Console.WriteLine("1. Introduce Course");
                Console.WriteLine("2. Register Student");
                Console.WriteLine("3. Enroll Student in Course");
                Console.WriteLine("4. Display Enrollments");
                Console.WriteLine("5. Exit");
                int choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        Console.Write("Enter Course ID: ");
                        int courseId = int.Parse(Console.ReadLine());
                        Console.Write("Enter Course Name: ");
                        string courseName = Console.ReadLine();
                        engine.Introduce(new Course(courseId, courseName));
                        break;
                    case 2:
                        Console.Write("Enter Student ID: ");
                        int studentId = int.Parse(Console.ReadLine());
                        Console.Write("Enter Student Name: ");
                        string studentName = Console.ReadLine();
                        engine.Register(new Student(studentId, studentName, DateTime.Now));
                        break;
                    case 3:
                        Console.Write("Enter Student ID to enroll: ");
                        int enrollStudentId = int.Parse(Console.ReadLine());
                        Console.Write("Enter Course ID to enroll in: ");
                        int enrollCourseId = int.Parse(Console.ReadLine());
                        engine.Enroll(enrollStudentId, enrollCourseId);
                        break;
                    case 4:
                        Enroll[] enrollments = engine.ListOfEnrollments();
                        info.DisplayEnrollments(enrollments);
                        break;
                    case 5:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }
    }
}