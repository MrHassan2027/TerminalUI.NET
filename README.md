# TerminalUI.NET

> Cross-platform TUI framework built from scratch using ANSI escape codes — no Spectre.Console dependency

## What it does
A lightweight terminal UI library that renders panels, tables, progress bars, and input prompts entirely via ANSI escape sequences. Handles keyboard input, mouse clicks (xterm), and terminal resize events. Build rich CLI dashboards without pulling in heavy third-party TUI libs.

## Quick Start
```bash
git clone https://github.com/yourusername/TerminalUI.NET
cd TerminalUI.NET
dotnet run --project TerminalUI.NET.Demo
```

```csharp
var ui = new TuiApp();
var panel = ui.AddPanel(x: 0, y: 0, width: 40, height: 10, title: "Status");
panel.AddRow("[green]Server:[/] Running");

var table = ui.AddTable(x: 0, y: 12, columns: new[] { "Name", "Value", "Status" });
table.AddRow("CPU", "12%", "[green]OK[/]");

ui.Run();
```

## Features
- Layout primitives: `Panel`, `Table`, `ProgressBar`, `InputBox`
- Markup parser: `[red]text[/]`, `[bold]text[/]`, `[bg:blue]text[/]`
- Keyboard input handling with `KeyPressed` events
- Mouse support (xterm mouse protocol)
- Terminal resize detection + re-render
- Double-buffering to prevent flicker

## Tech Stack
| Tool | Why |
|------|-----|
| C# / .NET 8 | Pure `Console` + raw ANSI writes |
| No dependencies | Single DLL, embed anywhere |

## Architecture
```
TerminalUI.NET/
├── Core/
│   ├── TuiApp.cs         # Main render loop
│   ├── Renderer.cs       # Double-buffer + ANSI writer
│   └── InputReader.cs    # Keyboard + mouse raw input
├── Widgets/
│   ├── Panel.cs
│   ├── Table.cs
│   ├── ProgressBar.cs
│   └── InputBox.cs
├── Markup/
│   └── MarkupParser.cs   # [color]...[/] tag parser
└── TerminalUI.NET.Demo/  # Live dashboard demo
```
