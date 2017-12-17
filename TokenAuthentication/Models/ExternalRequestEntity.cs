using Newtonsoft.Json;

namespace TokenAuthentication.Models
{
    public class ExternalRequestEntity
    {
        [JsonProperty("clientId")]
        public string ClientID { get; set; }

        [JsonProperty("clientKey")]
        public string ClientKey { get; set; }
    }
}