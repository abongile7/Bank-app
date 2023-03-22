﻿using BankingApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BankingApp.Services
{
    public class CheckingAcctService
    {
        private ApplicationDbContext db { get; set; }

        public CheckingAcctService(ApplicationDbContext Db)
        {
            db = Db;
        }

        public void NewCheckingAcct(string firstname, string lastname, double balance, string id)
        {
            var acctno = ((123456 + db.CheckingAccts.Count()).ToString().PadRight(10, '0'));
            var checkingacct = new CheckingAcct
            {
                FirstName = firstname,
                LastName = lastname,
                Balance = balance,
                AccountNo = acctno,
                ApplicationUserId = id
            };

            db.CheckingAccts.Add(checkingacct);
            db.SaveChanges();
        }
    }
}