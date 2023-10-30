use strict;
use warnings;

sub main_menu {
    print "\nExpense Tracker\n";
    print "1. Add Expense\n";
    print "2. View Expenses\n";
    print "3. Exit\n";
    print "Enter your choice: ";
}



sub add_expense {
    print "\nAdd Expense\n";
    print "Enter the date (yyyy-mm-dd): ";
    my $date = <>;
    chomp($date);
    print "Enter the description: ";
    my $description = <>;
    chomp($description);
    print "Enter the amount: ";
    my $amount = <>;
    chomp($amount);

    open(my $fh, '>>', 'expenses.txt') or die "Could not open expenses.txt: $!";
    print $fh "$date|$description|$amount\n";
    close($fh);

    print "Expense added successfully.\n";
}

sub view_expenses {
    print "\nExpense List\n";
    open(my $fh, '<', 'expenses.txt') or die "Could not open expenses.txt: $!";
    while (my $line = <$fh>) {
        chomp($line);
        my ($date, $description, $amount) = split(/\|/, $line);
        print "Date: $date, Description: $description, Amount: $amount\n";
    }
    close($fh);
}

while (1) {
    main_menu();
    my $choice = <>;
    chomp($choice);

    if ($choice == 1) {
        add_expense();
    } elsif ($choice == 2) {
        view_expenses();
    } elsif ($choice == 3) {
        print "Exiting the Expense Tracker.\n";
        last;
    } else {
        print "Invalid choice. Please try again.\n";
    }
}
