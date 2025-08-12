using System.ComponentModel;
using Whyfate.Toolkit.Utility;

namespace Whyfate.Toolkit.Tests.Utilities;

public class EnumUtilityTests
{
    [Fact]
    public void TestParse()
    {
        Assert.Equal(Gender.Male, "Male".Parse<Gender>());
        Assert.Equal(Gender.Famale, "Famale".Parse<Gender>());
        Assert.Equal(Gender.Unknown, "Unknown".Parse<Gender>());
        Assert.Equal(Gender.Male, "Male2".Parse<Gender>());
        Assert.Equal(Gender.Male, "Male2".Parse<Gender>(Gender.Male));
    }

    [Fact]
    public void TestParseWithDefauleValue()
    {
        Assert.Equal(Gender.Male, "Male".Parse<Gender>());
        Assert.Equal(Gender.Famale, "Male2".Parse(Gender.Famale));
        Assert.Equal(Gender.Male, "Male".Parse(Gender.Famale));
    }


    [Fact]
    public void TestGetAttribute()
    {
        Assert.Equal("1", Gender.Male.GetAttribute<Gender, CodeAttribute>()?.Code);
        Assert.Equal("2", Gender.Famale.GetAttribute<Gender, CodeAttribute>()?.Code);
        Assert.Equal("9", Gender.Unknown.GetAttribute<Gender, CodeAttribute>()?.Code);
        Assert.Null(((Gender)3).GetAttribute<Gender, CodeAttribute>()?.Code);
    }

    [Fact]
    public void TestGetDescription()
    {
        Assert.Equal("男", Gender.Male.GetDescription());
        Assert.Equal("女", Gender.Famale.GetDescription());
        Assert.Null(Gender.Unknown.GetDescription());
    }
}

enum Gender
{
    [Code("1")]
    [Description("男")]
    Male,
    [Code("2")]
    [Description("女")]
    Famale,
    [Code("9")]
    Unknown
}

class CodeAttribute(string code)
    : Attribute
{
    public string Code { get; } = code;
}