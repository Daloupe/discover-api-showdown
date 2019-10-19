using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Server.Controllers
{
    [ApiController]
    public class BillController : ControllerBase
    {
        private readonly ILogger<BillController> _logger;
        private static readonly ConcurrentDictionary<Guid, ItemLine> _itemLines = new ConcurrentDictionary<Guid, ItemLine>();

        public BillController(ILogger<BillController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("bill/{billid}")]
        public Task<IEnumerable<ItemLine>> Get(Guid billId)
        {
            _logger.LogInformation("Getting ItemLines for billId: " + billId);
            return Task.FromResult(_itemLines.Values.Where(x => x.BillId == billId));
        }

        [HttpPost]
        [Route("bill/create")]
        public Task<Guid> CreateBill(List<ItemLine> itemLines)
        {
            var billId = Guid.NewGuid();
            _logger.LogInformation("Creating Bill with Id: " + billId);
            //var itemLines = JsonSerializer.Deserialize<List<ItemLine>>(itemLinesJson);
            foreach (var itemLine in itemLines)
            {
                itemLine.BillId = billId;
                _itemLines.AddOrUpdate(itemLine.ItemId, itemLine, (id, existing) => itemLine);
            }
            return Task.FromResult(billId);
        }
    }
}
