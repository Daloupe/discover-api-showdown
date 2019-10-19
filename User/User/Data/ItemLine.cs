using System;

namespace User
{
    public class ItemLine
    {
        internal const int YES = 1;
        internal const int NO = 0;

        public Guid BillId { get; set; }
        public Guid ItemId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public bool IsClaimed { get; set; }
        public Guid? ClaimerId { get; set; }
        public bool IsPaid { get; set; }
        public Guid? PayerId { get; set; }
        public decimal Tip { get; set; }
        public string MerchantCountry { get; set; }
        public string MerchantCurrency { get; set; }
    }
}
