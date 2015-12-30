using System.Net;
using System.Threading.Tasks;
using JsonRpc.CoreCLR.Client.Models;

namespace JsonRpc.CoreCLR.Client.Interfaces
{
    public interface IWebRequestPreProcessor
    {
        Task PreProcessRequest(WebRequest webRequest, JsonRpcRequest rpcRequest);
    }
}