using System;

namespace StudentManagementSystem
{
    public class Enrollment
    {
        public int StudentId{ get; set; }
        public string StudentName { get; set; }
        public int CourseId { get; set; }
        public string coursename { get; set; }

        public Enrollment(int StudentId, string StudentName,int CourseId ,string coursename)
        {
            this.StudentId = StudentId;
            this.StudentName = StudentName;
            this.CourseId = CourseId;
            this.coursename = coursename;



        }

    }
    
}
