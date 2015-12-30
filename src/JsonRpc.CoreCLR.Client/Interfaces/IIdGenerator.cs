using System.Threading.Tasks;

namespace JsonRpc.CoreCLR.Client.Interfaces
{
    public interface IIdGenerator
    {
        Task<object> GenerateId();
    }
}