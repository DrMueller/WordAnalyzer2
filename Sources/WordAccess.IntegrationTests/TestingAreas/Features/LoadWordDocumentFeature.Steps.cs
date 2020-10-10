using System.IO;
using System.Linq;
using System.Threading.Tasks;
using LightBDD.XUnit2;
using Mmu.Mlh.LanguageExtensions.Areas.Assemblies.Extensions;
using Mmu.WordAnalyzer2.WordAccess.Areas.Models;
using Mmu.WordAnalyzer2.WordAccess.Areas.Repositories;
using Mmu.WordAnalyzer2.WordAccess.IntegrationTests.TestingInfrastructure.DependencyInjection;
using Xunit;

namespace Mmu.WordAnalyzer2.WordAccess.IntegrationTests.TestingAreas.Features
{
    public partial class LoadWordDocumentFeature : FeatureFixture
    {
        private IWordDocument _wordDocument;
        private string _wordDocumentName;
        private IWordDocumentRepository _wordDocumentRepo;

        private Task And_given_the_WordDocument_is_empty()
        {
            _wordDocumentName = "Empty";

            return Task.CompletedTask;
        }

        private Task And_given_the_WordDocument_has_five_Words()
        {
            _wordDocumentName = "PlainText";
            return Task.CompletedTask;
        }

        private Task Given_Loading_WordDocument()
        {
            var container = TestContainerFactory.Create();
            _wordDocumentRepo = container.GetInstance<IWordDocumentRepository>();

            return Task.CompletedTask;
        }

        private Task Then_the_WordDocument_contains_one_empty_line()
        {
            Assert.NotNull(_wordDocument.Words);
            Assert.Equal(1, _wordDocument.Words.Count);
            Assert.Equal("\r", _wordDocument.Words.Single().Text);

            return Task.CompletedTask;
        }

        private Task Then_the_WordDocument_contains_five_Words()
        {
            Assert.NotNull(_wordDocument.Words);
            Assert.Equal(5, _wordDocument.Words.Count);

            return Task.CompletedTask;
        }

        private async Task When_the_WordDocument_is_loaded()
        {
            var basePath = typeof(LoadWordDocumentFeature).Assembly.GetBasePath();

            var wordPath = Path.Combine(basePath, "TestingInfrastructure", "WordDocuments");

            var wordFilePath = Path.Combine(wordPath, _wordDocumentName);
            wordFilePath = Path.ChangeExtension(wordFilePath, ".docx");

            _wordDocument = await _wordDocumentRepo.LoadAsync(wordFilePath);
        }
    }
}