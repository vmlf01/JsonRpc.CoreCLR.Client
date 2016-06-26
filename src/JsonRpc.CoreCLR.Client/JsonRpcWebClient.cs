using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using JsonRpc.CoreCLR.Client.Interfaces;
using JsonRpc.CoreCLR.Client.Models;
using JsonRpc.CoreCLR.Client.Helpers;

namespace JsonRpc.CoreCLR.Client
{
    public class JsonRpcWebClient : IJsonRpcClient
    {
        public Uri ServiceEndpoint { get; private set; }
        private IIdGenerator IdGenerator { get; set; }
        private IWebRequestPreProcessor RequestPreProcessor { get; set; }

        public JsonRpcWebClient(Uri serviceEndpoint)
            : this(serviceEndpoint, null, new GuidIdGenerator())
        {
        }

        public JsonRpcWebClient(Uri serviceEndpoint, IWebRequestPreProcessor requestPreProcessor)
            : this(serviceEndpoint, requestPreProcessor, new GuidIdGenerator())
        {
        }

        public JsonRpcWebClient(Uri serviceEndpoint, IWebRequestPreProcessor requestPreProcessor, IIdGenerator idGenerator)
        {
            this.ServiceEndpoint = serviceEndpoint;
            this.RequestPreProcessor = requestPreProcessor;
            this.IdGenerator = idGenerator;
        }

        public async Task<JsonRpcResponse<T>> InvokeAsync<T>(string method, object args)
        {
            var req = new JsonRpcRequest()
            {
                Method = method,
                Params = args
            };
            return await InvokeAsync<T>(req);
        }

        public async Task<JsonRpcResponse<T>> InvokeAsync<T>(string method, object[] args)
        {
            var req = new JsonRpcRequest()
            {
                Method = method,
                Params = args
            };
            return await InvokeAsync<T>(req);
        }

        public async Task<JsonRpcResponse<T>> InvokeAsync<T>(JsonRpcRequest jsonRpc)
        {
            await GenerateRequestId(jsonRpc);

            WebRequest req = await CreateWebRequest(jsonRpc);

            await PreProcessRequest(req, jsonRpc);

            using (var res = await SendWebRequest(req, jsonRpc))
            {
                var stringResponse = await GetResponseString(res);

                var jsonResponse = await DeserializeResponse<T>(stringResponse);

                return jsonResponse;
            }
        }

        private async Task GenerateRequestId(JsonRpcRequest jsonRpc)
        {
            if (!jsonRpc.IsNotification && jsonRpc.Id == null)
            {
                jsonRpc.Id = await IdGenerator.GenerateId();
            }
        }

        private Task<WebRequest> CreateWebRequest(JsonRpcRequest jsonRpc)
        {
            WebRequest req = HttpWebRequest.Create(ServiceEndpoint);
            req.Method = "POST";
            req.ContentType = "application/json-rpc";
            return Task.FromResult(req);
        }

        private async Task<WebRequest> PreProcessRequest(WebRequest req, JsonRpcRequest jsonRpc)
        {
            if (this.RequestPreProcessor != null)
            {
                await this.RequestPreProcessor.PreProcessRequest(req, jsonRpc);
            }

            return req;
        }

        private async Task<WebResponse> SendWebRequest(WebRequest req, JsonRpcRequest jsonRpc)
        {
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(jsonRpc);

            using (var requestStream = await req.GetRequestStreamAsync())
            {
                using (var stream = new StreamWriter(requestStream))
                {
                    await stream.WriteAsync(json);
                }
            }

            return await req.GetResponseAsync();
        }

        private async Task<string> GetResponseString(WebResponse res)
        {
            var stringResponse = "";
            using (var rstream = new StreamReader(res.GetResponseStream()))
            {
                stringResponse = await rstream.ReadToEndAsync();
            }

            return stringResponse;
        }

        private Task<JsonRpcResponse<T>> DeserializeResponse<T>(string rpcStringResponse)
        {
            var jsonResponse = Newtonsoft.Json.JsonConvert.DeserializeObject<JsonRpcResponse<T>>(rpcStringResponse);
            if (jsonResponse == null)
            {
                throw new InvalidOperationException("Invalid response");
            }

            return Task.FromResult(jsonResponse);
        }
    }
}
