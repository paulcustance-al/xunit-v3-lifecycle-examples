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
    public ClassFixtureTests(DatabaseFixture fixture)
    {
        Console.WriteLine("Hitting constructor...");
        Console.WriteLine(fixture.Logs);
    }
    
    [Fact]
    public void Test1()
    {
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