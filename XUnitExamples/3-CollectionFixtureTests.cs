/*
  When to use: when you want to create a single test context and share it among tests in several test classes, and have 
  it cleaned up after all the tests in the test classes have finished.

  Sometimes you will want to share a fixture object among multiple test classes. The database example used for class 
  fixtures is a great example: you may want to initialize a database with a set of test data, and then leave that test 
  data in place for use by multiple test classes. You can use the collection fixture feature of xUnit.net to share a 
  single object instance among tests in several test classes.
  
  https://xunit.net/docs/shared-context#collection-fixture
*/

using XUnitExamples.Fixtures;

namespace XUnitExamples;

[Collection("Database collection")]
[Trait("Category", "TestsAcrossClasses")]
public class CollectionFixtureTest1
{
    private readonly DatabaseFixture _fixture;

    public CollectionFixtureTest1(DatabaseFixture fixture)
    {
        _fixture = fixture;
        Console.WriteLine("Hitting constructor...");
        Console.WriteLine(fixture.Logs);
    }
    
    [Fact]
    public void Test1()
    {
        _fixture.AddVegetable("Tomato");
        Console.WriteLine("Running Test 1...");
        Assert.True(true);
    }
    
    [Fact]
    public void Test2()
    {
        Console.WriteLine("Running Test 2...");
        Assert.True(true);
    }
}

[Collection("Database collection")]
[Trait("Category", "TestsAcrossClasses")]
public class CollectionFixtureTest2
{
    private readonly DatabaseFixture _fixture;

    public CollectionFixtureTest2(DatabaseFixture fixture)
    {
        _fixture = fixture;
        Console.WriteLine("Hitting constructor...");
        Console.WriteLine(fixture.Logs);
    }
    
    [Fact]
    public void Test1()
    {
        var vegetables = _fixture.GetVegetables();
        _fixture.AddVegetable("Cumquat");
        Console.WriteLine("Running Test 1...");
        Assert.True(true);
    }
    
    [Fact]
    public void Test2()
    {
        Console.WriteLine("Running Test 2...");
        Assert.True(true);
    }
}