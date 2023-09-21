import java.util.ArrayList;
import java.util.List;
import java.util.Scanner;



class LeaveRequest {
    private String employeeName;
    private String startDate;
    private String endDate;
    private boolean approved;

    public LeaveRequest(String employeeName, String startDate, String endDate) {
        this.employeeName = employeeName;
        this.startDate = startDate;
        this.endDate = endDate;
        this.approved = false;
    }

    public String getEmployeeName() {
        return employeeName;
    }

    public String getStartDate() {
        return startDate;
    }

    public String getEndDate() {
        return endDate;
    }

    public boolean isApproved() {
        return approved;
    }

    public void approve() {
        approved = true;
    }

    @Override
    public String toString() {
        return "LeaveRequest{" +
                "employeeName='" + employeeName + '\'' +
                ", startDate='" + startDate + '\'' +
                ", endDate='" + endDate + '\'' +
                ", approved=" + approved +
                '}';
    }
}

class LeaveApplicationSystem {
    private List<LeaveRequest> leaveRequests = new ArrayList<>();
    private Scanner scanner = new Scanner(System.in);

    public void requestLeave() {
        System.out.println("Leave Application");
        System.out.print("Enter your name: ");
        String employeeName = scanner.nextLine();
        System.out.print("Enter start date (yyyy-mm-dd): ");
        String startDate = scanner.nextLine();
        System.out.print("Enter end date (yyyy-mm-dd): ");
        String endDate = scanner.nextLine();

        LeaveRequest request = new LeaveRequest(employeeName, startDate, endDate);
        leaveRequests.add(request);
        System.out.println("Leave request submitted.");
    }

    public void processLeaveRequests() {
        System.out.println("Leave Requests");
        for (int i = 0; i < leaveRequests.size(); i++) {
            LeaveRequest request = leaveRequests.get(i);
            System.out.println((i + 1) + ". " + request);
        }

        System.out.print("Enter the number of the request to approve (0 to exit): ");
        int choice = scanner.nextInt();
        scanner.nextLine(); // Consume the newline character

        if (choice >= 1 && choice <= leaveRequests.size()) {
            LeaveRequest request = leaveRequests.get(choice - 1);
            request.approve();
            System.out.println("Leave request approved.");
        } else if (choice != 0) {
            System.out.println("Invalid choice.");
        }
    }

    public void run() {
        while (true) {
            System.out.println("\nLeave Application System");
            System.out.println("1. Request Leave");
            System.out.println("2. Process Leave Requests");
            System.out.println("3. Exit");
            System.out.print("Enter your choice: ");

            int choice = scanner.nextInt();
            scanner.nextLine(); // Consume the newline character

            switch (choice) {
                case 1:
                    requestLeave();
                    break;
                case 2:
                    processLeaveRequests();
                    break;
                case 3:
                    System.out.println("Exiting the application.");
                    return;
                default:
                    System.out.println("Invalid choice. Please try again.");
            }
        }
    }
}

public class Main {
    public static void main(String[] args) {
        LeaveApplicationSystem leaveSystem = new LeaveApplicationSystem();
        leaveSystem.run();
    }
}
