using System.Text;

namespace XUnitExamples.Fixtures;

public class DatabaseFixture : IDisposable
{
    private readonly StringBuilder _sb = new();
    private readonly List<string> _vegetables = ["Carrot", "Tomato", "Cucumber"];
    
    public string Logs
    {
        get
        {
            var logs = _sb.ToString();
            _sb.Clear();
            return logs;
        }
    }

    public List<string> GetVegetables()
    {
        return _vegetables;
    }

    public async Task<string> GetFirstVegetable()
    {
        await Task.Delay(1000);
        return _vegetables[0];
    }

    public void AddVegetable(string vegetable)
    {
        _vegetables.Add(vegetable);
    }

    public DatabaseFixture()
    { 
        _sb.AppendLine("Initializing test database...");
    }

    public void Dispose()
    {
        _sb.AppendLine($"Cleaning up test database...");
    }
}