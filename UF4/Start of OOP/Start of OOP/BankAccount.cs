namespace GestioBancaria
{
    public class BankAccount
    {
        private static int BANK_ID = 2100;
        private static string BANK_NAME = "TimoBank";
        private static double MAX_INT_RATE = 0.02;
        private string accountNumber;
        private string holderName;
        private string holderSurname;
        private double balance;
        private bool locked;
        private DateTime openingDate;
        private DateTime? closingDate = null;
        private DateTime? lastNegativeBalanceDate = null;

        public BankAccount(string accountNumber, string holderName, string holderSurname, double balance)
        {
            if (balance < 0) throw new Exception("balance can't be negative");
            this.accountNumber = accountNumber;
            this.holderName = holderName;
            this.holderSurname = holderSurname;
            this.balance = balance;
            this.locked = false;
            this.openingDate = DateTime.Now;
        }

        public BankAccount(string accountNumber, string holderName, string holderSurname)
            : this(accountNumber, holderName, holderSurname, 0)
        { }

        private void UpdateBalance(double amount)
        {
            
        }
        public bool Withdrawal(double amount)
        {
            return false;
        }
        public void Deposit(double amount)
        {
            balance += amount;
        }

        public bool IsLocked()
        {
            return this.locked;
        }

    }
}