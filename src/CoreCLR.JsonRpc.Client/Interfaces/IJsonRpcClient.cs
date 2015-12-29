using System.Threading.Tasks;
using CoreCLR.JsonRpc.Client.Models;

namespace CoreCLR.JsonRpc.Client.Interfaces
{
    public interface IJsonRpcClient
    {
        Task<JsonRpcResponse<T>> InvokeAsync<T>(string method, object arg);
        Task<JsonRpcResponse<T>> InvokeAsync<T>(string method, object[] args);
        Task<JsonRpcResponse<T>> InvokeAsync<T>(JsonRpcRequest jsonRpc);
    }
}