using System.Security.Cryptography;
using Whyfate.Toolkit.Security.Asymmetric;

namespace Whyfate.Toolkit.Tests.Security.Asymmetric;

public class RsaUtilityTests
{
    [Fact]
    public void TestSample()
    {
        var txt = "123456";
        var encryptData = RsaUtility.Encrypt(txt);
        var decryptData = RsaUtility.Decrypt(encryptData);
        Assert.Equal(txt, decryptData);
    }
    
    [Fact]
    public void TestFull()
    {
        var txt = "123456";
        var encryptData = RsaUtility.Encrypt(RsaUtility.PublicKey,txt, RsaUtility.Padding);
        var decryptData = RsaUtility.Decrypt(RsaUtility.PrivateKey,encryptData, RsaUtility.Padding);
        Assert.Equal(txt, decryptData);
        
        var success = RsaUtility.TryDecryptData(RsaUtility.PrivateKey,encryptData, RsaUtility.Padding,out var decryptData2);
        Assert.True(success);
        Assert.Equal(txt, decryptData2);
    }
    
    [Fact]
    public void TestEncryptException()
    {
        Assert.Throws<ArgumentNullException>(() =>
        {
            RsaUtility.Encrypt("");
        });
        
        Assert.Throws<ArgumentNullException>(() =>
        {
            RsaUtility.Encrypt("", "test data", RSAEncryptionPadding.OaepSHA256);
        });
        
        Assert.Throws<ArgumentNullException>(() =>
        {
            RsaUtility.Encrypt("test key", "", RSAEncryptionPadding.OaepSHA256);
        });
    }
    
    [Fact]
    public void TestDecryptException()
    {
        Assert.Throws<ArgumentNullException>(() =>
        {
            RsaUtility.Decrypt("");
        });
        
        Assert.Throws<ArgumentNullException>(() =>
        {
            RsaUtility.Decrypt("", "test data", RSAEncryptionPadding.OaepSHA256);
        });
        
        Assert.Throws<ArgumentNullException>(() =>
        {
            RsaUtility.Decrypt("test key", "", RSAEncryptionPadding.OaepSHA256);
        });
    }
    
    [Fact]
    public void TestTryDecryptData()
    {
        var success = RsaUtility.TryDecryptData(RsaUtility.PrivateKey,"test error data", RSAEncryptionPadding.OaepSHA256,out string? data);
        Assert.False(success);
        Assert.Null(data);
    }
}