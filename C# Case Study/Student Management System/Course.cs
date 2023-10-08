using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_Management_System
{
    public class Course
    {
        // Fields
        private int courseId;
        private string courseName;
        // Constructors
        public Course()
        {
            this.courseId = GenerateUniqueId();
            Console.Write("Enter Course Name: ");
            this.courseName = Console.ReadLine();
        }

        public int CourseId
        {
            get { return courseId; }
        }

        public string CourseName
        {
            get { return courseName; }
            set { courseName = value; }
        }

        private int GenerateUniqueId()
        {

            Random random = new Random();
            return random.Next(1000, 9999);
        }
    }
}