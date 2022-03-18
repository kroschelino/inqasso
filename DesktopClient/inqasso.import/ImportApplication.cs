using System.Diagnostics;
using System;
using System.Reflection;
using ConsoLovers.ConsoleToolkit.Core;
using ConsoLovers.ConsoleToolkit.Core.CommandLineArguments;

namespace Inqasso.Import
{
    internal class ImportApplication : ConsoleApplication<ImportArguments>
    {
        public ImportApplication(ICommandLineEngine commandLineEngine) : base(commandLineEngine)
        {

        }

        public override void RunWith(ImportArguments arguments)
        {
            if (arguments.Version)
            {
                var assembly = Assembly.GetExecutingAssembly();
                var versionInfo = FileVersionInfo.GetVersionInfo(assembly.Location);
                Console.WriteLine($"{versionInfo.ProductMajorPart}.{versionInfo.ProductMinorPart}.0");
            }
        }
    }

    internal class ImportArguments
    {
        [Option("Version", "v")]
        [HelpText("Shows version information")]
        public bool Version { get; set; }

        [Command("Help", "h", "?")]
        [HelpText("Displays the help you are watching at the moment.", "None")]
        public HelpCommand Help { get; set; }
    }
}


