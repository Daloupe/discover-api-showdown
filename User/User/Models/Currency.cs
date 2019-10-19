using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace User.Models
{
    public class Currency
    {
        [JsonPropertyName("curr_desc_en")]
        public string Name { get; set; }

        [JsonPropertyName("exchange_rate")]
        public decimal ExchangeRate { get; set; }
    }
}

//"currencies": [
// {
// "curr_cd": "AFN",
// "curr_desc_en": "Afghan Afghani",
// "curr_desc_es": "Afgani afgano",
// "curr_desc_de": "Afghanischer Afghani",
// "curr_desc_ja": "アフガニ",
// "curr_desc_ru": "Афганский афгани",
// "curr_desc_pt": "Afegane Afegão",
// "curr_desc_zh": "阿富汗阿富汗尼",
// "exchange_dt": "2017-04-20",
// "exchange_rate": 0.0155521
// },