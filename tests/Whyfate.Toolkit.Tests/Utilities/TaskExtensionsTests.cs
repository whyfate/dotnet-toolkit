using Whyfate.Toolkit.Utility;

namespace Whyfate.Toolkit.Tests.Utilities;

public class TaskExtensionsTests
{
    [Fact]
    public void TestWaitResultExt()
    {
        var task = Task.Delay(1);
        task.WaitExt();
    }
    
    [Fact]
    public void TestWaitResultExtT()
    {
        var task = Task.FromResult(1);
        var i = task.WaitResultExt();
        Assert.Equal(1, i);
    }
}