using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Employee
{
    public int EmployeeID { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Title { get; set; }
    public DateTime DOB { get; set; }
    public DateTime DOJ { get; set; }
    public string City { get; set; }
}

class Program2
{
    static void Main()
    {
        List<Employee> empList = new List<Employee>
        {
            new Employee { EmployeeID = 1001, FirstName = "Malcolm", LastName = "Daruwalla", Title = "Manager", DOB = DateTime.ParseExact("16/11/1984", "dd/MM/yyyy", null), DOJ = DateTime.ParseExact("8/6/2011", "d/M/yyyy", null), City = "Mumbai" },
            new Employee { EmployeeID = 1002, FirstName = "Asdin", LastName = "Dhalla", Title = "AsstManager", DOB = DateTime.ParseExact("20/08/1984", "d/MM/yyyy", null), DOJ = DateTime.ParseExact("7/7/2012", "d/M/yyyy", null), City = "Mumbai" },
            new Employee { EmployeeID = 1003, FirstName = "Madhavi", LastName = "Oza", Title = "Consultant", DOB = DateTime.ParseExact("14/11/1987", "d/M/yyyy", null), DOJ = DateTime.ParseExact("12/4/2015", "d/M/yyyy", null), City = "Pune" },
            new Employee { EmployeeID = 1004, FirstName = "Saba", LastName = "Shaikh", Title = "SE", DOB = DateTime.ParseExact("3/6/1990", "d/M/yyyy", null), DOJ = DateTime.ParseExact("2/2/2016", "d/M/yyyy", null), City = "Pune" },
            new Employee { EmployeeID = 1005, FirstName = "Nazia", LastName = "Shaikh", Title = "SE", DOB = DateTime.ParseExact("8/3/1991", "d/M/yyyy", null), DOJ = DateTime.ParseExact("2/2/2016", "d/M/yyyy", null), City = "Mumbai" },
            new Employee { EmployeeID = 1006, FirstName = "Amit", LastName = "Pathak", Title = "Consultant", DOB = DateTime.ParseExact("7/11/1989", "d/M/yyyy", null), DOJ = DateTime.ParseExact("8/8/2014", "d/M/yyyy", null), City = "Chennai" },
            new Employee { EmployeeID = 1007, FirstName = "Vijay", LastName = "Natrajan", Title = "Consultant", DOB = DateTime.ParseExact("2/12/1989", "d/M/yyyy", null), DOJ = DateTime.ParseExact("1/6/2015", "d/M/yyyy", null), City = "Mumbai" },
            new Employee { EmployeeID = 1008, FirstName = "Rahul", LastName = "Dubey", Title = "Associate", DOB = DateTime.ParseExact("11/11/1993", "d/M/yyyy", null), DOJ = DateTime.ParseExact("6/11/2014", "d/M/yyyy", null), City = "Chennai" },
            new Employee { EmployeeID = 1009, FirstName = "Suresh", LastName = "Mistry", Title = "Associate", DOB = DateTime.ParseExact("12/8/1992", "d/M/yyyy", null), DOJ = DateTime.ParseExact("3/12/2014", "d/M/yyyy", null), City = "Chennai" },
            new Employee { EmployeeID = 1010, FirstName = "Sumit", LastName = "Shah", Title = "Manager", DOB = DateTime.ParseExact("12/4/1991", "d/M/yyyy", null), DOJ = DateTime.ParseExact("2/1/2016", "d/M/yyyy", null), City = "Pune" }
        };

        Console.WriteLine("a. Details of all employees:");
        foreach (var employee in empList)
        {
            Console.WriteLine($"Employee ID: {employee.EmployeeID}, Name: {employee.FirstName} {employee.LastName}, Title: {employee.Title}, DOB: {employee.DOB.ToShortDateString()}, DOJ: {employee.DOJ.ToShortDateString()}, City: {employee.City}");
        }

        Console.WriteLine("\nb. Details of employees whose location is not Mumbai:");
        var notMumbaiEmployees = empList.Where(employee => employee.City != "Mumbai");
        foreach (var employee in notMumbaiEmployees)
        {
            Console.WriteLine($"Employee ID: {employee.EmployeeID}, Name: {employee.FirstName} {employee.LastName}, Title: {employee.Title}, DOB: {employee.DOB.ToShortDateString()}, DOJ: {employee.DOJ.ToShortDateString()}, City: {employee.City}");
        }

        Console.WriteLine("\nc. Details of employees whose title is AsstManager:");
        var asstManagerEmployees = empList.Where(employee => employee.Title == "AsstManager");
        foreach (var employee in asstManagerEmployees)
        {
            Console.WriteLine($"Employee ID: {employee.EmployeeID}, Name: {employee.FirstName} {employee.LastName}, Title: {employee.Title}, DOB: {employee.DOB.ToShortDateString()}, DOJ: {employee.DOJ.ToShortDateString()}, City: {employee.City}");
        }

        Console.WriteLine("\nd. Details of employees whose Last Name starts with 'S':");
        var lastNameStartsWithS = empList.Where(employee => employee.LastName.StartsWith("S"));
        foreach (var employee in lastNameStartsWithS)
        {
            Console.WriteLine($"Employee ID: {employee.EmployeeID}, Name: {employee.FirstName} {employee.LastName}, Title: {employee.Title}, DOB: {employee.DOB.ToShortDateString()}, DOJ: {employee.DOJ.ToShortDateString()}, City: {employee.City}");
        }
        Console.ReadLine();
    }
}