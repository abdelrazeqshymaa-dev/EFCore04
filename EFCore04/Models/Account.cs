using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore04.Models
{
    public class Account
    {
        public string AccountNumber { get; set; } = null!;  // PK
        public AccountType AccountType { get; set; }
        public decimal CurrentBalance { get; set; }
        public DateTime OpeningDate { get; set; }

        public int BranchId { get; set; }
        public Branch Branch { get; set; } = null!;

        public ICollection<CustomerAccount> CustomerAccounts { get; set; } = new List<CustomerAccount>();
        public ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();
    }
}
