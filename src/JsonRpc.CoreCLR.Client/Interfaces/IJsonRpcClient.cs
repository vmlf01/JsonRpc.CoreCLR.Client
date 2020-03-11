using System.Threading.Tasks;
using JsonRpc.CoreCLR.Client.Models;

namespace JsonRpc.CoreCLR.Client.Interfaces
{
    public interface IJsonRpcClient
    {
        /// <summary>
        /// Invokes the remote method using named arguments.
        /// Each field of the args object is an argument for the method.
        /// <param name="method">Name of method to invoke</param>
        /// <param name="args">Object with arguments to pass to invoked method</param>
        /// </summary>
        Task<JsonRpcResponse<T>> InvokeAsync<T>(string method, object args);

        /// <summary>
        /// Invokes the remote method using positional arguments
        /// <param name="method">Name of method to invoke</param>
        /// <param name="args">Array of arguments to pass to invoked method</param>
        /// </summary>
        Task<JsonRpcResponse<T>> InvokeAsync<T>(string method, object[] args);

        /// <summary>
        /// Invokes a remote method defined by the specified request
        /// <param name="jsonRpc">Definition of the remote method to invoke</param>
        /// </summary>
        Task<JsonRpcResponse<T>> InvokeAsync<T>(JsonRpcRequest jsonRpc);


        /// <summary>
        /// Invokes a remote method by notification. No reply is expected or handled
        /// <param name="jsonRpc">Definition of the remote method to invoke</param>
        /// </summary>
        void NotifyAsync(JsonRpcRequest jsonRpc);

    }
}