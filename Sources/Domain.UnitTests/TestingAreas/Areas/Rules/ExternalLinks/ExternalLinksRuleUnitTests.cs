using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Mmu.WordAnalyzer2.Domain.Areas.Rules.ExternalLinks;
using Mmu.WordAnalyzer2.WordAccess.Areas.Models;
using Moq;
using Xunit;

namespace Mmu.WordAnalyzer2.Domain.UnitTests.TestingAreas.Areas.Rules.ExternalLinks
{
    public class ExternalLinksRuleUnitTests
    {
        private ExternalLinksRule _sut;
        private readonly Mock<IWordDocument> _documentMock;

        public ExternalLinksRuleUnitTests()
        {
            _documentMock = new Mock<IWordDocument>();
            _sut = new ExternalLinksRule();    
        }

        [Fact]
        public async Task CheckingRule_AllLinksWorking_ReturnsPassed()
        {
            // Arrange
            var workingLink1 = new Mock<IExternalHyperLink>();
            workingLink1.Setup(f => f.Uri).Returns(new Uri("https://www.google.ch/"));

            var workingLink2 = new Mock<IExternalHyperLink>();
            workingLink2.Setup(f => f.Uri).Returns(new Uri("https://stackoverflow.com/"));

            var externalLinks = new List<IExternalHyperLink>()
            {
                workingLink1.Object,
                workingLink2.Object
            };

            _documentMock.Setup(f => f.ExternalHyperLinks).Returns(externalLinks);

            // Act
            var actualResult = await _sut.CheckRuleAsync(_documentMock.Object);

            // Assert
            Assert.True(actualResult.RulePassed);
        }

        [Fact]
        public async Task CheckingRule_NotAllLinksWorking_ReturnsNotPassed()
        {
            // Arrange
            var workingLink1 = new Mock<IExternalHyperLink>();
            workingLink1.Setup(f => f.Uri).Returns(new Uri("https://www.google.ch/"));

            var notWorkingLink1 = new Mock<IExternalHyperLink>();
            notWorkingLink1.Setup(f => f.Uri).Returns(new Uri("https://stackovlow.com/"));

            var notWorkingLink2 = new Mock<IExternalHyperLink>();
            notWorkingLink2.Setup(f => f.Uri).Returns(new Uri("https://stackoeewgegvlow.com/"));


            var externalLinks = new List<IExternalHyperLink>()
            {
                workingLink1.Object,
                notWorkingLink1.Object,
                notWorkingLink2.Object
            };

            _documentMock.Setup(f => f.ExternalHyperLinks).Returns(externalLinks);

            // Act
            var actualResult = await _sut.CheckRuleAsync(_documentMock.Object);

            // Assert
            Assert.False(actualResult.RulePassed);
        }
    }
}
