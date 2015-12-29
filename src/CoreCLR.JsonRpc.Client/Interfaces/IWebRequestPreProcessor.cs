using System.Net;
using System.Threading.Tasks;
using CoreCLR.JsonRpc.Client.Models;

namespace CoreCLR.JsonRpc.Client.Interfaces
{
    public interface IWebRequestPreProcessor
    {
        Task PreProcessRequest(WebRequest webRequest, JsonRpcRequest rpcRequest);
    }
}