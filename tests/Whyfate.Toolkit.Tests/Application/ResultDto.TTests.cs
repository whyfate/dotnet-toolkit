using Whyfate.Toolkit.Application;

namespace Whyfate.Toolkit.Tests.Application;

public class ResultDtoTTests
{
    [Fact]
    public void TestSucceed()
    {
        var dto = ResultDto<string>.Succeed("1");
        Assert.True(dto.IsSuccess);
        Assert.Equal("1", dto.Data);
        Assert.Null(dto.Message);
        Assert.Null(dto.ErrorCode);
    }
    
    [Fact]
    public void TestFailed()
    {
        var dto = ResultDto<string>.Failed("test.error","test error message");
        Assert.False(dto.IsSuccess);
        Assert.Null(dto.Data);        
        Assert.NotNull(dto.ErrorCode);
        Assert.Equal("test.error", dto.ErrorCode);
        Assert.NotNull(dto.Message);
        Assert.Equal("test error message", dto.Message);
    }
}