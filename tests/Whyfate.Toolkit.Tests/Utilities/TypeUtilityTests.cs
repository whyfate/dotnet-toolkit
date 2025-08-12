using Whyfate.Toolkit.Utility;

namespace Whyfate.Toolkit.Tests.Utilities;

public class TypeUtilityTests
{
    [Fact]
    public void TestGetPrivateType()
    {
        var typeName = typeof(int).FullName;
        var type2 = TypeUtility.GetType(typeName);
        Assert.NotNull(type2);
        Assert.Equal(typeName, type2.FullName);
    }

    [Fact]
    public void TestGetExecuteAssemblyType()
    {
        var typeName = typeof(TypeUtilityTests).FullName;
        var type2 = TypeUtility.GetType(typeName);
        Assert.NotNull(type2);
        Assert.Equal(typeName, type2.FullName);
    }


    [Fact]
    public void TestGetOtherAssemblyType()
    {
        var typeName = typeof(TypeUtility).FullName;
        var type2 = TypeUtility.GetType(typeName);
        Assert.NotNull(type2);
        Assert.Equal(typeName, type2.FullName);
    }

    [Theory]
    [InlineData(typeof(int), true)]
    [InlineData(typeof(float), true)]
    [InlineData(typeof(char), true)]
    [InlineData(typeof(byte), true)]
    [InlineData(typeof(bool), true)]
    [InlineData(typeof(Enum), true)]
    [InlineData(typeof(DateTime), true)]
    [InlineData(typeof(DateOnly), true)]
    [InlineData(typeof(TimeOnly), true)]
    [InlineData(typeof(DateTimeOffset), true)]
    [InlineData(typeof(string), true)]
    [InlineData(typeof(IDisposable), false)]
    [InlineData(typeof(object), false)]
    public void TestIsSimpleType(Type type, bool flag)
    {
        Assert.Equal(flag, TypeUtility.IsSimpleType(type));
    }
}