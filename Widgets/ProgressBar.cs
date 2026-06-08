using TerminalUI.NET.Core;

namespace TerminalUI.NET.Widgets;

public class ProgressBar : IWidget
{
    private readonly int _x, _y, _width;
    private readonly string _label;
    public float Value { get; set; } // 0.0 - 1.0

    public ProgressBar(int x, int y, int width, string label)
        => (_x, _y, _width, _label) = (x, y, width, label);

    public void Render(Renderer r)
    {
        int filled = (int)(Value * (_width - 2));
        filled = Math.Clamp(filled, 0, _width - 2);
        var bar = "[" + new string('█', filled) + new string('░', _width - 2 - filled) + "]";
        var pct = $" {Value * 100:F0}%";
        var label = _label.Length > 0 ? _label + " " : "";
        r.WriteAt(_x, _y, label + bar + pct, Renderer.Ansi.Green);
    }
}
