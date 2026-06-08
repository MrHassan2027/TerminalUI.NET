using TerminalUI.NET.Widgets;

namespace TerminalUI.NET.Core;

public class TuiApp
{
    private readonly List<IWidget> _widgets = new();
    private readonly Renderer _renderer = new();
    private bool _running;

    public Panel AddPanel(int x, int y, int width, int height, string title = "")
    {
        var p = new Panel(x, y, width, height, title);
        _widgets.Add(p);
        return p;
    }

    public Table AddTable(int x, int y, string[] columns)
    {
        var t = new Table(x, y, columns);
        _widgets.Add(t);
        return t;
    }

    public ProgressBar AddProgressBar(int x, int y, int width, string label = "")
    {
        var pb = new ProgressBar(x, y, width, label);
        _widgets.Add(pb);
        return pb;
    }

    public void Run()
    {
        Console.CursorVisible = false;
        Console.Clear();
        _running = true;

        _ = Task.Run(RenderLoop);

        while (_running)
        {
            if (!Console.KeyAvailable) { Thread.Sleep(16); continue; }
            var key = Console.ReadKey(true);
            if (key.Key == ConsoleKey.Q) _running = false;
        }

        Console.CursorVisible = true;
        Console.Clear();
    }

    public void Stop() => _running = false;

    private void RenderLoop()
    {
        while (_running)
        {
            _renderer.BeginFrame();
            foreach (var w in _widgets) w.Render(_renderer);
            _renderer.Flush();
            Thread.Sleep(50);
        }
    }
}
