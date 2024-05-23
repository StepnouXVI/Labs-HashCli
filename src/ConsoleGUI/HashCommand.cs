
using Spectre.Console;
using Spectre.Console.Cli;
using HashServices;

namespace ConsoleGUI;

internal class HashCommand : Command<HashCommandSettings>
{
    private readonly IHashService _hashService;

    public HashCommand(IHashService hashService)
    {
        _hashService = hashService;
    }

    public override int Execute(CommandContext context, HashCommandSettings settings)
    {
        var hash = _hashService.ComputeHash(settings.Mode, settings.FilePath);

        var fullPath = Path.GetFullPath(settings.FilePath);
        var panel = new Panel($"Hash for [link][underline][yellow]{fullPath}[/][/][/] is [blue]{hash}[/]");

        panel.Header("[green][[Results]][/]");
        panel.HeaderAlignment(Justify.Center);
        panel.Expand = true;
        panel.Border = BoxBorder.Double;

        AnsiConsole.Write(panel);
        return 0;
    }
}
