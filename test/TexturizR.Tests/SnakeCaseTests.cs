namespace TexturizR.Tests;

public class SnakeCaseTests: PhraseBuilderTests
{
    protected override PhraseBuilder CreateBuilder() => "the_quick_brown_fox".AsDelimitedPhrase("_");
}
