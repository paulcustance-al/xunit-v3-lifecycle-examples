using System.Text;

namespace XUnitExamples.Fixtures;

public class DatabaseFixture : IDisposable
{
    private readonly StringBuilder _sb = new();
    public string Logs
    {
        get
        {
            var logs = _sb.ToString();
            _sb.Clear();
            return logs;
        }
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