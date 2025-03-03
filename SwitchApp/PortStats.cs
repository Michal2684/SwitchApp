
namespace SwitchApp;

public class PortStats
{
    public Dictionary<string, int> In { get; } = new();
    public Dictionary<string, int> Out { get; } = new();
}