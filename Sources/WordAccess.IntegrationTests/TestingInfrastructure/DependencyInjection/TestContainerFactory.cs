using Lamar;

namespace Mmu.WordAnalyzer2.WordAccess.IntegrationTests.TestingInfrastructure.DependencyInjection
{
    internal static class TestContainerFactory
    {
        internal static IContainer Create()
        {
            return new Container(
                cfg =>
                {
                    cfg.Scan(
                        scanner =>
                        {
                            scanner.AssembliesFromApplicationBaseDirectory();
                            scanner.LookForRegistries();
                        });
                });
        }
    }
}