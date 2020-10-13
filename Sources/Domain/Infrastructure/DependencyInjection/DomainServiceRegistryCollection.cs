using Lamar;
using Mmu.WordAnalyzer2.Domain.Areas.RuleChecking.Rules;

namespace Mmu.WordAnalyzer2.Domain.Infrastructure.DependencyInjection
{
    public class DomainServiceRegistryCollection : ServiceRegistry
    {
        public DomainServiceRegistryCollection()
        {
            Scan(
                scanner =>
                {
                    scanner.AssemblyContainingType<DomainServiceRegistryCollection>();
                    scanner.AddAllTypesOf<IRule>();
                    scanner.WithDefaultConventions();
                });
        }
    }
}