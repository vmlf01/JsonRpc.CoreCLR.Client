using System;
using System.Linq;
using System.Collections;
using System.Reflection;
using System.Threading.Tasks;
using Xunit;

using CoreCLR.JsonRpc.Client.Helpers;

namespace CoreCLR.JsonRpc.Client.Tests.Helpers
{
  public class GuidIdGeneratorTests : IDisposable
  {
    public GuidIdGeneratorTests()
    {
    }

    [Fact]
    public async Task ShouldGenerateAnId()
    {
        var generator = new GuidIdGenerator();
        var id = (await generator.GenerateId()).ToString();
        Assert.NotNull(id);
    }

    [Fact]
    public async Task ShouldGenerateADifferentIdEverytime()
    {
        var generator = new GuidIdGenerator();
        var id1 = (await generator.GenerateId()).ToString();
        var id2 = (await generator.GenerateId()).ToString();
        Assert.NotEqual(id1, id2);
    }
    
    [Fact]
    public async Task ShouldGenerateAGuidString()
    {
        var generator = new GuidIdGenerator();
        var id = (await generator.GenerateId()).ToString();
        Guid result;
        Assert.True(Guid.TryParse(id, out result));
    }
    
    public void Dispose()
    {
    }
  }
}
