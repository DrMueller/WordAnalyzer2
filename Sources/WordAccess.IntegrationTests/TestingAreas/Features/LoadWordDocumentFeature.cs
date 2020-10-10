using System.Threading.Tasks;
using LightBDD.Framework;
using LightBDD.Framework.Scenarios;
using LightBDD.XUnit2;

namespace Mmu.WordAnalyzer2.WordAccess.IntegrationTests.TestingAreas.Features
{
    [FeatureDescription(
        @"In order to use the WordDocument
as a programmer
I want to load the WordDocument")]
    public partial class LoadWordDocumentFeature
    {
        public LoadWordDocumentFeature()
        {
            
        }

        [Scenario]
        public async Task No_Words()
        {
            await Runner.RunScenarioAsync(
                Given_Loading_WordDocument,
                And_given_the_WordDocument_is_empty,
                When_the_WordDocument_is_loaded,
                Then_the_WordDocument_contains_no_Words);
        }

        [Scenario]
        public async Task Five_Words()
        {
            await Runner.RunScenarioAsync(
                Given_Loading_WordDocument,
                And_given_the_WordDocument_has_five_Words,
                When_the_WordDocument_is_loaded,
                Then_the_WordDocument_contains_five_Words);
        }

        [Scenario]
        public async Task ExternalHyperLinks()
        {
            await Runner.RunScenarioAsync(
                Given_Loading_WordDocument,
                And_given_the_WordDocument_has_HyperLinks_to_Google_and_Stackoverflow,
                When_the_WordDocument_is_loaded,
                Then_the_WordDocument_contains_HyperLinks_to_Google_and_StackOverflow);
        }

        [Scenario]
        public async Task Word_Fonts_Calibri_and_Consolas()
        {
            await Runner.RunScenarioAsync(
                Given_Loading_WordDocument,
                And_given_the_WordDocument_has_the_Fonts_Calibri_and_Consolas,
                When_the_WordDocument_is_loaded,
                Then_the_WordDocument_contains_the_Fonts_Calibri_and_Consolas);
        }
    }
}