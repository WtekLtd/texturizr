namespace TexturizR;

public readonly record struct PhraseBuilder 
{
    public PhraseBuilder(string[] words, string wordSeparator)
    {
        Words = words;
        WordSeparator = wordSeparator;
        Capitalization = PhraseCapitalization.Default;
    }

    public string[] Words { get; }

    public string WordSeparator { get; init; }

    public PhraseCapitalization Capitalization { get; init; } = PhraseCapitalization.Default;

    public PhraseBuilder Capitalize(PhraseCapitalization capitalization) => this with { Capitalization = capitalization };

    public PhraseBuilder JoinWordsWith(string wordSeparator) => this with { WordSeparator = wordSeparator };

    public PhraseBuilder JoinWords() => this with { WordSeparator = string.Empty };

    public override string ToString()
    {
        var capitalization = Capitalization;
        var capitalisedWords = Words
            .Select((word, index) => CapitalizeWord(word, index, capitalization));
        return string.Join(WordSeparator, capitalisedWords);
    }

    private static string CapitalizeWord(string word, int wordIndex, PhraseCapitalization capitalization)
    {
        if (word.Length == 0) 
        {
            return word;
        }

        return (wordIndex, capitalization) switch
        {
            (0, PhraseCapitalization.FirstWord) or
            (>0, PhraseCapitalization.TrailingWords) or
            (_, PhraseCapitalization.EachWord) => char.ToUpperInvariant(word[0]) + word[1..].ToLowerInvariant(),
            
            (_, PhraseCapitalization.EachLetter) => word.ToUpperInvariant(),
            
            (_, PhraseCapitalization.Default) => word,
            
            _ => word.ToLowerInvariant(),
        };
    }
}
