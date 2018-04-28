using System;

namespace Kata.Bank.Domain
{
    public class Account
    {
        private Guid accountId;
        private double balance;
        private string currency;

        public static Account Empty()
        {
            return new Account(Guid.NewGuid(), 0, "EUR");
        }

        public static Account With(double balance)
        {
            return new Account(Guid.NewGuid(), balance);
        }

        private Account(Guid accountId, double balance, string currency)
            : this(accountId, balance)
        {
            if (string.IsNullOrEmpty(currency)) throw new ArgumentNullException();
            this.currency = currency;
        }

        public Account(Guid guid, double balance)
        {
            this.accountId = guid;
            this.balance = balance;
        }

        private Account()
        {
        }

        public void Credit(double amount)
        {
            if (amount <= 0)
                throw new Exception("A deposit must be positive");
            balance += amount;
        }

        public void Debit(double amount)
        {
            var tempBalance = balance + amount;
            if (tempBalance <= 0)
                throw new Exception("You're not authorized to debit your account");

            balance = tempBalance;
        }

        public double GetBalance()
        {
            return balance;
        }
    }
}
