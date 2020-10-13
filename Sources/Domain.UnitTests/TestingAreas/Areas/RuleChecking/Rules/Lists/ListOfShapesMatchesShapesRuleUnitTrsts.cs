using System.Collections.Generic;
using System.Threading.Tasks;
using Mmu.WordAnalyzer2.Domain.Areas.RuleChecking.Rules.Lists;
using Mmu.WordAnalyzer2.WordAccess.Areas.Models;
using Moq;
using Xunit;

namespace Mmu.WordAnalyzer2.Domain.UnitTests.TestingAreas.Areas.RuleChecking.Rules.Lists
{
    public class ListOfShapesMatchesShapesRuleUnitTrsts
    {
        private readonly Mock<IWordDocument> _documentMock;
        private readonly ListOfShapesMatchesShapesRule _sut;

        public ListOfShapesMatchesShapesRuleUnitTrsts()
        {
            _documentMock = new Mock<IWordDocument>();
            _sut = new ListOfShapesMatchesShapesRule();
        }

        [Fact]
        public async Task CheckingRule_DescriptionsNotMaching_ReturnsNotPassed()
        {
            // Arrange
            const string FigDesc1 = "Abbildung 1: Test";
            const string FigDesc2 = "Abbildung 2: Test2";

            var desc1 = new Mock<IElementDescription>();
            desc1.Setup(f => f.PlainDescription).Returns(FigDesc1);
            var shape1 = new Mock<IShape>();
            shape1.Setup(f => f.Description).Returns(desc1.Object);

            var desc2 = new Mock<IElementDescription>();
            desc2.Setup(f => f.PlainDescription).Returns(FigDesc2);
            var shape2 = new Mock<IShape>();
            shape2.Setup(f => f.Description).Returns(desc2.Object);

            _documentMock.Setup(f => f.Shapes).Returns(
                new List<IShape>
                {
                    shape1.Object,
                    shape2.Object
                });

            var entry1 = new Mock<ICharacters>();
            entry1.Setup(f => f.Text).Returns(FigDesc1);
            var entry2 = new Mock<ICharacters>();
            entry2.Setup(f => f.Text).Returns("AnotherDesc");

            var figureMock = new Mock<IListOfShapes>();
            figureMock.Setup(f => f.Entries).Returns(
                new List<ICharacters>
                {
                    entry1.Object,
                    entry2.Object
                });

            _documentMock.Setup(f => f.ListOfShapes).Returns(figureMock.Object);

            // Act
            var actualResult = await _sut.CheckRuleAsync(_documentMock.Object);

            // Assert
            Assert.False(actualResult.RulePassed);
        }

        [Fact]
        public async Task CheckingRule_HavingLessInListThanShapes_ReturnsNotPassed()
        {
            // Arrange
            const string FigDesc1 = "Abbildung 1: Test";
            const string FigDesc2 = "Abbildung 2: Test2";

            var desc1 = new Mock<IElementDescription>();
            desc1.Setup(f => f.PlainDescription).Returns(FigDesc1);
            var shape1 = new Mock<IShape>();
            shape1.Setup(f => f.Description).Returns(desc1.Object);

            var desc2 = new Mock<IElementDescription>();
            desc2.Setup(f => f.PlainDescription).Returns(FigDesc2);
            var shape2 = new Mock<IShape>();
            shape2.Setup(f => f.Description).Returns(desc2.Object);

            _documentMock.Setup(f => f.Shapes).Returns(
                new List<IShape>
                {
                    shape1.Object,
                    shape2.Object
                });

            var entry1 = new Mock<ICharacters>();
            entry1.Setup(f => f.Text).Returns(FigDesc1);

            var figureMock = new Mock<IListOfShapes>();
            figureMock.Setup(f => f.Entries).Returns(
                new List<ICharacters>
                {
                    entry1.Object
                });

            _documentMock.Setup(f => f.ListOfShapes).Returns(figureMock.Object);

            // Act
            var actualResult = await _sut.CheckRuleAsync(_documentMock.Object);

            // Assert
            Assert.False(actualResult.RulePassed);
        }

        [Fact]
        public async Task CheckingRule_HavingLessShapesThanInList_ReturnsNotPassed()
        {
            // Arrange
            const string FigDesc1 = "Abbildung 1: Test";
            const string FigDesc2 = "Abbildung 2: Test2";

            var desc1 = new Mock<IElementDescription>();
            desc1.Setup(f => f.PlainDescription).Returns(FigDesc1);
            var shape1 = new Mock<IShape>();
            shape1.Setup(f => f.Description).Returns(desc1.Object);

            _documentMock.Setup(f => f.Shapes).Returns(
                new List<IShape>
                {
                    shape1.Object,
                });

            var entry1 = new Mock<ICharacters>();
            entry1.Setup(f => f.Text).Returns(FigDesc1);
            var entry2 = new Mock<ICharacters>();
            entry2.Setup(f => f.Text).Returns(FigDesc2);

            var figureMock = new Mock<IListOfShapes>();
            figureMock.Setup(f => f.Entries).Returns(
                new List<ICharacters>
                {
                    entry1.Object,
                    entry2.Object
                });

            _documentMock.Setup(f => f.ListOfShapes).Returns(figureMock.Object);

            // Act
            var actualResult = await _sut.CheckRuleAsync(_documentMock.Object);

            // Assert
            Assert.False(actualResult.RulePassed);
        }

        [Fact]
        public async Task CheckingRule_ShapeMatchingsList_ReturnsPassed()
        {
            // Arrange
            const string FigDesc1 = "Abbildung 1: Test";
            const string FigDesc2 = "Abbildung 2: Test2";

            var desc1 = new Mock<IElementDescription>();
            desc1.Setup(f => f.PlainDescription).Returns(FigDesc1);
            var shape1 = new Mock<IShape>();
            shape1.Setup(f => f.Description).Returns(desc1.Object);

            var desc2 = new Mock<IElementDescription>();
            desc2.Setup(f => f.PlainDescription).Returns(FigDesc2);
            var shape2 = new Mock<IShape>();
            shape2.Setup(f => f.Description).Returns(desc2.Object);

            _documentMock.Setup(f => f.Shapes).Returns(
                new List<IShape>
                {
                    shape1.Object,
                    shape2.Object
                });

            var entry1 = new Mock<ICharacters>();
            entry1.Setup(f => f.Text).Returns(FigDesc1);
            var entry2 = new Mock<ICharacters>();
            entry2.Setup(f => f.Text).Returns(FigDesc2);

            var figureMock = new Mock<IListOfShapes>();
            figureMock.Setup(f => f.Entries).Returns(
                new List<ICharacters>
                {
                    entry1.Object,
                    entry2.Object
                });

            _documentMock.Setup(f => f.ListOfShapes).Returns(figureMock.Object);

            // Act
            var actualResult = await _sut.CheckRuleAsync(_documentMock.Object);

            // Assert
            Assert.True(actualResult.RulePassed);
        }
    }
}