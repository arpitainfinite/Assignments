using System;
using System.Data.SqlClient;

namespace StudentManagementSystem
{
    public class Course
    {
        private int courseId;
        private string courseName;

        public Course()
        {
            // Prompt the user to enter course details
            Console.Write("Enter Course ID: ");
            if (!int.TryParse(Console.ReadLine(), out this.courseId))
            {
                Console.WriteLine("Invalid ID. Using default ID (0).");
                this.courseId = 0;
            }

            Console.Write("Enter Course Name: ");
            this.courseName = Console.ReadLine();
        }

        public int CourseId
        {
            get { return courseId; }
            set { courseId = value; }
        }

        public string CourseName
        {
            get { return courseName; }
            set { courseName = value; }
        }

        public void AddCourseToDatabase()
        {
            try
            {
                using (SqlConnection connection = GetConnection())
                {
                    string query = "INSERT INTO Courses (CourseId, CourseName) VALUES (@CourseId, @CourseName)";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@CourseId", this.CourseId);
                        command.Parameters.AddWithValue("@CourseName", this.CourseName);

                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }

        private SqlConnection GetConnection()
        {
            return new SqlConnection("Data Source=ICS-LT-CRY19C3;Initial Catalog=SMSProject;" +
                "Integrated Security=True");
        }
    }
}
