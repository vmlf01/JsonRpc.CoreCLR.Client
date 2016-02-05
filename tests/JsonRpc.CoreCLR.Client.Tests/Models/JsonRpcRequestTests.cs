using System;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using Xunit;

using JsonRpc.CoreCLR.Client.Models;

namespace JsonRpc.CoreCLR.Client.Tests.Models
{
  public class JsonRpcRequestTests : IDisposable
  {
    JsonRpcRequest jsonRequest;

    public JsonRpcRequestTests()
    {
        jsonRequest = new JsonRpcRequest() {
            Method = "rpcMethod",
            Params = new { param1 = "value1" },
            Id = 123
        };
    }

    [Fact]
    public void ShouldSerializePublicInterface()
    {
        var json = Newtonsoft.Json.JsonConvert.SerializeObject(jsonRequest);

        Assert.Equal("{\"jsonrpc\":\"2.0\",\"method\":\"rpcMethod\",\"params\":{\"param1\":\"value1\"},\"id\":123}", json);
    }

    public void Dispose()
    {
    }
  }
}
