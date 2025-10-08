/*
    When to use: when you want a clean test context for every test (sharing the setup and cleanup code, without sharing 
    the object instance).

    xUnit.net creates a new instance of the test class for every test that is run, so any code which is placed into the 
    constructor of the test class will be run for every single test. This makes the constructor a convenient place to 
    put reusable context setup code where you want to share the code without sharing object instances (meaning, you get
    a clean copy of the context object(s) for every test that is run).

    For context cleanup, add the IDisposable interface to your test class, and put the cleanup code in the Dispose() 
    method.
    
    https://xunit.net/docs/shared-context#constructor
 */

using System.Collections.Concurrent;

namespace XUnitExamples;

public class ConstructorAndDisposeTests : IDisposable
{
    private readonly BlockingCollection<int> _collection;

    // A new instance ins created on every test using the constructor
    public ConstructorAndDisposeTests()
    {
        _collection = new BlockingCollection<int>();
    }

    // When the instance is disposed if we have any unmanaged resources we can clean up when the 
    // dispose method is invoked by the garbage collector. Most of the time you won't need this dispose method.
    public void Dispose()
    {
        _collection.Dispose();
    }

    [Fact]
    public void New_collection_starts_with_zero_items()
    {
        var count = _collection.Count;

        Assert.Equal(0, count);
    }

    [Fact]
    public void Adding_an_item_increases_count_to_one()
    {
        _collection.Add(42, TestContext.Current.CancellationToken);

        var count = _collection.Count;

        Assert.Equal(1, count);
    }
    
    [Fact]
    public void Each_test_gets_a_fresh_collection_instance()
    {
        _collection.Add(99, TestContext.Current.CancellationToken);

        var count = _collection.Count;

        Assert.Equal(1, count);
    }
}