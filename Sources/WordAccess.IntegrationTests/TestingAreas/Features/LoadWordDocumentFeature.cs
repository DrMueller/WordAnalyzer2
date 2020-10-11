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
        [Scenario]
        public async Task Empty_line_as_Character()
        {
            await Runner.RunScenarioAsync(
                Given_Loading_WordDocument,
                And_given_the_WordDocument_has_just_an_empty_line,
                When_the_WordDocument_is_loaded,
                Then_the_WordDocument_contains_no_Characters);
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
        public async Task Fonts_Calibri_and_Consolas()
        {
            await Runner.RunScenarioAsync(
                Given_Loading_WordDocument,
                And_given_the_WordDocument_has_the_Fonts_Calibri_and_Consolas,
                When_the_WordDocument_is_loaded,
                Then_the_WordDocument_contains_the_Fonts_Calibri_and_Consolas);
        }

        [Scenario]
        public async Task Table_Glossary()
        {
            await Runner.RunScenarioAsync(
                Given_Loading_WordDocument,
                And_given_the_WordDocument_contains_a_Glossary_Table,
                When_the_WordDocument_is_loaded,
                Then_the_WordDocument_contains_one_Table,
                Then_the_glossary_Table_contains_the_description_Glossar);
        }

        [Scenario]
        public async Task One_Shape_with_Description_below()
        {
            await Runner.RunScenarioAsync(
                Given_Loading_WordDocument,
                And_given_the_WordDocument_has_one_Shape_with_a_description,
                When_the_WordDocument_is_loaded,
                Then_the_WordDocument_contains_one_Shape,
                Then_the_Shape_has_a_description);
        }

        [Scenario]
        public async Task One_Shape_without_Description()
        {
            await Runner.RunScenarioAsync(
                Given_Loading_WordDocument,
                And_given_the_WordDocument_has_one_Shape_without_description,
                When_the_WordDocument_is_loaded,
                Then_the_WordDocument_contains_one_Shape,
                Then_the_Shape_has_no_description);
        }

        [Scenario]
        public async Task Table_NoDescription()
        {
            await Runner.RunScenarioAsync(
                Given_Loading_WordDocument,
                And_given_the_WordDocument_contains_a_Table_without_description,
                When_the_WordDocument_is_loaded,
                Then_the_WordDocument_contains_one_Table,
                Then_the_single_Table_contains_no_Description);
        }

        [Scenario]
        public async Task TwentyFour_Characters()
        {
            await Runner.RunScenarioAsync(
                Given_Loading_WordDocument,
                And_given_the_WordDocument_has_23_Characters,
                When_the_WordDocument_is_loaded,
                Then_the_WordDocument_contains_23_Characters);
        }
    }
}