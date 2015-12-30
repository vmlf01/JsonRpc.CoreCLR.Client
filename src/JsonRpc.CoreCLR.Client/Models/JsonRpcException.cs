using Newtonsoft.Json;

namespace JsonRpc.CoreCLR.Client.Models
{
    [JsonObject(MemberSerialization.OptIn)]
    public class JsonRpcException
    {
        [JsonProperty("code")]
        public int Code { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("data")]
        public object Data { get; set; }

        public JsonRpcException(int code, string message, object data)
        {
            this.Code = code;
            this.Message = message;
            this.Data = data;
        }
    }
}
