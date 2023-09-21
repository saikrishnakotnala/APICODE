using System;
using System.Collections.Generic;

class LeaveRequest
{
    public string EmployeeName { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public bool Approved { get; set; }

    public LeaveRequest(string employeeName, DateTime startDate, DateTime endDate)
    {
        EmployeeName = employeeName;
        StartDate = startDate;
        EndDate = endDate;
        Approved = false;
    }

    public void Approve()
    {
        Approved = true;
    }

    public override string ToString()
    {
        return $"Employee: {EmployeeName}, Start Date: {StartDate.ToShortDateString()}, End Date: {EndDate.ToShortDateString()}, Approved: {Approved}";
    }
}

class LeaveApplicationSystem
{
    private List<LeaveRequest> leaveRequests = new List<LeaveRequest>();

    public void RequestLeave()
    {
        Console.WriteLine("Leave Application");
        Console.Write("Enter your name: ");
        string employeeName = Console.ReadLine();
        Console.Write("Enter start date (yyyy-mm-dd): ");
        DateTime startDate = DateTime.Parse(Console.ReadLine());
        Console.Write("Enter end date (yyyy-mm-dd): ");
        DateTime endDate = DateTime.Parse(Console.ReadLine());

        LeaveRequest request = new LeaveRequest(employeeName, startDate, endDate);
        leaveRequests.Add(request);
        Console.WriteLine("Leave request submitted.");
    }

    public void ProcessLeaveRequests()
    {
        Console.WriteLine("Leave Requests");
        for (int i = 0; i < leaveRequests.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {leaveRequests[i]}");
        }

        Console.Write("Enter the number of the request to approve (0 to exit): ");
        if (int.TryParse(Console.ReadLine(), out int choice))
        {
            if (choice >= 1 && choice <= leaveRequests.Count)
            {
                LeaveRequest request = leaveRequests[choice - 1];
                request.Approve();
                Console.WriteLine("Leave request approved.");
            }
            else if (choice != 0)
            {
                Console.WriteLine("Invalid choice.");
            }
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter a number.");
        }
    }

    public void Run()
    {
        while (true)
        {
            Console.WriteLine("\nLeave Application System");
            Console.WriteLine("1. Request Leave");
            Console.WriteLine("2. Process Leave Requests");
            Console.WriteLine("3. Exit");
            Console.Write("Enter your choice: ");

            if (int.TryParse(Console.ReadLine(), out int choice))
            {
                switch (choice)
                {
                    case 1:
                        RequestLeave();
                        break;
                    case 2:
                        ProcessLeaveRequests();
                        break;
                    case 3:
                        Console.WriteLine("Exiting the application.");
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a number.");
            }
        }
    }
}

class Program
{
    static void Main()
    {
        LeaveApplicationSystem leaveSystem = new LeaveApplicationSystem();
        leaveSystem.Run();
    }
}
