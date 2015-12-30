using System.Threading.Tasks;
using JsonRpc.CoreCLR.Client.Models;

namespace JsonRpc.CoreCLR.Client.Interfaces
{
    public interface IJsonRpcClient
    {
        Task<JsonRpcResponse<T>> InvokeAsync<T>(string method, object arg);
        Task<JsonRpcResponse<T>> InvokeAsync<T>(string method, object[] args);
        Task<JsonRpcResponse<T>> InvokeAsync<T>(JsonRpcRequest jsonRpc);
    }
}