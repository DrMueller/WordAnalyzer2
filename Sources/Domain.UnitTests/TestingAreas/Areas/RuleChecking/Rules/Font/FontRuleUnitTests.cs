using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mmu.Mlh.LanguageExtensions.Areas.Collections;
using Mmu.WordAnalyzer2.Domain.Areas.RuleChecking.Rules.Font;
using Mmu.WordAnalyzer2.WordAccess.Areas.Models;
using Moq;
using Xunit;

namespace Mmu.WordAnalyzer2.Domain.UnitTests.TestingAreas.Areas.RuleChecking.Rules.Font
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
            var charMocks = new List<Mock<ICharacter>>
            {
                new Mock<ICharacter>(),
                new Mock<ICharacter>(),
                new Mock<ICharacter>()
            };

            var consolasFontMock = new Mock<IFont>();
            consolasFontMock.Setup(f => f.Name).Returns("Consolas");

            var arialFontMock = new Mock<IFont>();
            arialFontMock.Setup(f => f.Name).Returns("Arial");

            charMocks.First().Setup(f => f.Font).Returns(arialFontMock.Object);

            charMocks.Skip(1).ForEach(
                word =>
                {
                    word.Setup(f => f.Font).Returns(consolasFontMock.Object);
                });

            var charObjects = charMocks.Select(f => f.Object).ToList();
            var chars = new Mock<ICharacters>();
            chars.Setup(f => f.Entries).Returns(charObjects);
            _documentMock.Setup(f => f.Characters).Returns(chars.Object);

            // Act
            var actualResult = await _sut.CheckRuleAsync(_documentMock.Object);

            // Assert
            Assert.False(actualResult.RulePassed);
        }

        [Fact]
        public async Task CheckingRule_WordDocumentHavingOneFont_ReturnsPassed()
        {
            // Arrange
            var charMocks = new List<Mock<ICharacter>>
            {
                new Mock<ICharacter>(),
                new Mock<ICharacter>(),
                new Mock<ICharacter>()
            };

            var fontMock = new Mock<IFont>();
            fontMock.Setup(f => f.Name).Returns("Consolas");

            charMocks.ForEach(
                word =>
                {
                    word.Setup(f => f.Font).Returns(fontMock.Object);
                });

            var charObjects = charMocks.Select(f => f.Object).ToList();
            var chars = new Mock<ICharacters>();
            chars.Setup(f => f.Entries).Returns(charObjects);
            _documentMock.Setup(f => f.Characters).Returns(chars.Object);

            // Act
            var actualResult = await _sut.CheckRuleAsync(_documentMock.Object);

            // Assert
            Assert.True(actualResult.RulePassed);
        }
    }
}