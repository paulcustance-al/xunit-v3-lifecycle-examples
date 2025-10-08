/*
    When to use: when you want to create a single test context and share it among all the tests in the class, and have it
    cleaned up after all the tests in the class have finished.

    Sometimes test context creation and cleanup can be very expensive. If you were to run the creation and cleanup code
    during every test, it might make the tests slower than you want. You can use the class fixture feature of xUnit.net
    to share a single object instance among all tests in a test class.

    https://xunit.net/docs/shared-context#class-fixture
*/

using XUnitExamples.Fixtures;

namespace XUnitExamples;

public class ClassFixtureTests : IClassFixture<DatabaseFixture>
{
    private readonly DatabaseFixture _fixture;

    public ClassFixtureTests(DatabaseFixture fixture)
    {
        _fixture = fixture;
        Console.WriteLine("Hitting class constructor...");
        Console.WriteLine(fixture.Logs);
    }
    
    [Fact]
    public void Test1()
    {
        var vegetables = _fixture.GetVegetables();
        _fixture.AddVegetable("Suede");
        Console.WriteLine("Running Test 1...");
        Assert.True(true);
    }
    
    [Fact]
    public void Test2()
    {
        var vegetables = _fixture.GetVegetables();
        _fixture.AddVegetable("Sweet Potato");
        Console.WriteLine("Running Test 2...");
        Assert.True(true);
    }
}