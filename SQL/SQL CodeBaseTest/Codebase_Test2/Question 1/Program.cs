using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace Codebase_Test2
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = "Data Source=ICS-LT-CRY19C3;Initial Catalog=AssignmentDB;" + "Integrated Security=True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                // calling our stored procedure
                using (SqlCommand cmd = new SqlCommand("AddEmployee", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    Console.WriteLine("Enter employee details:");
                    // Geting user input for employee name
                    Console.Write("Employee Name: ");
                    string empname = Console.ReadLine();
                    // Geting user input for employee salary
                    Console.Write("Employee Salary: ");
                    if (!decimal.TryParse(Console.ReadLine(), out decimal empsal))
                    {
                        Console.WriteLine("Invalid salary input.");
                        return;
                    }



                    // Geting the user input for employment type in capital letters only
                    Console.WriteLine("Employment Type (F for full-time, P for part-time): ");
                    Console.WriteLine("do not use small case as f or p");
                    string emptype = Console.ReadLine();
                    if (emptype != "F" && emptype != "P")
                    {
                        Console.WriteLine("Invalid employment type input.");
                        return;
                    }
                    cmd.Parameters.Add(new SqlParameter("@empname", empname));
                    cmd.Parameters.Add(new SqlParameter("@empsal", empsal));
                    cmd.Parameters.Add(new SqlParameter("@emptype", emptype));

                    // Executing the stored procedure
                    cmd.ExecuteNonQuery();
                }

                Console.WriteLine("Congratulations!! new Employee has been added successfully.");

                DisplayEmployeeRecords(connection);
                Console.ReadLine();
            }
        }
        //function for display the table through ado
        static void DisplayEmployeeRecords(SqlConnection connection)
        {
            Console.WriteLine("..............The Employee Table..............");
            using (SqlCommand selectCommand = new SqlCommand("SELECT * FROM Code_Employee", connection))
            using (SqlDataAdapter adapter = new SqlDataAdapter(selectCommand))
            {
                DataTable employeeTable = new DataTable();
                adapter.Fill(employeeTable);

                foreach (DataRow row in employeeTable.Rows)
                {
                    Console.WriteLine($"EmployeeID: {row["empno"]}, Name: {row["empname"]}, Salary: {row["empsal"]}, Type: {row["emptype"]}");
                }
            }
        }
    }
}