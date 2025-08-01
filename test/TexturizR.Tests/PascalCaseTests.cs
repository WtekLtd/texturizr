namespace TexturizR.Tests;

public class PascalCaseTests: PhraseBuilderTests
{
    protected override PhraseBuilder CreateBuilder() => "theQuickBrownFox".AsCamelCasePhrase();
}
