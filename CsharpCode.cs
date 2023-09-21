using System;
using System.Collections.Generic;

class Employee
{
    public string EmployeeId { get; set; }
    public string EmployeeName { get; set; }
    public Dictionary<DateTime, bool> Attendance { get; set; }

    public Employee(string employeeId, string employeeName)
    {
        EmployeeId = employeeId;
        EmployeeName = employeeName;
        Attendance = new Dictionary<DateTime, bool>();
    }
}

class AttendanceSystem
{
    private List<Employee> employees = new List<Employee>();

    public void AddEmployee(string employeeId, string employeeName)
    {
        Employee employee = new Employee(employeeId, employeeName);
        employees.Add(employee);
    }

    public void MarkAttendance(string employeeId, DateTime date)
    {
        Employee employee = employees.Find(emp => emp.EmployeeId == employeeId);

        if (employee != null)
        {
            if (!employee.Attendance.ContainsKey(date))
            {
                employee.Attendance[date] = true;
                Console.WriteLine($"{employee.EmployeeName} (ID: {employee.EmployeeId}) marked present on {date.ToShortDateString()}");
            }
            else
            {
                Console.WriteLine($"{employee.EmployeeName} (ID: {employee.EmployeeId}) has already been marked present on {date.ToShortDateString()}");
            }
        }
        else
        {
            Console.WriteLine($"Employee with ID {employeeId} not found.");
        }
    }

    public void ViewAttendance(string employeeId, DateTime startDate, DateTime endDate)
    {
        Employee employee = employees.Find(emp => emp.EmployeeId == employeeId);

        if (employee != null)
        {
            Console.WriteLine($"Attendance for {employee.EmployeeName} (ID: {employee.EmployeeId}) from {startDate.ToShortDateString()} to {endDate.ToShortDateString()}:");
            foreach (var entry in employee.Attendance)
            {
                if (entry.Key >= startDate && entry.Key <= endDate)
                {
                    string status = entry.Value ? "Present" : "Absent";
                    Console.WriteLine($"{entry.Key.ToShortDateString()}: {status}");
                }
            }
        }
        else
        {
            Console.WriteLine($"Employee with ID {employeeId} not found.");
        }
    }
}

class Program
{
    static void Main()
    {
        AttendanceSystem attendanceSystem = new AttendanceSystem();

        // Add employees
        attendanceSystem.AddEmployee("001", "John Doe");
        attendanceSystem.AddEmployee("002", "Jane Smith");

        while (true)
        {
            Console.WriteLine("\nEmployee Attendance System");
            Console.WriteLine("1. Mark Attendance");
            Console.WriteLine("2. View Attendance");
            Console.WriteLine("3. Exit");
            Console.Write("Enter your choice: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Write("Enter Employee ID: ");
                    string empId = Console.ReadLine();
                    Console.Write("Enter Date (yyyy-mm-dd): ");
                    DateTime date = DateTime.Parse(Console.ReadLine());
                    attendanceSystem.MarkAttendance(empId, date);
                    break;
                case "2":
                    Console.Write("Enter Employee ID: ");
                    string empIdToView = Console.ReadLine();
                    Console.Write("Enter Start Date (yyyy-mm-dd): ");
                    DateTime startDate = DateTime.Parse(Console.ReadLine());
                    Console.Write("Enter End Date (yyyy-mm-dd): ");
                    DateTime endDate = DateTime.Parse(Console.ReadLine());
                    attendanceSystem.ViewAttendance(empIdToView, startDate, endDate);
                    break;
                case "3":
                    Console.WriteLine("Exiting the application.");
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }
}
