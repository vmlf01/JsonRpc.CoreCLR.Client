using System;
using System.Threading.Tasks;
using JsonRpc.CoreCLR.Client.Interfaces;

namespace JsonRpc.CoreCLR.Client.Helpers
{
    public class IntIdGenerator : IIdGenerator
    {
        static Int32 counterId = 1;
        Object countLock = new object();
        public object GenerateId()
        {
            Int32 i;
            lock (countLock)
            {
                i = counterId++;
            }
            return i.ToString();
        }
    }
}