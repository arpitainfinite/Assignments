using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace StudentManagementSystem
{
    class AppEngine
    {
        public static List<Student> GetAllStudents()
        {
            List<Student> students = new List<Student>();

            using (SqlConnection connection = GetConnection())
            {
                string query = "SELECT * FROM Students";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    Console.WriteLine("{0, -5} {1, -20} {2, -15}", "ID", "Name", "Date of Birth");
                    Console.WriteLine(new string('-', 45)); // Add a line separator

                    while (reader.Read())
                    {
                        int id = reader.GetInt32(0);
                        string name = reader.GetString(1);
                        DateTime dateOfBirth = reader.GetDateTime(2);

                        Console.WriteLine("{0, -5} {1, -20} {2, -15}", id, name, dateOfBirth.ToString("yyyy-MM-dd"));
                    }

                    reader.Close();
                }
            }

            return students;
        }

        public static List<Course> GetAllCourses()
        {
            List<Course> courses = new List<Course>();

            using (SqlConnection connection = GetConnection())
            {
                string query = "SELECT * FROM Courses";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    Console.WriteLine("{0, -5} {1, -30}", "ID", "Course Name");
                    Console.WriteLine(new string('-', 20)); // Add a line separator

                    while (reader.Read())
                    {
                        int id = reader.GetInt32(0);
                        string courseName = reader.GetString(1);

                        Console.WriteLine("{0, -5} {1, -30}", id, courseName);
                    }

                    reader.Close();
                }
            }

            return courses;
        }



        private static SqlConnection GetConnection()
        {
            return new SqlConnection("Data Source=ICS-LT-CRY19C3;Initial Catalog=SMSProject;" +
                "Integrated Security=True");
        }

        public static void EnrollStudentInCourse(int studentId, int courseId)
        {
            using (SqlConnection connection = GetConnection())
            {
                string query = "INSERT INTO Enrollments (StudentId, CourseId) VALUES (@StudentId, @CourseId)";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@StudentId", studentId);
                    command.Parameters.AddWithValue("@CourseId", courseId);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }
        public static List<Enrollment> GetAllEnrollmentsWithDetails()
        {
            List<Enrollment> enrollments = new List<Enrollment>();

            using (SqlConnection connection = GetConnection())
            {
                connection.Open();

                string query = "SELECT E.StudentId, S.Name AS StudentName, E.CourseId, C.CourseName FROM Enrollments E " +
                               "JOIN Students S ON E.StudentId = S.Id " +
                               "JOIN Courses C ON E.CourseId = C.CourseId";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        int studentId = reader.GetInt32(0);
                        string studentName = reader.GetString(1);
                        int courseId = reader.GetInt32(2);
                        string courseName = reader.GetString(3);

                        // Create a new Enrollment object and add it to the list
                        enrollments.Add(new Enrollment(studentId, studentName, courseId, courseName));
                    }

                    reader.Close();
                }
            }

            return enrollments;
        }


        public static Student RetrieveStudentById(int studentId)
        {
            // Implement logic to retrieve student from database by ID
            // Example: return AppEngine.GetStudentById(studentId);
            using (SqlConnection connection = GetConnection())
            {
                connection.Open();
                string query = "SELECT * FROM Students WHERE Id = @StudentId";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@StudentId", studentId);
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        int id = reader.GetInt32(0);
                        string name = reader.GetString(1);
                        DateTime dateOfBirth = reader.GetDateTime(2);
                        return new Student { Id = id, Name = name, DateOfBirth = dateOfBirth };
                    }
                    return null; // Student not found
                }
            }
        }

        public static Course RetrieveCourseById(int courseId)
        {
            // Implement logic to retrieve course from database by ID
            // Example: return AppEngine.GetCourseById(courseId);
            using (SqlConnection connection = GetConnection())
            {
                connection.Open();
                string query = "SELECT * FROM Courses WHERE CourseId = @CourseId";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@CourseId", courseId);
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        int id = reader.GetInt32(0);
                        string courseName = reader.GetString(1);
                        return new Course { CourseId = id, CourseName = courseName };
                    }
                    return null; // Course not found
                }
            }
        }

        
    }

}


