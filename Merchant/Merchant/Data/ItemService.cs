using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Merchant.Data
{
    public class ItemService
    {
        public static readonly Item[] _items = new[]
        {
            new Item
            {
                Name = "Coke 375ml",
                Price = 2.50m,
            },
            new Item
            {
                Name = "Sausage Roll",
                Price = 4.50m,
            },
            new Item
            {
                Name = "Meat Pie",
                Price = 3.50m,
            }
        };

        public Task<Item[]> GetItems()
        {
            return Task.FromResult(_items);
        }
    }
}
