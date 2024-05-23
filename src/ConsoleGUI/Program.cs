using ConsoleGUI;
using Spectre.Console;
using Spectre.Console.Cli;
using Microsoft.Extensions.DependencyInjection;
using HashServices;
using Domain;

var serviceCollections = new ServiceCollection();
serviceCollections.AddSingleton<IHashService>(new HashService(new Dictionary<string, I32BitHashComputer>(){
    {"crc32", new SRC32HashComputer()},
    {"sum32", new SumHashComputer()} }));

var app = new CommandApp<HashCommand>(new TypeRegistrar(serviceCollections));

app.Configure(config =>
{
    config.SetExceptionHandler((ex, resolver) =>
    {
        var panel = new Panel(ex.Message);

        panel.Header("[white][[Error]][/]");
        panel.HeaderAlignment(Justify.Center);
        panel.Expand = true;
        panel.Border = BoxBorder.Double;
        panel.BorderColor(Color.Red);

        AnsiConsole.Write(panel);
    }
    );

    config.SetApplicationName("HashCli");
    config.SetApplicationVersion("0.1.0");

// #if DEBUG
//     config.PropagateExceptions();
// #endif


});
return app.Run(args);
