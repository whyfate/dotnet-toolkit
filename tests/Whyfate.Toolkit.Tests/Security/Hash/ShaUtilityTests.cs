using Whyfate.Toolkit.Security.Hash;

namespace Whyfate.Toolkit.Tests.Security.Hash;

public class ShaUtilityTests
{
    [Fact]
    public void Test()
    {
        var hash = ShaUtility.Sha256("123456");
        Assert.NotNull(hash);
    }
}