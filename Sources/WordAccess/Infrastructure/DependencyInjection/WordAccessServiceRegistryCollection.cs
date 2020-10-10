using Lamar;

namespace Mmu.WordAnalyzer2.WordAccess.Infrastructure.DependencyInjection
{
    public class WordAccessServiceRegistryCollection : ServiceRegistry
    {
        public WordAccessServiceRegistryCollection()
        {
            Scan(
                scanner =>
                {
                    scanner.AssemblyContainingType<WordAccessServiceRegistryCollection>();
                    scanner.WithDefaultConventions();
                });
        }
    }
}