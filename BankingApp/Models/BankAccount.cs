using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BankingApp.Models
{
    public class BankAccount
    {
        [Key]
        public int Id { get; set; }
        public double Amount { get; set; }
        public double Balance { get; set; }
        public double Deposit { get; set; }
        public double Withdraw { get; set; }

        public double GetBalance()
        {
            return Amount;
        }

        public double DoDeposit(double amount)
        {
            Amount += amount;
            return Amount;
        }
        public double WithdrawFunds(double amount)
        {
            // check avail balance logic
            if (Amount < amount)
            {
                Amount = Amount;
            }
            else
            {
                Amount -= amount;
            }
            return Amount;
        }

    }
}