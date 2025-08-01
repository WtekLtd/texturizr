namespace TexturizR.Tests;

public class TrainCaseTests: PhraseBuilderTests
{
    protected override PhraseBuilder CreateBuilder() => "The-Quick-Brown-Fox".AsDelimitedPhrase("-");
}
