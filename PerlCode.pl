use strict;
use warnings;

# Define the LeaveRequest class
package LeaveRequest;

sub new {
    my ($class, $employee_name, $start_date, $end_date) = @_;
    my $self = {
        employee_name => $employee_name,
        start_date    => $start_date,
        end_date      => $end_date,
        approved      => 0
    };
    bless $self, $class;
    return $self;
}

sub approve {
    my ($self) = @_;
    $self->{approved} = 1;
}

sub is_approved {
    my ($self) = @_;
    return $self->{approved};
}

sub to_string {
    my ($self) = @_;
    return "Employee: $self->{employee_name}, Start Date: $self->{start_date}, End Date: $self->{end_date}, Approved: " . ($self->{approved} ? "Yes" : "No");
}

# Define the LeaveApplicationSystem class
package LeaveApplicationSystem;

sub new {
    my ($class) = @_;
    my $self = {
        leave_requests => []
    };
    bless $self, $class;
    return $self;
}

sub request_leave {
    my ($self) = @_;
    print "Leave Application\n";
    print "Enter your name: ";
    my $employee_name = <>;
    chomp($employee_name);
    print "Enter start date (yyyy-mm-dd): ";
    my $start_date = <>;
    chomp($start_date);
    print "Enter end date (yyyy-mm-dd): ";
    my $end_date = <>;
    chomp($end_date);

    my $request = LeaveRequest->new($employee_name, $start_date, $end_date);
    push @{$self->{leave_requests}}, $request;
    print "Leave request submitted.\n";
}

sub process_leave_requests {
    my ($self) = @_;
    print "Leave Requests\n";
    for my $i (0..$#{$self->{leave_requests}}) {
        my $request = $self->{leave_requests}[$i];
        print ($i + 1) . ". " . $request->to_string() . "\n";
    }

    print "Enter the number of the request to approve (0 to exit): ";
    my $choice = <>;
    chomp($choice);

    if ($choice eq '0') {
        return;
    }

    if ($choice =~ /^\d+$/ && $choice >= 1 && $choice <= @{$self->{leave_requests}}) {
        my $request = $self->{leave_requests}[$choice - 1];
        $request->approve();
        print "Leave request approved.\n";
    } else {
        print "Invalid choice.\n";
    }
}

sub run {
    my ($self) = @_;
    while (1) {
        print "\nLeave Application System\n";
        print "1. Request Leave\n";
        print "2. Process Leave Requests\n";
        print "3. Exit\n";
        print "Enter your choice: ";
        my $choice = <>;
        chomp($choice);

        if ($choice eq '1') {
            $self->request_leave();
        } elsif ($choice eq '2') {
            $self->process_leave_requests();
        } elsif ($choice eq '3') {
            print "Exiting the application.\n";
            last;
        } else {
            print "Invalid choice. Please try again.\n";
        }
    }
}

# Main program
my $leave_system = LeaveApplicationSystem->new();
$leave_system->run();
