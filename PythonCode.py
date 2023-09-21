class LeaveRequest:
    def __init__(self, employee_name, start_date, end_date):
        self.employee_name = employee_name
        self.start_date = start_date
        self.end_date = end_date
        self.approved = False

    def approve(self):
        self.approved = True

    def __str__(self):
        return f"Employee: {self.employee_name}, Start Date: {self.start_date}, End Date: {self.end_date}, Approved: {self.approved}"

class LeaveApplicationSystem:
    def __init__(self):
        self.leave_requests = []

    def request_leave(self):
        print("Leave Application")
        employee_name = input("Enter your name: ")
        start_date = input("Enter start date (yyyy-mm-dd): ")
        end_date = input("Enter end date (yyyy-mm-dd): ")

        request = LeaveRequest(employee_name, start_date, end_date)
        self.leave_requests.append(request)
        print("Leave request submitted.")

    def process_leave_requests(self):
        print("Leave Requests")
        for i, request in enumerate(self.leave_requests, start=1):
            print(f"{i}. {request}")

        choice = input("Enter the number of the request to approve (0 to exit): ")
        if choice == '0':
            return

        try:
            choice = int(choice)
            if 1 <= choice <= len(self.leave_requests):
                request = self.leave_requests[choice - 1]
                request.approve()
                print("Leave request approved.")
            else:
                print("Invalid choice.")
        except ValueError:
            print("Invalid input. Please enter a number.")

    def run(self):
        while True:
            print("\nLeave Application System")
            print("1. Request Leave")
            print("2. Process Leave Requests")
            print("3. Exit")
            choice = input("Enter your choice: ")

            if choice == '1':
                self.request_leave()
            elif choice == '2':
                self.process_leave_requests()
            elif choice == '3':
                print("Exiting the application.")
                break
            else:
                print("Invalid choice. Please try again.")

if __name__ == "__main__":
    leave_system = LeaveApplicationSystem()
    leave_system.run()
