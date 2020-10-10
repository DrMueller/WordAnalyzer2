using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mmu.Mlh.LanguageExtensions.Areas.Collections;
using Mmu.WordAnalyzer2.Domain.Areas.Rules.Font;
using Mmu.WordAnalyzer2.WordAccess.Areas.Models;
using Moq;
using Xunit;

namespace Mmu.WordAnalyzer2.Domain.UnitTests.TestingAreas.Areas.Rules.Font
{
    public class FontRuleUnitTests
    {
        private readonly FontRule _sut;
        private readonly Mock<IWordDocument> _documentMock;

        public FontRuleUnitTests()
        {
            _documentMock = new Mock<IWordDocument>();
            _sut = new FontRule();
        }

        [Fact]
        public async Task CheckingRule_WordDocumentHavingMultipleFonts_ReturnsNotPassed()
        {
            // Arrange
            var wordMocks = new List<Mock<IWord>>
            {
                new Mock<IWord>(),
                new Mock<IWord>(),
                new Mock<IWord>()
            };

            var consolasFontMock = new Mock<IFont>();
            consolasFontMock.Setup(f => f.Name).Returns("Consolas");

            var arialFontMock = new Mock<IFont>();
            arialFontMock.Setup(f => f.Name).Returns("Arial");

            wordMocks.First().Setup(f => f.Font).Returns(arialFontMock.Object);

            wordMocks.Skip(1).ForEach(
                word =>
                {
                    word.Setup(f => f.Font).Returns(consolasFontMock.Object);
                });

            var wordObjects = wordMocks.Select(f => f.Object).ToList();
            _documentMock.Setup(f => f.Words).Returns(wordObjects);

            // Act
            var actualResult = await _sut.CheckRuleAsync(_documentMock.Object);

            // Assert
            Assert.False(actualResult.RulePassed);
        }

        [Fact]
        public async Task CheckingRule_WordDocumentHavingOneFont_ReturnsPassed()
        {
            // Arrange
            var wordMocks = new List<Mock<IWord>>
            {
                new Mock<IWord>(),
                new Mock<IWord>(),
                new Mock<IWord>()
            };

            var fontMock = new Mock<IFont>();
            fontMock.Setup(f => f.Name).Returns("Consolas");

            wordMocks.ForEach(
                word =>
                {
                    word.Setup(f => f.Font).Returns(fontMock.Object);
                });

            var wordObjects = wordMocks.Select(f => f.Object).ToList();
            _documentMock.Setup(f => f.Words).Returns(wordObjects);

            // Act
            var actualResult = await _sut.CheckRuleAsync(_documentMock.Object);

            // Assert
            Assert.True(actualResult.RulePassed);
        }
    }
}