using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Server.Controllers
{
    [ApiController]
    public class BillController : ControllerBase
    {
        private readonly ILogger<BillController> _logger;
        private static readonly ConcurrentDictionary<Guid, ItemLine> _itemLines = new ConcurrentDictionary<Guid, ItemLine>
        {
            [Guid.Empty] = new ItemLine
            {
                BillId = Guid.Empty,
                ItemId = Guid.Empty,
                Name = "Blah",
                Price = 2.1m,
            }
        };

        public BillController(ILogger<BillController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("bill/{billid}")]
        public IEnumerable<ItemLine> Get(Guid billId)
        {
            _logger.LogDebug("Getting ItemLines for billId: " + billId);
            return _itemLines.Values.Where(x => x.BillId == billId);
        }
    }
}
