using Whyfate.Toolkit.Exceptions;
using Whyfate.Toolkit.Exceptions.Business;
using Whyfate.Toolkit.Exceptions.Security;
using Whyfate.Toolkit.Exceptions.System;

namespace Whyfate.Toolkit.Tests.Exceptions;

public class ExceptionTests
{
    [Fact]
    public void TestThrowBusinessException()
    {
        var ex = new InvalidParameterException("username must not be empty.");
        Assert.Equal(ErrorCodes.InvalidParameter, ex.ErrorCode);

        var ex2 = new ResourceNotFoundException();
        Assert.Equal(ErrorCodes.ResourceNotFound, ex2.ErrorCode);
    }

    [Fact]
    public void TestThrowSystemException()
    {
        var ex = new ServerUnknownErrorException();
        Assert.Equal(ErrorCodes.ServerUnknownError, ex.ErrorCode);

        var ex2 = new ServiceUnavailableException("test-svc");
        Assert.Equal(ErrorCodes.ServiceUnavailable, ex2.ErrorCode);
        Assert.Equal("test-svc", ex2.TargetSvc);
    }

    [Fact]
    public void TestThrowSecurityException()
    {
        var ex = new ForbiddenException();
        Assert.Equal(ErrorCodes.Forbidden, ex.ErrorCode);
        
        var ex2 = new UnauthorizedException();
        Assert.Equal(ErrorCodes.Unauthorized, ex2.ErrorCode);
    }

    [Fact]
    public void TestInnerException()
    {
        var ex = new ForbiddenException(ErrorCodes.Forbidden, "Forbidden",new Exception("Inner exception"));
        Assert.NotNull(ex.InnerException);
    }
}