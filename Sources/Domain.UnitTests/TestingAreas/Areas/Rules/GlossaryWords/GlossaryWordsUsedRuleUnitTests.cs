using System.Collections.Generic;
using System.Threading.Tasks;
using Mmu.WordAnalyzer2.Domain.Areas.Rules.GlossaryWords;
using Mmu.WordAnalyzer2.WordAccess.Areas.Models;
using Moq;
using Xunit;

namespace Mmu.WordAnalyzer2.Domain.UnitTests.TestingAreas.Areas.Rules.GlossaryWords
{
    public class GlossaryWordsUsedRuleUnitTests
    {
        private readonly GlossaryWordsUsedRule _sut;
        private readonly Mock<IWordDocument> _documentMock;

        public GlossaryWordsUsedRuleUnitTests()
        {
            _documentMock = new Mock<IWordDocument>();
            _sut = new GlossaryWordsUsedRule();
        }

        [Fact]
        public async Task CheckingRuleGlossaryWordsNotUsed_ReturnsNotPassed()
        {
            // Arrange
            const string Word1 = "Word1";
            const string Word2 = "Word2";

            var glossaryTableMock = new Mock<ITable>();
            var descMock = new Mock<IElementDescription>();
            descMock.Setup(f => f.PlainDescription).Returns("Abbildung 1: Glossar");
            glossaryTableMock.Setup(f => f.Description).Returns(descMock.Object);

            var cell1 = new Mock<ICell>();
            var word1 = new Mock<IWord>();
            var chars1Mock = new Mock<ICharacters>();
            chars1Mock.Setup(f => f.Text).Returns(Word1);
            word1.Setup(f => f.Characters).Returns(chars1Mock.Object);
            cell1.Setup(f => f.ColumnIndex).Returns(1);
            cell1.Setup(f => f.RowIndex).Returns(2);
            cell1.Setup(f => f.Words).Returns(new List<IWord>
            {
                word1.Object
            });

            var cell2 = new Mock<ICell>();
            var word2 = new Mock<IWord>();
            var chars2Mock = new Mock<ICharacters>();
            chars2Mock.Setup(f => f.Text).Returns(Word2);
            word2.Setup(f => f.Characters).Returns(chars2Mock.Object);
            cell2.Setup(f => f.ColumnIndex).Returns(1);
            cell2.Setup(f => f.RowIndex).Returns(3);
            cell2.Setup(f => f.Words).Returns(new List<IWord>
            {
                word2.Object
            });

            glossaryTableMock.Setup(f => f.Cells).Returns(new List<ICell>
            {
                cell1.Object,
                cell2.Object
            });

            _documentMock.Setup(f => f.Tables).Returns(new List<ITable>
            {
                glossaryTableMock.Object
            });

            _documentMock.Setup(f => f.Words).Returns(
                new List<IWord>
                {
                    word1.Object,
                    word1.Object,
                    word2.Object
                });

            // Act
            var actualResult = await _sut.CheckRuleAsync(_documentMock.Object);

            // Assert
            Assert.False(actualResult.RulePassed);
            Assert.Equal(word2.Object.Characters.Text, actualResult.ErrorMessage);
        }

        [Fact]
        public async Task CheckingRule_AllGlossaryWordsUsed_ReturnsPassed()
        {
            // Arrange
            const string Word1 = "Word1";
            const string Word2 = "Word2";

            var glossaryTableMock = new Mock<ITable>();
            var descMock = new Mock<IElementDescription>();
            descMock.Setup(f => f.PlainDescription).Returns("Abbildung 1: Glossar");
            glossaryTableMock.Setup(f => f.Description).Returns(descMock.Object);

            var cell1 = new Mock<ICell>();
            var word1 = new Mock<IWord>();
            var chars1Mock = new Mock<ICharacters>();
            chars1Mock.Setup(f => f.Text).Returns(Word1);
            word1.Setup(f => f.Characters).Returns(chars1Mock.Object);
            cell1.Setup(f => f.ColumnIndex).Returns(1);
            cell1.Setup(f => f.RowIndex).Returns(2);
            cell1.Setup(f => f.Words).Returns(new List<IWord>
            {
                word1.Object
            });

            var cell2 = new Mock<ICell>();
            var word2 = new Mock<IWord>();
            var chars2Mock = new Mock<ICharacters>();
            chars2Mock.Setup(f => f.Text).Returns(Word2);
            word2.Setup(f => f.Characters).Returns(chars2Mock.Object);
            cell2.Setup(f => f.ColumnIndex).Returns(1);
            cell2.Setup(f => f.RowIndex).Returns(3);
            cell2.Setup(f => f.Words).Returns(new List<IWord>
            {
                word2.Object
            });

            glossaryTableMock.Setup(f => f.Cells).Returns(new List<ICell>
            {
                cell1.Object,
                cell2.Object
            });

            _documentMock.Setup(f => f.Tables).Returns(new List<ITable>
            {
                glossaryTableMock.Object
            });

            _documentMock.Setup(f => f.Words).Returns(
                new List<IWord>
                {
                    word1.Object,
                    word1.Object,
                    word2.Object,
                    word2.Object
                });

            // Act
            var actualResult = await _sut.CheckRuleAsync(_documentMock.Object);

            // Assert
            Assert.True(actualResult.RulePassed);
        }
    }
}