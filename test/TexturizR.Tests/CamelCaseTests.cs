namespace TexturizR.Tests;

public class CamelCaseTests: PhraseBuilderTests
{
    protected override PhraseBuilder CreateBuilder() => "the-quick-brown-fox".AsDelimitedPhrase("-");
}