using System;
using System.Threading.Tasks;

namespace Seedwork.CQRS.Bus.Core.Tests.UnitTests.Configurations.Stubs
{
    internal class BusSerializerStub : IBusSerializer
    {
        public Task<T> Deserialize<T>(byte[] data)
        {
            throw new InvalidOperationException();
        }

        public Task<byte[]> Serialize<T>(T obj)
        {
            throw new InvalidOperationException();
        }
    }
}