using System;
using System.Collections.Generic;
using System.Text;

namespace BankLoan.Utilities.Messages
{
    public static class ExceptionMessages
    {
        public const string ClientNameNullOrWhitespace = "Client name cannot be null or empty.";//done
        public const string ClientIdNullOrWhitespace = "Client's ID cannot be null or empty.";//done
        public const string ClientIncomeBelowZero = "Income cannot be below or equal to 0.";//done
        public const string BankNameNullOrWhiteSpace = "Bank name cannot be null or empty.";//done
        public const string BankTypeInvalid = "Invalid bank type.";//done
        public const string LoanTypeInvalid = "Invalid loan type.";//done
        public const string MissingLoanFromType = "Loan of type {0} is missing.";//done
        public const string ClientTypeInvalid = "Invalid client type.";//done
    }
}
