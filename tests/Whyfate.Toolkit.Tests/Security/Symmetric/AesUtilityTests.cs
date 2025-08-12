using Whyfate.Toolkit.Security.Symmetric;

namespace Whyfate.Toolkit.Tests.Security.Symmetric;

public class AesUtilityTests
{
    private readonly string _key = "pass.whyfate.com";
    private readonly string _iv = "abcdef9876543210";

    private readonly string _plainText = """
                                        {
                                          "a":"a",
                                          "b": 1,
                                          "c": [],
                                          "d": true
                                        }
                                        """;

    private readonly string _ecbCipherText = "b2DQ03I23JeZQZz3WOygsOcomzPOKbagtnJAyLy+l6mtmPN3RSIbumO28lJXVdWhiWe/AESZT7aB0vM+xBsUgg==";
    private readonly string _cbcCipherText = "tQtKCyXecrW/zO6kEMV+8yoxnRjhl2HOt9ZBH67h1kp1HTjnOC9M/3WNXtP3mIDwhdLAUcUaYXWCtPRDO2UZRQ==";

    [Fact]
    public void TestEncrypt()
    {
        var result = AesUtility.Encrypt(_plainText, _key);
        Assert.Equal(_ecbCipherText, result);
    }

    [Fact]
    public void TestDecrypt()
    {
        var result = AesUtility.Decrypt(_ecbCipherText, _key);
        Assert.Equal(_plainText, result);
    }

    [Fact]
    public void TestEncryptCbc()
    {
        var result = AesUtility.Encrypt(_plainText, _key,_iv);
        Assert.Equal(_cbcCipherText, result);
    }

    [Fact]
    public void TestDecryptCbc()
    {
        var result = AesUtility.Decrypt(_cbcCipherText, _key, _iv);
        Assert.Equal(_plainText, result);
    }
}