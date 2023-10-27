using System;
using System.Data.SqlClient;

namespace StudentManagementSystem
{
    public class Student
    {
        private int id;
        private string name;
        private DateTime dateOfBirth;

        public Student()
        {
            // Prompt the user to enter student details
            Console.Write("Enter Student ID: ");
            if (!int.TryParse(Console.ReadLine(), out this.id))
            {
                Console.WriteLine("Invalid ID. Using default ID (0).");
                this.id = 0;
            }

            Console.Write("Enter Student Name: ");
            this.name = Console.ReadLine();

            Console.Write("Enter Student Date of Birth (YYYY-MM-DD): ");
            if (!DateTime.TryParse(Console.ReadLine(), out this.dateOfBirth))
            {
                Console.WriteLine("Invalid date format. Using default date (MinValue).");
                this.dateOfBirth = DateTime.MinValue;
            }
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public DateTime DateOfBirth
        {
            get { return dateOfBirth; }
            set { dateOfBirth = value; }
        }

        public void AddStudentDetails()
        {
            try
            {
                using (SqlConnection connection = GetConnection())
                {
                    string query = "INSERT INTO Students (Id, Name, DateOfBirth) VALUES (@Id, @Name, @DateOfBirth)";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Id", this.Id);
                        command.Parameters.AddWithValue("@Name", this.Name);
                        command.Parameters.AddWithValue("@DateOfBirth", this.DateOfBirth);

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
        public Student(int id, string name, DateTime dateOfBirth)
        {
            this.id = id;
            this.name = name;
            this.dateOfBirth = dateOfBirth;
        }
    }
}
