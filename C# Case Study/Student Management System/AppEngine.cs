using System;
using System.Collections.Generic;

namespace Student_Management_System
{
    public class AppEngine
    {
        private List<Student> students = new List<Student>();
        private List<Course> courses = new List<Course>();
        private List<Enroll> enrollments = new List<Enroll>();
        private Sql_Connection Sql=new Sql_Connection
        

        public void RegisterCourse(Course course)
        {
            courses.Add(course);
        }

        public void RegisterStudent(Student student)
        {
            students.Add(student);
            Sql.AddStudentDetails(student);
        }

        public Student[] ListOfStudents()
        {
            return students.ToArray();
        }

        public Course[] ListOfCourses()
        {
            return courses.ToArray();
        }

        public void Enroll(Student student, Course course)
        {
            DateTime enrollmentDate = DateTime.Now; // You can set the enrollment date as needed
            Enroll enrollment = new Enroll(student, course);
            enrollments.Add(enrollment);
        }

        public Enroll[] ListOfEnrollments()
        {
            return enrollments.ToArray();
        }
    }
}