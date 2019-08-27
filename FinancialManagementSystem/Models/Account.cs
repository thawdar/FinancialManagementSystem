using System;
using System.ComponentModel.DataAnnotations;
using Model.Attributes;

namespace FinancialManagementSystem.Models
{
    public class Account
    {
        [PrimaryKey]
        public Guid AccountId { get; set; }
        public string AccountName { get; set; }
        public string AccountType { get; set; }
        public DateTime OpeningDate { get; set; }
        public decimal OpeningBalance { get; set; }
        public Guid ProfileId { get; set; }

    }
}
