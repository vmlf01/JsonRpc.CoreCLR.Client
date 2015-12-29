using System.Threading.Tasks;

namespace CoreCLR.JsonRpc.Client.Interfaces
{
    public interface IIdGenerator
    {
        Task<object> GenerateId();
    }
}