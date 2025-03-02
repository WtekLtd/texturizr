namespace TexturizR.Tests;

public abstract class PhraseBuilderTests
{
    abstract protected PhraseBuilder CreateBuilder();

    [Fact]
    public void ToPascalCase()
    {
        var transformedString = CreateBuilder()
            .Capitalize(PhraseCapitalization.EachWord)
            .JoinWords()
            .ToString();
        Assert.Equal("TheQuickBrownFox", transformedString);
    }

    [Fact]
    public void ToKebabCase()
    {
        var transformedString = CreateBuilder()
            .Capitalize(PhraseCapitalization.None)
            .JoinWordsWith("-")
            .ToString();
        Assert.Equal("the-quick-brown-fox", transformedString);
    }

    [Fact]
    public void ToTrainCase()
    {
        var transformedString = CreateBuilder()
            .Capitalize(PhraseCapitalization.EachWord)
            .JoinWordsWith("-")
            .ToString();
        Assert.Equal("The-Quick-Brown-Fox", transformedString);
    }

    [Fact]
    public void ToSnakeCase()
    {
        var transformedString = CreateBuilder()
            .Capitalize(PhraseCapitalization.None)
            .JoinWordsWith("_")
            .ToString();
        Assert.Equal("the_quick_brown_fox", transformedString);
    }
}