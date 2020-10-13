using System.Collections.Generic;
using System.Threading.Tasks;
using Mmu.WordAnalyzer2.Domain.Areas.Matching.Models;
using Mmu.WordAnalyzer2.Domain.Areas.Matching.Services;
using Mmu.WordAnalyzer2.Domain.Areas.RuleChecking;
using Mmu.WordAnalyzer2.Domain.Areas.RuleChecking.Rules.TableMatching;
using Mmu.WordAnalyzer2.WordAccess.Areas.Models;
using Moq;
using Xunit;

namespace Mmu.WordAnalyzer2.Domain.UnitTests.TestingAreas.Areas.RuleChecking.Rules.TableMatching
{
    public class PicsInPicTableRuleUnitTests
    {
        private readonly PicsInPicTableRule _sut;
        private readonly Mock<IWordDocument> _documentMock;
        private readonly Mock<IWordMatcher> _wordMatcherMock;

        public PicsInPicTableRuleUnitTests()
        {
            _documentMock = new Mock<IWordDocument>();
            _wordMatcherMock = new Mock<IWordMatcher>();
            _sut = new PicsInPicTableRule(_wordMatcherMock.Object);
        }

        [Fact]
        public async Task CheckingRule_PicsAndTablesMatching_ReturnsPassed()
        {
            // Arrange
            var matches = new List<IMatch>();
            var cells = new List<ICell>();

            var headerCellMock = new Mock<ICell>();
            headerCellMock.Setup(f => f.RowIndex).Returns(1);
            headerCellMock.Setup(f => f.ColumnIndex).Returns(1);

            cells.Add(headerCellMock.Object);

            for (var i = 1; i <= 5; i++)
            {
                var match = new Mock<IMatch>();
                match.Setup(f => f.Value).Returns($"[PIC{i}]");
                matches.Add(match.Object);

                var cell = new Mock<ICell>();
                var word = new Mock<IWord>();
                var chars = new Mock<ICharacters>();
                chars.Setup(f => f.Text).Returns($"PIC{i}");
                word.Setup(f => f.Characters).Returns(chars.Object);
                cell.Setup(f => f.Words).Returns(
                    new List<IWord>
                    {
                        word.Object
                    });

                cell.Setup(f => f.ColumnIndex).Returns(1);
                cell.Setup(f => f.RowIndex).Returns(i);

                cells.Add(cell.Object);
            }

            _wordMatcherMock.Setup(f => f.MatchWords(It.IsAny<IWordDocument>(), It.IsAny<string>())).Returns(matches);

            var table = new Mock<ITable>();
            var desc = new Mock<IElementDescription>();
            desc.Setup(f => f.PlainDescription).Returns(Constants.Tables.PicTableSuffix);
            table.Setup(f => f.Description).Returns(desc.Object);
            table.Setup(f => f.Cells).Returns(cells);

            _documentMock.Setup(f => f.Tables).Returns(
                new List<ITable>
                {
                    table.Object
                });

            // Act
            var actualResult = await _sut.CheckRuleAsync(_documentMock.Object);

            // Assert
            Assert.True(actualResult.RulePassed);
        }

        [Fact]
        public async Task CheckingRule_WithDifferentValues_ReturnsNotPassed()
        {
            // Arrange
            var matches = new List<IMatch>();
            var cells = new List<ICell>();

            var headerCellMock = new Mock<ICell>();
            headerCellMock.Setup(f => f.RowIndex).Returns(1);
            headerCellMock.Setup(f => f.ColumnIndex).Returns(1);

            cells.Add(headerCellMock.Object);

            for (var i = 1; i <= 5; i++)
            {
                var match = new Mock<IMatch>();
                match.Setup(f => f.Value).Returns($"[PIC{i * i}]");
                matches.Add(match.Object);

                var cell = new Mock<ICell>();
                var word = new Mock<IWord>();
                var chars = new Mock<ICharacters>();
                chars.Setup(f => f.Text).Returns($"PIC{i}");
                word.Setup(f => f.Characters).Returns(chars.Object);
                cell.Setup(f => f.Words).Returns(
                    new List<IWord>
                    {
                        word.Object
                    });

                cell.Setup(f => f.ColumnIndex).Returns(1);
                cell.Setup(f => f.RowIndex).Returns(i);

                cells.Add(cell.Object);
            }

            _wordMatcherMock.Setup(f => f.MatchWords(It.IsAny<IWordDocument>(), It.IsAny<string>())).Returns(matches);

            var table = new Mock<ITable>();
            var desc = new Mock<IElementDescription>();
            desc.Setup(f => f.PlainDescription).Returns(Constants.Tables.PicTableSuffix);
            table.Setup(f => f.Description).Returns(desc.Object);
            table.Setup(f => f.Cells).Returns(cells);

            _documentMock.Setup(f => f.Tables).Returns(
                new List<ITable>
                {
                    table.Object
                });

            // Act
            var actualResult = await _sut.CheckRuleAsync(_documentMock.Object);

            // Assert
            Assert.False(actualResult.RulePassed);
        }

        [Fact]
        public async Task CheckingRule_WithDifferentWordsCount_ReturnsNotPassed()
        {
            // Arrange
            var matches = new List<IMatch>();
            var cells = new List<ICell>();

            var headerCellMock = new Mock<ICell>();
            headerCellMock.Setup(f => f.RowIndex).Returns(1);
            headerCellMock.Setup(f => f.ColumnIndex).Returns(1);

            cells.Add(headerCellMock.Object);

            for (var i = 1; i <= 5; i++)
            {
                var match = new Mock<IMatch>();
                match.Setup(f => f.Value).Returns($"[PIC{i}]");
                matches.Add(match.Object);

                if (i < 5)
                {
                    var cell = new Mock<ICell>();
                    var word = new Mock<IWord>();
                    var chars = new Mock<ICharacters>();
                    chars.Setup(f => f.Text).Returns($"PIC{i}");
                    word.Setup(f => f.Characters).Returns(chars.Object);
                    cell.Setup(f => f.Words).Returns(
                        new List<IWord>
                        {
                            word.Object
                        });

                    cell.Setup(f => f.ColumnIndex).Returns(1);
                    cell.Setup(f => f.RowIndex).Returns(i);

                    cells.Add(cell.Object);
                }
            }

            _wordMatcherMock.Setup(f => f.MatchWords(It.IsAny<IWordDocument>(), It.IsAny<string>())).Returns(matches);

            var table = new Mock<ITable>();
            var desc = new Mock<IElementDescription>();
            desc.Setup(f => f.PlainDescription).Returns(Constants.Tables.PicTableSuffix);
            table.Setup(f => f.Description).Returns(desc.Object);
            table.Setup(f => f.Cells).Returns(cells);

            _documentMock.Setup(f => f.Tables).Returns(
                new List<ITable>
                {
                    table.Object
                });

            // Act
            var actualResult = await _sut.CheckRuleAsync(_documentMock.Object);

            // Assert
            Assert.False(actualResult.RulePassed);
        }
    }
}