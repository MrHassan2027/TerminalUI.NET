using TerminalUI.NET.Core;

namespace TerminalUI.NET.Widgets;

public interface IWidget { void Render(Renderer r); }

public class Panel : IWidget
{
    private readonly int _x, _y, _w, _h;
    private readonly string _title;
    private readonly List<string> _rows = new();

    public Panel(int x, int y, int w, int h, string title)
        => (_x, _y, _w, _h, _title) = (x, y, w, h, title);

    public void AddRow(string text) => _rows.Add(text);
    public void Clear() => _rows.Clear();

    public void Render(Renderer r)
    {
        r.DrawBox(_x, _y, _w, _h, _title);
        int maxRows = _h - 2;
        var visible = _rows.TakeLast(maxRows).ToList();
        for (int i = 0; i < visible.Count; i++)
        {
            var text = visible[i];
            if (text.Length > _w - 4) text = text[..(_w - 4)];
            r.WriteAt(_x + 2, _y + 1 + i, text.PadRight(_w - 4));
        }
    }
}
