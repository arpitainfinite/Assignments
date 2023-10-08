using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Management_System
{
   public class Enroll
    {
        private Student student;
        private Course course;
        //private DateTime enrollmentDate; // Use DateTime instead of LocalDate

        // Constructors
        public Enroll(Student student, Course course)
        {
            this.student = student;
            this.course = course;
            //this.enrollmentDate = enrollmentDate;
            
        }
// Getters and Setters (Properties)
        public Student Student
        {
            get { return student; }
            set { student = value; }
        }

        public Course Course
        {
            get { return course; }
            set { course = value; }
        }



        //public DateTime EnrollmentDate
        //{
        //    get { return enrollmentDate; }
        //    set { enrollmentDate = value; }
        //}
    }
}
