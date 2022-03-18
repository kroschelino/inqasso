using ConsoLovers.ConsoleToolkit.Core;

namespace Inqasso.Import
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleApplicationManager.For<ImportApplication>().SetWindowTitle("Inqasso Import").Run(args);
        }

    }
}
