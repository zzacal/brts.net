using Brts.Audible;
using FluentAssertions;
using NSubstitute;

namespace Brts.Tests;

public class AudibleTests
{
    [Fact]
    public void UpdatingValiue_CallsHandler()
    {
        var test = new Audible<int>(value: 0);
        test.Value.Should().Be(0);
        
        var handler = Substitute.For<Action<int>>();
        test.OnChange(handler);
        test.Value = 1;
        test.Value.Should().Be(1);
        handler.Received()(1);
    }
    
    [Fact]
    public void UpdatingValiueToNull_CallsHandlerWithNull()
    {
        var test = new Audible<int?>(value: 0);
        test.Value.Should().Be(0);
        
        var handler = Substitute.For<Action<int?>>();
        test.OnChange(handler);
        test.Value = null;
        test.Value.Should().Be(null);
        handler.Received()(null);
    }

    [Fact]
    public void UpdatingValiueWhenNoHandler_DoesNotThrow()
    {
        var test = new Audible<string>(value: "hello hello");
        test.Value.Should().Be("hello hello");
        
        test.Value = "hello world";
        test.Value.Should().Be("hello world");
    }
}