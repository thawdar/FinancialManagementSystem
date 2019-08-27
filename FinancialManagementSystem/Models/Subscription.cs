using System;
using Model.Attributes;

namespace FinancialManagementSystem.Models
{
    public class Subscription
    {
        [PrimaryKey]
        public Guid SubscriptionId { get; set; }
        public DateTime SubscriptionDateDate { get; set; }
        public DateTime ValidUntil { get; set; }
        public decimal Amount { get; set; }
        public Guid ProfileId { get; set; }
    }
}
