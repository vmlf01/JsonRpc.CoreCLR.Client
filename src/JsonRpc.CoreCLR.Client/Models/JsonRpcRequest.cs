using Newtonsoft.Json;

namespace JsonRpc.CoreCLR.Client.Models
{
    [JsonObject(MemberSerialization.OptIn)]
    public class JsonRpcRequest
    {
        public bool IsNotification { get; set; }

        [JsonProperty(PropertyName = "jsonrpc")]
        public string JsonRpc { get { return "2.0"; } }

        [JsonProperty("method")]
        public string Method { get; set; }

        /// <summary>
        /// Params can be an array of values for positional arguments,
        /// or an object for named arguments
        /// </summary>
        [JsonProperty("params")]
        public object Params { get; set; }

        [JsonProperty("id")]
        public object Id { get; set; }
    }
}
