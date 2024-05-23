using System.ComponentModel;
using Spectre.Console;
using Spectre.Console.Cli;

namespace ConsoleGUI;
    internal sealed class HashCommandSettings: CommandSettings
    {
        private  readonly List<string> _modes = new List<string>{"crc32", "sum32"};
        
        [Description("Path to file.")]
        [CommandArgument(0, "<path>")]
        public string? FilePath { get; set; }

        [Description("Hash mode. <crc32> or <sum32>")]
        [CommandOption("-m|--mode <Mode>")]
        [DefaultValue("crc32")]
        public string Mode {get; set;}

    public override ValidationResult Validate()
    {
        if(String.IsNullOrWhiteSpace(FilePath))
        {
            return ValidationResult.Error("File path is required.");
        }

        if(!File.Exists(FilePath))
        {
            return ValidationResult.Error("File does not exist.");
        }

        if(!_modes.Contains(Mode))
        {
            return ValidationResult.Error("Mode must be crc32 or sum32.");
        }

        return ValidationResult.Success();
    }
}
