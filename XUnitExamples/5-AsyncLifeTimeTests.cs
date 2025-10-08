/*
    You cannot call asynchronous methods in a constructor. You can implement IAsyncLifetime to get both an async startup
    and cleanup method. If you only need an async dispose method, you can implement IAsyncDisposable on its own, 
    IAsyncLifetime inherits IAsyncDisposable.
    
    https://xunit.net/docs/shared-context#constructor
 */

using XUnitExamples.Fixtures;

namespace XUnitExamples;

public class AsyncLifetimeTests : IAsyncLifetime, IClassFixture<DatabaseFixture>
{
    private readonly DatabaseFixture _fixture;
    private readonly Stack<int> _stack = new();

    public AsyncLifetimeTests(DatabaseFixture fixture)
    {
        _fixture = fixture;
    }
    
    public async ValueTask InitializeAsync()
    {
        // Simulate an async operation
        var vegetable = await _fixture.GetFirstVegetable();
    }
    
    public ValueTask DisposeAsync()
    {
        // Simulate an async operation
        return ValueTask.CompletedTask;
    }

    [Fact]
    public void New_collection_starts_with_zero_items()
    {
        var count = _stack.Count;

        Assert.Equal(0, count);
    }

    [Fact]
    public void Adding_an_item_increases_count_to_one()
    {
        _stack.Push(42);

        var count = _stack.Count;

        Assert.Equal(1, count);
    }
    
    [Fact]
    public void Each_test_gets_a_fresh_collection_instance()
    {
        _stack.Push(99);

        var count = _stack.Count;

        Assert.Equal(1, count);
    }
}