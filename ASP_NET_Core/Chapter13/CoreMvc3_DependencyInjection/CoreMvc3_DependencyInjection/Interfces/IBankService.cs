using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreMvc3_DependencyInjection.Interfces
{
    public interface IBankService
    {
        string BankId { get; }

        string BankName { get; }

        //查詢帳戶餘額
        decimal AccountBalance(string depositorId);

        //提款
        bool Withdraw(decimal dollars);

        //存款
        bool Deposit(decimal dollars);
    }
}
