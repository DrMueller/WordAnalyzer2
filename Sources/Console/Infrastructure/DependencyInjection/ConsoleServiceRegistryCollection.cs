using Lamar;
using Mmu.Mlh.ConsoleExtensions.Areas.Commands.Models;

namespace Mmu.WordAnalyzer2.Console.Infrastructure.DependencyInjection
{
    public class ConsoleServiceRegistryCollection : ServiceRegistry
    {
        public ConsoleServiceRegistryCollection()
        {
            Scan(
                scanner =>
                {
                    scanner.AssemblyContainingType<ConsoleServiceRegistryCollection>();
                    scanner.AddAllTypesOf<IConsoleCommand>();
                    scanner.WithDefaultConventions();
                });
        }
    }
}