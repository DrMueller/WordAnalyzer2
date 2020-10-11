using System.Collections.Generic;
using System.Threading.Tasks;
using Mmu.WordAnalyzer2.Domain.Areas.Rules.TableDescriptions;
using Mmu.WordAnalyzer2.WordAccess.Areas.Models;
using Moq;
using Xunit;

namespace Mmu.WordAnalyzer2.Domain.UnitTests.TestingAreas.Areas.Rules.TableDescriptions
{
    public class TableDescriptionSortedRuleUnitTests
    {
        private readonly TableDescriptionSortedRule _sut;
        private readonly Mock<IWordDocument> _documentMock;

        public TableDescriptionSortedRuleUnitTests()
        {
            _documentMock = new Mock<IWordDocument>();
            _sut = new TableDescriptionSortedRule();
        }

        [Fact]
        public async Task CheckingRule_TableNotStartingWith1_ReturnsNotPassed()
        {
            // Arrange
            var ele1 = new Mock<IElementDescription>();

            var ele2Description = $"{TableDescriptionSortedRule.TablePrefix} 2";
            ele1.Setup(f => f.PlainDescription).Returns(ele2Description);
            var table1 = new Mock<ITable>();
            table1.Setup(f => f.Description).Returns(ele1.Object);

            var tables = new List<ITable>
            {
                table1.Object,
            };

            _documentMock.Setup(f => f.Tables).Returns(tables);

            // Act
            var actualResult = await _sut.CheckRuleAsync(_documentMock.Object);

            // Assert
            Assert.False(actualResult.RulePassed);
            Assert.Equal(ele2Description, actualResult.ErrorMessage);
        }

        [Fact]
        public async Task CheckingRule_TableNotStartingWithPrefix_ReturnsNotPassed()
        {
            // Arrange
            var tableMock = new Mock<ITable>();

            const string TableDescription = "Tra";

            var descMock = new Mock<IElementDescription>();
            descMock.Setup(f => f.PlainDescription).Returns(TableDescription);

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
            Assert.Equal(TableDescription, actualResult.ErrorMessage);
        }

        [Fact]
        public async Task CheckingRule_TablesBeingSorted_ReturnsPassed()
        {
            // Arrange
            var ele1 = new Mock<IElementDescription>();
            ele1.Setup(f => f.PlainDescription).Returns($"{TableDescriptionSortedRule.TablePrefix} 1");
            var table1 = new Mock<ITable>();
            table1.Setup(f => f.Description).Returns(ele1.Object);

            var ele2 = new Mock<IElementDescription>();

            var ele2Description = $"{TableDescriptionSortedRule.TablePrefix} 2";
            ele2.Setup(f => f.PlainDescription).Returns(ele2Description);
            var table2 = new Mock<ITable>();
            table2.Setup(f => f.Description).Returns(ele2.Object);

            var tables = new List<ITable>
            {
                table1.Object,
                table2.Object
            };

            _documentMock.Setup(f => f.Tables).Returns(tables);

            // Act
            var actualResult = await _sut.CheckRuleAsync(_documentMock.Object);

            // Assert
            Assert.True(actualResult.RulePassed);
        }

        [Fact]
        public async Task CheckingRule_TablesNotBeingSorted_ReturnsNotPassed()
        {
            // Arrange
            var ele1 = new Mock<IElementDescription>();
            ele1.Setup(f => f.PlainDescription).Returns($"{TableDescriptionSortedRule.TablePrefix} 1");
            var table1 = new Mock<ITable>();
            table1.Setup(f => f.Description).Returns(ele1.Object);

            var ele2 = new Mock<IElementDescription>();

            var ele2Description = $"{TableDescriptionSortedRule.TablePrefix} 3";
            ele2.Setup(f => f.PlainDescription).Returns(ele2Description);
            var table2 = new Mock<ITable>();
            table2.Setup(f => f.Description).Returns(ele2.Object);

            var tables = new List<ITable>
            {
                table1.Object,
                table2.Object
            };

            _documentMock.Setup(f => f.Tables).Returns(tables);

            // Act
            var actualResult = await _sut.CheckRuleAsync(_documentMock.Object);

            // Assert
            Assert.False(actualResult.RulePassed);
            Assert.Equal(ele2Description, actualResult.ErrorMessage);
        }
    }
}