using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Management_System
{
    public class Info
    {
        public void Display(Student student)
        {
            // Display student details
            Console.WriteLine("Student ID: " + student.Id);
            Console.WriteLine("Name: " + student.Name);
            Console.WriteLine("Date of Birth: " + student.DateOfBirth.ToShortDateString());
        }

        public void Display(Course course)
        {
           
           Console.WriteLine("Course ID: " + course.CourseId);
            Console.WriteLine("Course Name: " + course.CourseName);
        }

        public void Display(Enroll enrollment)
        {
            // Display enrollment details
        //    Console.WriteLine("Enrollment Date: " + enrollment.EnrollmentDate.ToShortDateString());
            Display(enrollment.Student);
            Display(enrollment.Course);
        }
    }
}
