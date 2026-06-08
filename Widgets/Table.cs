using TerminalUI.NET.Core;

namespace TerminalUI.NET.Widgets;

public class Table : IWidget
{
    private readonly int _x, _y;
    private readonly string[] _columns;
    private readonly List<string[]> _rows = new();
    private int _colWidth;

    public Table(int x, int y, string[] columns)
    {
        _x = x; _y = y; _columns = columns;
        _colWidth = Math.Max(12, columns.Max(c => c.Length) + 2);
    }

    public void AddRow(params string[] cells) => _rows.Add(cells);
    public void Clear() => _rows.Clear();

    public void Render(Renderer r)
    {
        int y = _y;
        var header = string.Concat(_columns.Select(c => c.PadRight(_colWidth)));
        r.WriteAt(_x, y++, header, Renderer.Ansi.Bold);
        r.WriteAt(_x, y++, new string('─', _columns.Length * _colWidth));
        foreach (var row in _rows)
        {
            var line = string.Concat(row.Select((c, i) =>
                (i < row.Length ? c : "").PadRight(_colWidth)));
            r.WriteAt(_x, y++, line);
        }
    }
}
