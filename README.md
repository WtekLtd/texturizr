TexturizR
========

Simple library for transforming text from one case to another.

### Installing TexturizR.

TexturizR can be installed from nuget

    Install-Package TexturizR

or using the dotnet clr

    dotnet add package TexturizR

### Parsing a Phrase

TexturizR uses a fluent builder style syntax that allows you full control over the transformation process. This allows you to specify how the source text should be parsed, which letters of the phrase should be upper case, and what word delimiters to use for the transformed string. If you can imagine a case, you should be able to reproduce it.

To begin building a phrase, start by calling one of the following extension methods on a string...

#### AsPhrase()

Parses a phrase which uses whitespace to separate words.

#### AsCamelCasePhrase()

Parses a phrase which uses capital letters to indicate the start of a new word. Works for Camel and Pascal case strings.

#### AsDelimitedPhrase(string wordSeparator)

Parses a phrase which uses a specified string to separate words.

### Transforming a Phrase

Once you have a phrase builder you can chain calls to the following methods fluently to configure how the transformed phrase will appear.

#### Capitalize(PhraseCapitalization capitalization)

This sets which letters of the output phrase will be capitalized. This can be one of the following...

**Default**: Do not change the casing from the original string. This is the default value.

**None**: all characters in the output string will be lower case.

**EachLetter**: ALL CHARACTERS IN THE OUTPUT STRING WILL BE UPPER CASE.

**EachWord**: Each Word In The Output String Will Start With An Upper Case Letter, All Others Will Be Lower Case.

**FirstWord**: The first word in the output string will start with an upper case letter, all other letters will be lower case.

**TrailingWords**: all Words Except For The First Will Start With A Upper Case Letter. All Other Letters Will Be Lower Case.

#### JoinWordsWith(string wordSeparator)

This sets the delimiter to be used when building the transformed string.

#### JoinWords()

This is an alias for JoinWordsWith(String.Empty). Used for building Camel and Pascal case phrases.

#### ToString()

This generates the configured string.

### Examples

```csharp
// camelCase to UPPER_SNAKE_CASE
var upperSnake = "theQuickBrownFox"
    .AsCamelCasePhrase()
    .Capitalize(PhraseCapitalization.EachLetter)
    .JoinWordsWith("_")
    .ToString();

// kebab-case to PascalCase
var pascal = "the-quick-brown-fox"
    .AsDelimitedPhrase("-")
    .Capitalize(PhraseCapitalization.EachWord)
    .JoinWords()
    .ToString();
```