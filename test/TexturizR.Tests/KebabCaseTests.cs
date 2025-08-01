namespace TexturizR.Tests;

public class KebabCaseTests: PhraseBuilderTests
{
    protected override PhraseBuilder CreateBuilder() => "the-quick-brown-fox".AsDelimitedPhrase("-");
}
