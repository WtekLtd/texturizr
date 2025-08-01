namespace TexturizR;

public static class StringExtensions
{
    public static PhraseBuilder AsPhrase(this string text)
    {
        var words = text.Split(Array.Empty<char>(), StringSplitOptions.RemoveEmptyEntries);
        return new PhraseBuilder(words, " ");
    }

    public static PhraseBuilder AsDelimitedPhrase(this string text, string wordSeparator)
    {
        var words = text.Split(wordSeparator);
        return new PhraseBuilder(words, wordSeparator);
    }

    public static PhraseBuilder AsCamelCasePhrase(this string text)
    {
        var words = new List<string>();
        var lastWordStartIndex = 0;
        for (var i = 1; i < text.Length; i++) {
            var character = text[i];
            if (character >= 'A' && character <= 'Z')
            {
                words.Add(text[lastWordStartIndex..i]);
                lastWordStartIndex = i;
            }
        }

        if (lastWordStartIndex < text.Length) 
        {
            words.Add(text[lastWordStartIndex..]);
        }

        return new PhraseBuilder([..words], string.Empty);
    }
}
