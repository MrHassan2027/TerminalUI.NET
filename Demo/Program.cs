using TerminalUI.NET.Core;

var app = new TuiApp();

var statusPanel = app.AddPanel(0, 0, 40, 8, "Server Status");
statusPanel.AddRow("CPU:    12%");
statusPanel.AddRow("Memory: 512 MB");
statusPanel.AddRow("Uptime: 3h 24m");

var connTable = app.AddTable(0, 10, new[] { "Session ID", "IP", "State" });
connTable.AddRow("abc-123", "192.168.1.5", "Active");
connTable.AddRow("def-456", "10.0.0.2",   "Idle");

var bar = app.AddProgressBar(0, 17, 40, "Load");
bar.Value = 0.42f;

_ = Task.Run(async () =>
{
    while (true)
    {
        await Task.Delay(500);
        bar.Value = (float)(new Random().NextDouble());
        statusPanel.Clear();
        statusPanel.AddRow($"CPU:    {new Random().Next(5, 80)}%");
        statusPanel.AddRow($"Memory: {new Random().Next(200, 900)} MB");
        statusPanel.AddRow($"Uptime: {DateTime.UtcNow:HH:mm:ss}");
    }
});

app.Run();
