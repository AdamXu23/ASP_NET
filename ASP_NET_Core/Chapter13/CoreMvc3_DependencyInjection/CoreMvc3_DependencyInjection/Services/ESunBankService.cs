using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreMvc3_DependencyInjection.Interfces;

namespace CoreMvc3_DependencyInjection.Services
{
    public class EsunBankService : IBankService
    {
        public string BankId { get; private set; }

        public string BankName { get; private set; }

        public EsunBankService()
        {
            BankId = "808";
            BankName = "玉山銀行";
        }

        public decimal AccountBalance(string depositorId)
        {
            decimal balance = 3000000;
            if (depositorId == "18072")
            {
                balance = 1500000;
            }

            return balance;
        }

        public bool Deposit(decimal dollars)
        {
            //...
            return true;
        }

        public bool Withdraw(decimal dollars)
        {
            //...
            return true;
        }
    }
}
