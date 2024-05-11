namespace BankingSystemLoanApprovalSystem
{
    public class LoanApprovalSystem
    {
        public static void Main()
        {
            LoanProcessor processor = new LoanProcessor();

            // Define a delegate instance that represents a loan approval rule
            LoanApprovalDelegate approvalRule = (amount, creditScore) =>
            {
                // Simple loan approval criteria: Credit score must be 600 or higher
                return creditScore >= 600 && amount <= 100000;
            };

            // Process loan application using the defined delegate
            double requestedAmount = 80000;
            int applicantCreditScore = 650;

            bool isLoanApproved = processor.ProcessLoan(requestedAmount, applicantCreditScore, approvalRule);

            if (isLoanApproved)
            {
                Console.WriteLine("Congratulations! Your loan is approved.");
            }
            else
            {
                Console.WriteLine("Sorry, your loan application was not approved.");
            }
        }
    }

    // Delegate for loan approval
    public delegate bool LoanApprovalDelegate(double amount, int creditScore);
    public class LoanProcessor
    {
        public bool ProcessLoan(double loanAmount, int creditScore, LoanApprovalDelegate approvalDelegate)
        {
            return approvalDelegate(loanAmount, creditScore);
        }
    }
}

