using System;
using System.Threading.Tasks;
using CoreCLR.JsonRpc.Client.Interfaces;

namespace CoreCLR.JsonRpc.Client.Helpers
{
    public class GuidIdGenerator : IIdGenerator
    {
        public async Task<object> GenerateId()
        {
            return await Task.FromResult(Guid.NewGuid().ToString());
        }
    }
}