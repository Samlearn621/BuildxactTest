using Newtonsoft.Json;
using System.Collections.Generic;

namespace buildxact_supplies.Models
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
    public class Supply
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("uom")]
        public string Uom { get; set; }

        [JsonProperty("priceInCents")]
        public int PriceInCents { get; set; }

        [JsonProperty("providerId")]
        public string ProviderId { get; set; }

        [JsonProperty("materialType")]
        public string MaterialType { get; set; }
    }

    public class Partner
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("partnerType")]
        public string PartnerType { get; set; }

        [JsonProperty("partnerAddress")]
        public string PartnerAddress { get; set; }

        [JsonProperty("supplies")]
        public List<Supply> Supplies { get; set; }
    }

    public class JsonSupplierModel
    {
        [JsonProperty("partners")]
        public List<Partner> Partners { get; set; }
    }


}
