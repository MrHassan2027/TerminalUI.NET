using System.Text;

namespace TerminalUI.NET.Core;

public class Renderer
{
    private readonly StringBuilder _buf = new();

    public static class Ansi
    {
        public const string Reset  = "\x1b[0m";
        public const string Bold   = "\x1b[1m";
        public const string Red    = "\x1b[31m";
        public const string Green  = "\x1b[32m";
        public const string Yellow = "\x1b[33m";
        public const string Blue   = "\x1b[34m";
        public const string Cyan   = "\x1b[36m";
        public const string White  = "\x1b[37m";
        public static string MoveTo(int x, int y) => $"\x1b[{y + 1};{x + 1}H";
        public static string Fg(int r, int g, int b) => $"\x1b[38;2;{r};{g};{b}m";
        public static string Bg(int r, int g, int b) => $"\x1b[48;2;{r};{g};{b}m";
    }

    public void BeginFrame() => _buf.Clear();

    public void WriteAt(int x, int y, string text, string color = "")
    {
        _buf.Append(Ansi.MoveTo(x, y));
        if (!string.IsNullOrEmpty(color)) _buf.Append(color);
        _buf.Append(text);
        if (!string.IsNullOrEmpty(color)) _buf.Append(Ansi.Reset);
    }

    public void DrawBox(int x, int y, int w, int h, string title = "")
    {
        WriteAt(x, y, "┌" + (title.Length > 0 ? $"[ {title} ]" : "").PadRight(w - 2, '─') + "┐");
        for (int row = 1; row < h - 1; row++)
        {
            WriteAt(x, y + row, "│" + new string(' ', w - 2) + "│");
        }
        WriteAt(x, y + h - 1, "└" + new string('─', w - 2) + "┘");
    }

    public void Flush()
    {
        Console.Write(_buf.ToString());
    }
}
