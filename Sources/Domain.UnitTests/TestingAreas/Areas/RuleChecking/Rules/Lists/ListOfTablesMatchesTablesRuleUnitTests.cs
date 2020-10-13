using System.Collections.Generic;
using System.Threading.Tasks;
using Mmu.WordAnalyzer2.Domain.Areas.RuleChecking.Rules.Lists;
using Mmu.WordAnalyzer2.WordAccess.Areas.Models;
using Moq;
using Xunit;

namespace Mmu.WordAnalyzer2.Domain.UnitTests.TestingAreas.Areas.RuleChecking.Rules.Lists
{
    public class ListOfTablesMatchesTablesRuleUnitTests
    {
        private readonly ListOfTablesMatchesTablesRule _sut;
        private readonly Mock<IWordDocument> _documentMock;

        public ListOfTablesMatchesTablesRuleUnitTests()
        {
            _documentMock = new Mock<IWordDocument>();
            _sut = new ListOfTablesMatchesTablesRule();
        }

        [Fact]
        public async Task CheckingRule_DescriptionsNotMatching_ReturnsNotPassed()
        {
            // Arrange
            const string TableDesc1 = "Tabelle 1: Test";
            const string TableDesc2 = "Tabelle 2: Test2";

            var desc1 = new Mock<IElementDescription>();
            desc1.Setup(f => f.PlainDescription).Returns(TableDesc1);
            var table1 = new Mock<ITable>();
            table1.Setup(f => f.Description).Returns(desc1.Object);

            var desc2 = new Mock<IElementDescription>();
            desc2.Setup(f => f.PlainDescription).Returns("Tra1234");
            var table2 = new Mock<ITable>();
            table2.Setup(f => f.Description).Returns(desc2.Object);

            _documentMock.Setup(f => f.Tables).Returns(
                new List<ITable>
                {
                    table1.Object,
                    table2.Object
                });

            var entry1 = new Mock<ICharacters>();
            entry1.Setup(f => f.Text).Returns(TableDesc1);
            var entry2 = new Mock<ICharacters>();
            entry2.Setup(f => f.Text).Returns(TableDesc2);

            var figureMock = new Mock<IListOfTables>();
            figureMock.Setup(f => f.Entries).Returns(
                new List<ICharacters>
                {
                    entry1.Object,
                    entry2.Object
                });

            _documentMock.Setup(f => f.ListOfTables).Returns(figureMock.Object);

            // Act
            var actualResult = await _sut.CheckRuleAsync(_documentMock.Object);

            // Assert
            Assert.False(actualResult.RulePassed);
        }

        [Fact]
        public async Task CheckingRule_HavingLessInListThanTables_ReturnsNotPassed()
        {
            // Arrange
            const string TableDesc1 = "Tabelle 1: Test";
            const string TableDesc2 = "Tabelle 2: Test2";

            var desc1 = new Mock<IElementDescription>();
            desc1.Setup(f => f.PlainDescription).Returns(TableDesc1);
            var table1 = new Mock<ITable>();
            table1.Setup(f => f.Description).Returns(desc1.Object);

            var desc2 = new Mock<IElementDescription>();
            desc2.Setup(f => f.PlainDescription).Returns(TableDesc2);
            var table2 = new Mock<ITable>();
            table2.Setup(f => f.Description).Returns(desc2.Object);

            _documentMock.Setup(f => f.Tables).Returns(
                new List<ITable>
                {
                    table1.Object,
                    table2.Object
                });

            var entry1 = new Mock<ICharacters>();
            entry1.Setup(f => f.Text).Returns(TableDesc1);

            var figureMock = new Mock<IListOfTables>();
            figureMock.Setup(f => f.Entries).Returns(
                new List<ICharacters>
                {
                    entry1.Object
                });

            _documentMock.Setup(f => f.ListOfTables).Returns(figureMock.Object);

            // Act
            var actualResult = await _sut.CheckRuleAsync(_documentMock.Object);

            // Assert
            Assert.False(actualResult.RulePassed);
        }

        [Fact]
        public async Task CheckingRule_HavingLessTablesThanInList_ReturnsNotPassed()
        {
            // Arrange
            const string TableDesc1 = "Tabelle 1: Test";
            const string TableDesc2 = "Tabelle 2: Test2";

            var desc1 = new Mock<IElementDescription>();
            desc1.Setup(f => f.PlainDescription).Returns(TableDesc1);
            var table1 = new Mock<ITable>();
            table1.Setup(f => f.Description).Returns(desc1.Object);

            _documentMock.Setup(f => f.Tables).Returns(
                new List<ITable>
                {
                    table1.Object
                });

            var entry1 = new Mock<ICharacters>();
            entry1.Setup(f => f.Text).Returns(TableDesc1);
            var entry2 = new Mock<ICharacters>();
            entry2.Setup(f => f.Text).Returns(TableDesc2);

            var figureMock = new Mock<IListOfTables>();
            figureMock.Setup(f => f.Entries).Returns(
                new List<ICharacters>
                {
                    entry1.Object,
                    entry2.Object
                });

            _documentMock.Setup(f => f.ListOfTables).Returns(figureMock.Object);

            // Act
            var actualResult = await _sut.CheckRuleAsync(_documentMock.Object);

            // Assert
            Assert.False(actualResult.RulePassed);
        }

        [Fact]
        public async Task CheckingRule_TablesMatchingTablesList_ReturnsPassed()
        {
            // Arrange
            const string TableDesc1 = "Tabelle 1: Test";
            const string TableDesc2 = "Tabelle 2: Test2";

            var desc1 = new Mock<IElementDescription>();
            desc1.Setup(f => f.PlainDescription).Returns(TableDesc1);
            var table1 = new Mock<ITable>();
            table1.Setup(f => f.Description).Returns(desc1.Object);

            var desc2 = new Mock<IElementDescription>();
            desc2.Setup(f => f.PlainDescription).Returns(TableDesc2);
            var table2 = new Mock<ITable>();
            table2.Setup(f => f.Description).Returns(desc2.Object);

            _documentMock.Setup(f => f.Tables).Returns(
                new List<ITable>
                {
                    table1.Object,
                    table2.Object
                });

            var entry1 = new Mock<ICharacters>();
            entry1.Setup(f => f.Text).Returns(TableDesc1);
            var entry2 = new Mock<ICharacters>();
            entry2.Setup(f => f.Text).Returns(TableDesc2);

            var figureMock = new Mock<IListOfTables>();
            figureMock.Setup(f => f.Entries).Returns(
                new List<ICharacters>
                {
                    entry1.Object,
                    entry2.Object
                });

            _documentMock.Setup(f => f.ListOfTables).Returns(figureMock.Object);

            // Act
            var actualResult = await _sut.CheckRuleAsync(_documentMock.Object);

            // Assert
            Assert.True(actualResult.RulePassed);
        }
    }
}