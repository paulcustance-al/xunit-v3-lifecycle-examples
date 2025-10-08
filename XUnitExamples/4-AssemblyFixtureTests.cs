/*
    When to use: when you want to create a single test context and share it among all the tests in your test assembly.

    Newly introduced in Core Framework v3, you can now share a single instance of a fixture among all the test
    classes in your test assembly.

    Instance of assembly fixtures are created once before any test in your assembly is run, and cleaned up after
    all tests have finished running. Any test class may gain access to the assembly fixture simply by adding it as a
    constructor argument.

    Note that unlike collection fixtures, there is no change in parallelization when using an assembly fixture.
    This means fixtures used as assembly fixtures may be used from multiple tests simultaneously, and must be
    designed for with this parallelism requirement in mind. Alternatively, you could disable all parallelism in your
    test assembly by setting the parallelizeTestCollections configuration setting to false.

    To see the Assembly Attribute look in Properties/AssemblyInfo.cs file

    https://xunit.net/docs/shared-context#assembly-fixture
*/

using XUnitExamples.Fixtures;

[assembly: AssemblyFixture(typeof(DatabaseFixture))]

namespace XUnitExamples;

public class AssemblyFixtureTests
{
    public class CollectionFixtureTest1
    {
        public CollectionFixtureTest1(DatabaseFixture fixture)
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

    public class CollectionFixtureTest2
    {
        public CollectionFixtureTest2(DatabaseFixture fixture)
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
}