TexturizR
========

Flexible text transformation library for converting between different cases and structures.

# Installing TexturizR

TexturizR can be installed from nuget

    Install-Package TexturizR

or using the .NET CLR

    dotnet add package TexturizR

# Overview

TexturizR uses a fluent builder-style syntax, giving you full control over the transformation process. You can:

- Convert between various formats (camelCase, PascalCase, kebab-case, snake_case, and more).
- Control capitalization rules for each word.
- Specify custom delimiters for output formatting.

If you can imagine a text format, **TexturizR can transform it**.

# Declaring the Current Case or Structure

To begin transforming text, first declare its existing format using one of the following parsing methods:

## AsPhrase()

Declares a phrase made up of **whitespace-separated words** (e.g. "The quick brown fox").

## AsCamelCasePhrase()

Declares a phrase where capital letters indicate new words. This works for:

- camelCase (e.g. "theQuickBrownFox")
- PascalCase (e.g. "TheQuickBrownFox")

## AsDelimitedPhrase(string wordSeparator)

Declares a phrase where words are separated by a specific character.

- **kebab-case** (e.g. "the-quick-brown-fox")
- **snake_case** (e.g. "the_quick_brown_fox")
- **Custom delimiter** (e.g. "the|quick|brown|fox") 

# Transforming a Phrase

Once you have a phrase builder you can fluently chain calls to configure the transformed text.

## Capitalization Rules

Controls which letters in the output phrase will be capitalized.

### Capitalize(PhraseCapitalization capitalization)

Can be configured with one of the following values:

- **Default** - Keeps the original casing (default).

- **None** - Converts all characters to **lowercase**.

- **EachLetter** - Converts all characters to **UPPERCASE**.

- **EachWord** - Capitalizes **Each Word Like This**

- **FirstWord** - Capitalizes **Only the first letter of the first word like this**

- **TrailingWords**: Capitalizes **the First Letter Of All Words Except The First Like This**

## Word Separation

Controls how words are joined in the transformed phrase.

### JoinWordsWith(string wordSeparator)

This sets the delimiter to be used when building the transformed string:

- JoinWordsWith("-") - Converts to **kebab-case**
- JoinWordsWith("_") - Converts to **snake_case**

### JoinWords()

Alias for JoinWordsWith(String.Empty). Used for building Camel and Pascal case phrases.

## Generating the Final String

### ToString()

Call .ToString() to produce the final transformed string.

# Examples

## Convert camelCase to UPPER_SNAKE_CASE

```csharp
// Input: "theQuickBrownFox" -> Output: "THE_QUICK_BROWN_FOX".
var upperSnake = "theQuickBrownFox"
    .AsCamelCasePhrase()
    .Capitalize(PhraseCapitalization.EachLetter)
    .JoinWordsWith("_")
    .ToString();
```

## Convert kebab-case to PascalCase

```csharp
// Input: "the-quick-brown-fox" -> Output: "TheQuickBrownFox".
var pascal = "the-quick-brown-fox"
    .AsDelimitedPhrase("-")
    .Capitalize(PhraseCapitalization.EachWord)
    .JoinWords()
    .ToString();
```

# Why Use TexturizR?

- [x] **Intuitive Fluent API** - Chain methods to build transformations naturally.
- [x] **Supports Multiple Formats** - Easily switch between camelCase, PascalCase, kebab-case, snake_case, and more.
- [x] **Fully Customizable** – Define your own delimiters and capitalization rules.
- [x] **Lightweight & Fast** – Built for performance and simplicity.