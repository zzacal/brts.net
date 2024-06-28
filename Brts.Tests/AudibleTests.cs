using Brts.Audible;
using FluentAssertions;
using NSubstitute;

namespace Brts.Tests;

public class AudibleTests
{
    [Fact]
    public void UpdatingValue_CallsHandler()
    {
        var test = new Audible<int>(value: 0);
        test.Get().Should().Be(0);
        
        var handler = Substitute.For<Action<int>>();
        test.OnChange(handler);
        test.Set(1);
        test.Get().Should().Be(1);
        handler.Received()(1);
    }
    
    [Fact]
    public void UpdatingValueToNull_CallsHandlerWithNull()
    {
        var test = new Audible<int?>(value: 0);
        test.Get().Should().Be(0);
        
        var handler = Substitute.For<Action<int?>>();
        test.OnChange(handler);
        test.Set(null);
        test.Get().Should().Be(null);
        handler.Received()(null);
    }

    [Fact]
    public void UpdatingValue_WhenNoHandler_DoesNotThrow()
    {
        var test = new Audible<string>(value: "hello hello");
        test.Get().Should().Be("hello hello");
        
        test.Set("hello world");
        test.Get().Should().Be("hello world");
    }

    [Fact]
    public async void UpdatingValue_WhenHandlerAsync_CallsHandler()
    {
        var test = new AudibleAsync<string>("meow");
        var sideffect = "";

        var asyncHandler = async (string val) => await Task.Run(() => { sideffect = val; });
        test.OnChange(asyncHandler);

        await test.Set("not meow");

        sideffect.Should().Be("not meow");
    }
}