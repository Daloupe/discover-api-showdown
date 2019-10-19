using System;

namespace User
{
    public class ClaimItem
    {
        public Guid UserId { get; set; }
        public Guid ItemId { get; set; }
    }
    public class PayBill
    {
        public Guid UserId { get; set; }
        public decimal TipAmount { get; set; }
    }
}
