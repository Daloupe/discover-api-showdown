using System;

namespace Merchant
{

    public class ItemLine
    {
        internal const int YES = 1;
        internal const int NO = 0;

        public Guid BillId { get; set; }
        public Guid ItemId { get; set; }        
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int IsClaimed { get; set; }
        public Guid ClaimerId { get; set; }
        public bool IsPaid { get; set; }
        public Guid PayerId { get; set; }
        public decimal Tip { get; set; }

        public static ItemLine From(Item item)
        {
            return new ItemLine
            {
                ItemId = Guid.NewGuid(),
                Name = item.Name,
                Price = item.Price,
            };
        }
    }
}