using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Merchant.Models
{
    public class TipGuide
    {
        [JsonPropertyName("countryName")]
        public string CountryName { get; set; }

        [JsonPropertyName("tipCategoryDesc")] //Restaurant
        public string TipCategoryDesc { get; set; }

        [JsonPropertyName("tipClassificationDesc")]
        public string TipClassificationDesc { get; set; }

        [JsonPropertyName("defaultTipAmount")]
        public string DefaultTipAmount { get; set; }

        [JsonPropertyName("tipDescription")]
        public string TipDescription { get; set; }
    }
}

//{
//        "tipEtiquetteGuideId": 199,
//        "isoCurrencyCode": "GTQ",
//        "langCde": "en",
//        "tipDescription": "10% -15%",
//        "defaultTipAmount": "15",
//        "countryName": "Guatemala",
//        "countryIsoNumber": 704,
//        "currencyDesc": "Guatemalan Quetzal",
//        "tipCategoryId": 2,
//        "tipCategoryDesc": "Restaurant",
//        "tipClassificationId": 2,
//        "tipClassificationDesc": "Percent"
//    }
