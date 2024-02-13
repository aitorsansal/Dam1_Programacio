using System.Text;
using Microsoft.VisualBasic.CompilerServices;

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
            balance += amount;
        }

        public bool DoBizum(double amount, BankAccount otherBankAccount)
        {
            bool bizumWorked = true;
            if (amount < 0) //means you are sending bizum
            {
                if (balance - amount < 0) bizumWorked = false;
            }
            else
            {
                if (otherBankAccount.balance - amount < 0) bizumWorked = false;
            }
            if(bizumWorked)
            {
                UpdateBalance(amount);
                otherBankAccount.UpdateBalance(-amount);
            }
            return bizumWorked;
        }

        public bool Deposit(double amount) //todo should be bool type
        {
            if (amount < 0) return false;
            UpdateBalance(amount);
            return true;
        }
        public bool Withdrawal(double amount)
        {
            if (amount < 0) return false;
            UpdateBalance(-amount);
            return true;
        }

        public bool Close()
        {
            if (closingDate != null) return false;
            closingDate = DateTime.Now;
            return true;
        }

        public void ChangeReceipt(double amount)
        {
            UpdateBalance(amount);
            if (balance < 0) lastNegativeBalanceDate = DateTime.Now;
        }

        public void IncreaseInterest(double interestRate)
        {
            if (interestRate > 0 || interestRate < MAX_INT_RATE)
            {
                UpdateBalance(balance * interestRate);
            }
        }
        public bool IsLocked()
        {
            return locked;
        }

        public bool CheckNegativeBalance()
        {
            if (lastNegativeBalanceDate == null) return false;
            if(DateTime.Now.Month - lastNegativeBalanceDate.Value.Month >= 1) UpdateBalance(-100);
            return true;
        }

        public static BankAccount? MergeAccounts(BankAccount ba1, BankAccount ba2, string newId)
        {
            if (ba1.holderName != ba2.holderName || ba1.holderSurname != ba2.holderSurname) return null;
            if (ba1.balance + ba2.balance < 0) return null;
            double newBalance = ba1.balance + ba2.balance;
            BankAccount newBankAccount = new BankAccount(newId, ba1.holderName, ba1.holderSurname, newBalance);
            ba1.Close();
            ba2.Close();
            return newBankAccount;
        }

        public override string ToString()
        {
            StringBuilder sb = new();
            sb.Append($"Num c.c --> {accountNumber}");
            sb.Append("\n");
            sb.Append($"Titular --> {holderSurname}, {holderName}");
            sb.Append("\n");
            sb.Append($"Saldo --> {Math.Round(balance, 2)}");
            if (locked)
            {
                sb.Append("\n");
                sb.Append("Compte bloquejat");
            }
            return sb.ToString();
        }
    }
}