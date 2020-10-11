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

        private Task And_given_the_WordDocument_contains_a_Glossary_Table()
        {
            _wordDocumentName = "Glossary";

            return Task.CompletedTask;
        }

        private Task And_given_the_WordDocument_contains_a_Table_without_description()
        {
            _wordDocumentName = "TableWithoutDescription";

            return Task.CompletedTask;
        }

        private Task And_given_the_WordDocument_has_23_Characters()
        {
            _wordDocumentName = "Plaintext";

            return Task.CompletedTask;
        }

        private Task And_given_the_WordDocument_has_HyperLinks_to_Google_and_Stackoverflow()
        {
            _wordDocumentName = "HyperLinks";

            return Task.CompletedTask;
        }

        private Task And_given_the_WordDocument_has_just_an_empty_line()
        {
            _wordDocumentName = "Empty";

            return Task.CompletedTask;
        }

        private Task And_given_the_WordDocument_has_one_Shape_with_a_description()
        {
            _wordDocumentName = "ShapeWithDescription";

            return Task.CompletedTask;
        }

        private Task And_given_the_WordDocument_has_one_Shape_without_description()
        {
            _wordDocumentName = "ShapeWithoutDescription";

            return Task.CompletedTask;
        }

        private Task And_given_the_WordDocument_has_the_Fonts_Calibri_and_Consolas()
        {
            _wordDocumentName = "TwoFonts";

            return Task.CompletedTask;
        }

        private Task Given_Loading_WordDocument()
        {
            var container = TestContainerFactory.Create();
            _wordDocumentRepo = container.GetInstance<IWordDocumentRepository>();

            return Task.CompletedTask;
        }

        private Task Then_the_glossary_Table_contains_the_description_Glossar()
        {
            var glossaryTable = _wordDocument.Tables.Single();
            Assert.EndsWith("Glossar", glossaryTable.Description.PlainDescription);

            return Task.CompletedTask;
        }

        private Task Then_the_WordDocument_contains_one_Table()
        {
            Assert.Equal(1, _wordDocument.Tables.Count);

            return Task.CompletedTask;
        }

        private Task Then_the_single_Table_contains_no_Description()
        {
            var table = _wordDocument.Tables.Single();
            Assert.Equal(string.Empty, table.Description.PlainDescription);
            Assert.Equal(Position.None, table.Description.Position);

            return Task.CompletedTask;
        }

        private Task Then_the_WordDocument_contains_23_Characters()
        {
            Assert.NotNull(_wordDocument.Characters);
            Assert.Equal(23, _wordDocument.Characters.Entries.Count);

            return Task.CompletedTask;
        }

        private Task Then_the_WordDocument_contains_HyperLinks_to_Google_and_StackOverflow()
        {
            Assert.NotNull(_wordDocument.ExternalHyperLinks);
            Assert.Equal(2, _wordDocument.ExternalHyperLinks.Count);

            Assert.Contains(_wordDocument.ExternalHyperLinks, f => f.Uri.AbsoluteUri == "https://www.google.ch/");
            Assert.Contains(_wordDocument.ExternalHyperLinks, f => f.Uri.AbsoluteUri == "https://stackoverflow.com/");

            return Task.CompletedTask;
        }

        private Task Then_the_WordDocument_contains_no_Characters()
        {
            Assert.NotNull(_wordDocument.Characters);
            Assert.Empty(_wordDocument.Characters.Entries);

            return Task.CompletedTask;
        }

        private Task Then_the_WordDocument_contains_one_Shape()
        {
            Assert.NotNull(_wordDocument.Shapes);
            Assert.Equal(1, _wordDocument.Shapes.Count);

            return Task.CompletedTask;
        }


        private Task Then_the_Shape_has_a_description()
        {
            var shape = _wordDocument.Shapes.Single();
            Assert.Equal("Abbildung 1: Test", shape.Description.PlainDescription);
            Assert.Equal(Position.Below, shape.Description.Position);

            return Task.CompletedTask;
        }

        private Task Then_the_Shape_has_no_description()
        {
            var shape = _wordDocument.Shapes.Single();
            Assert.Equal(string.Empty, shape.Description.PlainDescription);
            Assert.Equal(Position.None, shape.Description.Position);

            return Task.CompletedTask;
        }

        private Task Then_the_WordDocument_contains_the_Fonts_Calibri_and_Consolas()
        {
            var distinctFonts = _wordDocument.Characters.Entries.Select(f => f.Font.Name).Distinct().ToList();

            Assert.Equal(2, distinctFonts.Count);
            Assert.Contains(distinctFonts, f => f == "Consolas");
            Assert.Contains(distinctFonts, f => f == "Calibri");

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