using System;
using System.Data.SqlClient;


public class Sql_Connection

    {

        public static Sql_Connection GetConnection()
        {
            SqlConnection con = new SqlConnection("Data Source=ICS-LT-CRY19C3;Initial Catalog=SMSProject;" +
                "Integrated Security=True");
            con.Open();
            return con;
        }

        public static void AddStudentDetails(Student student)
        {
            using (SqlConnection connection = GetConnection())
            {
                string query = "INSERT INTO Students (Id, Name, DateOfBirth) VALUES (@Id, @Name, @DateOfBirth)";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", student.Id);
                    command.Parameters.AddWithValue("@Name", student.Name);
                    command.Parameters.AddWithValue("@DateOfBirth", student.DateOfBirth);

                    command.ExecuteNonQuery();
                }
            }
        }
    }
