using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace StudentManagementSystem
{
    public class EnrollmentRepository
    {
        private string connectionString;

        public EnrollmentRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public List<Enrollment> GetAllEnrollmentsWithDetails()
        {
            List<Enrollment> enrollments = new List<Enrollment>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT E.StudentId, S.Name AS StudentName, E.CourseId FROM Enrollments E " +
                               "JOIN Students S ON E.StudentId = S.Id";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        int studentId = reader.GetInt32(0);
                        string studentName = reader.GetString(1);
                        int courseId = reader.GetInt32(2);

                        // Create a new EnrollmentInfo object and add it to the list
                       
                    }

                    reader.Close();
                }
            }

            return enrollments;
        }
    }

}
