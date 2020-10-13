using System.Collections.Generic;
using System.Threading.Tasks;
using Mmu.WordAnalyzer2.Domain.Areas.RuleChecking.Rules.ShapeDescriptions;
using Mmu.WordAnalyzer2.WordAccess.Areas.Models;
using Moq;
using Xunit;

namespace Mmu.WordAnalyzer2.Domain.UnitTests.TestingAreas.Areas.RuleChecking.Rules.ShapeDescriptions
{
    public class ShapeDescriptionBelowRuleUnitTests
    {
        private readonly ShapeDescriptionBelowRule _sut;
        private readonly Mock<IWordDocument> _documentMock;

        public ShapeDescriptionBelowRuleUnitTests()
        {
            _documentMock = new Mock<IWordDocument>();
            _sut = new ShapeDescriptionBelowRule();
        }

        [Fact]
        public async Task CheckingRule_DescriptionBeingAbove_ReturnsNotPassed()
        {
            // Arrange
            var shapeMock = new Mock<IShape>();

            var descMock = new Mock<IElementDescription>();
            descMock.Setup(f => f.PlainDescription).Returns("tra");
            descMock.Setup(f => f.Position).Returns(Position.Above);
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
            Assert.Equal("tra", actualResult.ErrorMessage);
        }

        [Fact]
        public async Task CheckingRule_DescriptionBeingBelow_ReturnsPassed()
        {
            // Arrange
            var shapewithDesc = new Mock<IShape>();

            var descMock = new Mock<IElementDescription>();
            descMock.Setup(f => f.PlainDescription).Returns("tra");
            descMock.Setup(f => f.Position).Returns(Position.Below);
            shapewithDesc.Setup(f => f.Description).Returns(descMock.Object);

            var shapes = new List<IShape>
            {
                shapewithDesc.Object
            };

            _documentMock.Setup(f => f.Shapes).Returns(shapes);

            // Act
            var actualResult = await _sut.CheckRuleAsync(_documentMock.Object);

            // Assert
            Assert.True(actualResult.RulePassed);
        }

        [Fact]
        public async Task CheckingRule_ShapeNotHavingDescription_ReturnsNotPassed()
        {
            // Arrange
            var shapeMock = new Mock<IShape>();

            var descMock = new Mock<IElementDescription>();
            descMock.Setup(f => f.PlainDescription).Returns(string.Empty);
            descMock.Setup(f => f.Position).Returns(Position.None);
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
            Assert.Equal(ShapeDescriptionBelowRule.NoDescription, actualResult.ErrorMessage);
        }
    }
}