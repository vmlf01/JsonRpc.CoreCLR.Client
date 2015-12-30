using Newtonsoft.Json;

namespace JsonRpc.CoreCLR.Client.Models
{
    [JsonObject(MemberSerialization.OptIn)]
    public class JsonRpcRequest
    {
        public bool IsNotification { get; set; }

        [JsonProperty("method")]
        public string Method { get; set; }

        [JsonProperty("params")]
        public object Params { get; set; }

        [JsonProperty("id")]
        public object Id { get; set; }
    }
}
