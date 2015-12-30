using System;
using System.Threading.Tasks;
using JsonRpc.CoreCLR.Client.Interfaces;

namespace JsonRpc.CoreCLR.Client.Helpers
{
    public class GuidIdGenerator : IIdGenerator
    {
        public async Task<object> GenerateId()
        {
            return await Task.FromResult(Guid.NewGuid().ToString());
        }
    }
}