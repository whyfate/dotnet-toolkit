using Whyfate.Toolkit.Application;

namespace Whyfate.Toolkit.Tests.Application;

public class ResultDtoTests
{
    [Fact]
    public void TestSucceed()
    {
        var dto = ResultDto.Succeed();
        Assert.True(dto.IsSuccess);
        Assert.Null(dto.Message);
        Assert.Null(dto.ErrorCode);
    }
    
    [Fact]
    public void TestFailed()
    {
        var dto = ResultDto.Failed("test.error","test error message");
        Assert.False(dto.IsSuccess);
        Assert.NotNull(dto.ErrorCode);
        Assert.Equal("test.error", dto.ErrorCode);
        Assert.NotNull(dto.Message);
        Assert.Equal("test error message", dto.Message);
    }
}