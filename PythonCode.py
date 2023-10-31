class Loan:
    def __init__(self, customer_name, loan_amount, interest_rate, loan_term):
        self.customer_name = customer_name
        self.loan_amount = loan_amount
        self.interest_rate = interest_rate
        self.loan_term = loan_term
        self.balance = loan_amount
        self.payments = []


    def get_loan_summary(self):
        total_paid = sum(self.payments)
        return f"Customer: {self.customer_name}\n" \
               f"Loan Amount: ${self.loan_amount}\n" \
               f"Interest Rate: {self.interest_rate}%\n" \
               f"Loan Term (months): {self.loan_term}\n" \
               f"Outstanding Balance: ${self.balance}\n" \
               f"Total Paid: ${total_paid}\n"


def main():
    loans = []

    while True:
        print("\nLoan Management Application")
        print("1. Create Loan")
        print("2. Make Payment")
        print("3. Loan Summary")
        print("4. Exit")
        choice = input("Enter your choice: ")

        if choice == '1':
            customer_name = input("Enter customer name: ")
            loan_amount = float(input("Enter loan amount: $"))
            interest_rate = float(input("Enter interest rate (%): "))
            loan_term = int(input("Enter loan term (months): "))
            loan = Loan(customer_name, loan_amount, interest_rate, loan_term)
            loans.append(loan)
            print("Loan created successfully.")
        elif choice == '2':
            if not loans:
                print("No loans exist.")
                continue
            customer_name = input("Enter customer name: ")
            loan = next((l for l in loans if l.customer_name == customer_name), None)
            if loan:
                payment_amount = float(input("Enter payment amount: $"))
                loan.make_payment(payment_amount)
            else:
                print("Loan not found for this customer.")
        elif choice == '3':
            if not loans:
                print("No loans exist.")
                continue
            customer_name = input("Enter customer name: ")
            loan = next((l for l in loans if l.customer_name == customer_name), None)
            if loan:
                print(loan.get_loan_summary())
            else:
                print("Loan not found for this customer.")
        elif choice == '4':
            print("Exiting the application.")
            break
        else:
            print("Invalid choice. Please try again.")


if __name__ == "__main__":
    main()
