using System.Collections.Generic;
using System.Threading.Tasks;
using Mmu.WordAnalyzer2.Domain.Areas.RuleChecking.Rules.ShapeDescriptions;
using Mmu.WordAnalyzer2.WordAccess.Areas.Models;
using Moq;
using Xunit;

namespace Mmu.WordAnalyzer2.Domain.UnitTests.TestingAreas.Areas.RuleChecking.Rules.ShapeDescriptions
{
    public class ShapeDescriptionSortedRuleUnitTests
    {
        private readonly ShapeDescriptionSortedRule _sut;
        private readonly Mock<IWordDocument> _documentMock;

        public ShapeDescriptionSortedRuleUnitTests()
        {
            _documentMock = new Mock<IWordDocument>();
            _sut = new ShapeDescriptionSortedRule();
        }

        [Fact]
        public async Task CheckingRule_ShapesBeingSorted_ReturnsPassed()
        {
            // Arrange
            var ele1 = new Mock<IElementDescription>();
            ele1.Setup(f => f.PlainDescription).Returns($"{ShapeDescriptionSortedRule.ShapePrefix} 1");
            var shape1 = new Mock<IShape>();
            shape1.Setup(f => f.Description).Returns(ele1.Object);

            var ele2 = new Mock<IElementDescription>();

            var ele2Description = $"{ShapeDescriptionSortedRule.ShapePrefix} 2";
            ele2.Setup(f => f.PlainDescription).Returns(ele2Description);
            var shape2 = new Mock<IShape>();
            shape2.Setup(f => f.Description).Returns(ele2.Object);

            var shapes = new List<IShape>
            {
                shape1.Object,
                shape2.Object
            };

            _documentMock.Setup(f => f.Shapes).Returns(shapes);

            // Act
            var actualResult = await _sut.CheckRuleAsync(_documentMock.Object);

            // Assert
            Assert.True(actualResult.RulePassed);
        }

        [Fact]
        public async Task CheckingRule_ShapesNotBeingSorted_ReturnsNotPassed()
        {
            // Arrange
            var ele1 = new Mock<IElementDescription>();
            ele1.Setup(f => f.PlainDescription).Returns($"{ShapeDescriptionSortedRule.ShapePrefix} 1");
            var shape1 = new Mock<IShape>();
            shape1.Setup(f => f.Description).Returns(ele1.Object);

            var ele2 = new Mock<IElementDescription>();
            var ele2Description = $"{ShapeDescriptionSortedRule.ShapePrefix} 3";
            ele2.Setup(f => f.PlainDescription).Returns(ele2Description);
            var shape2 = new Mock<IShape>();
            shape2.Setup(f => f.Description).Returns(ele2.Object);

            var shapes = new List<IShape>
            {
                shape1.Object,
                shape2.Object
            };

            _documentMock.Setup(f => f.Shapes).Returns(shapes);

            // Act
            var actualResult = await _sut.CheckRuleAsync(_documentMock.Object);

            // Assert
            Assert.False(actualResult.RulePassed);
            Assert.Equal(ele2Description, actualResult.ErrorMessage);
        }

        [Fact]
        public async Task CheckingRule_ShapesNotStartingWithPrefix_ReturnsNotPassed()
        {
            // Arrange
            const string ShapeDescription = "Tra";
            var shapeMock = new Mock<IShape>();
            var descMock = new Mock<IElementDescription>();
            descMock.Setup(f => f.PlainDescription).Returns(ShapeDescription);

            shapeMock.Setup(f => f.Description).Returns(descMock.Object);

            var shapes = new List<IShape>
            {
                shapeMock.Object
            };

            _documentMock.Setup(f => f.Shapes).Returns(shapes);

            // Act
            var actualResult = await _sut.CheckRuleAsync(_documentMock.Object);

            // Assert
            Assert.False(actualResult.RulePassed);
            Assert.Equal(ShapeDescription, actualResult.ErrorMessage);
        }
    }
}