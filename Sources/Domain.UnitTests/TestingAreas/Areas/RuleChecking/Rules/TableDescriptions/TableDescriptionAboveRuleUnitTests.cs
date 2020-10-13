using System.Collections.Generic;
using System.Threading.Tasks;
using Mmu.WordAnalyzer2.Domain.Areas.RuleChecking.Rules.TableDescriptions;
using Mmu.WordAnalyzer2.WordAccess.Areas.Models;
using Moq;
using Xunit;

namespace Mmu.WordAnalyzer2.Domain.UnitTests.TestingAreas.Areas.RuleChecking.Rules.TableDescriptions
{
    public class TableDescriptionAboveRuleUnitTests
    {
        private readonly TableDescriptionAboveRule _sut;
        private readonly Mock<IWordDocument> _documentMock;

        public TableDescriptionAboveRuleUnitTests()
        {
            _documentMock = new Mock<IWordDocument>();
            _sut = new TableDescriptionAboveRule();
        }

        [Fact]
        public async Task CheckingRule_DescriptionBeingAbove_ReturnsPassed()
        {
            // Arrange
            var tableMock = new Mock<ITable>();

            var descMock = new Mock<IElementDescription>();
            descMock.Setup(f => f.PlainDescription).Returns("tra");
            descMock.Setup(f => f.Position).Returns(Position.Above);
            tableMock.Setup(f => f.Description).Returns(descMock.Object);

            var tables = new List<ITable>
            {
                tableMock.Object
            };

            _documentMock.Setup(f => f.Tables).Returns(tables);

            // Act
            var actualResult = await _sut.CheckRuleAsync(_documentMock.Object);

            // Assert
            Assert.True(actualResult.RulePassed);
        }

        [Fact]
        public async Task CheckingRule_DescriptionBeingBelow_ReturnsNotPassed()
        {
            // Arrange
            var tableMock = new Mock<ITable>();

            var descMock = new Mock<IElementDescription>();
            descMock.Setup(f => f.PlainDescription).Returns("tra");
            descMock.Setup(f => f.Position).Returns(Position.Below);
            tableMock.Setup(f => f.Description).Returns(descMock.Object);

            var tables = new List<ITable>
            {
                tableMock.Object
            };

            _documentMock.Setup(f => f.Tables).Returns(tables);

            // Act
            var actualResult = await _sut.CheckRuleAsync(_documentMock.Object);

            // Assert
            Assert.False(actualResult.RulePassed);
        }

        [Fact]
        public async Task CheckingRule_TableNotHavingDescription_ReturnsNotPassed()
        {
            // Arrange
            var tableMock = new Mock<ITable>();

            var descMock = new Mock<IElementDescription>();
            descMock.Setup(f => f.PlainDescription).Returns(string.Empty);
            descMock.Setup(f => f.Position).Returns(Position.None);
            tableMock.Setup(f => f.Description).Returns(descMock.Object);

            var tables = new List<ITable>
            {
                tableMock.Object
            };

            _documentMock.Setup(f => f.Tables).Returns(tables);

            // Act
            var actualResult = await _sut.CheckRuleAsync(_documentMock.Object);

            // Assert
            Assert.False(actualResult.RulePassed);
        }
    }
}