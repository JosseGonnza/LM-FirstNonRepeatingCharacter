using FluentAssertions;

namespace LeanMindInterview;
/*
 * "" -> ""
 *
 * "ss" -> ""
 * "**" -> ""
 * "sstt" -> ""
 *
 * "s" -> "s"
 * "*" -> "*"
 *
 * "st" -> "s"
 * "*t" -> "*"
 *
 * "sts" -> "t"
 * "s*s" -> "*"
 *
 * "sttrs" -> "r"
 * "stt*s" -> "*"
 */
public class NonRepeatingLetterShould
{
    [Fact(DisplayName = "when word is empty result is empty text")]
    public void when_word_is_empty_result_is_empty_text()
    {
        var word = "";

        var result = FirstNonRepeatingLetter(word);

        result.Should().Be("");
    }
    
    [Theory(DisplayName = "when word contains a non repeated result is this character")]
    [InlineData("s", "s")]
    [InlineData("*", "*")]
    [InlineData(@"\", @"\")]
    public void when_word_contains_a_non_repeated_result_is_this_character(string word, string expected)
    {
        var result = FirstNonRepeatingLetter(word);

        result.Should().Be(expected);
    }

    [Theory(DisplayName = "when word contains all characters repeated result is empty text")]
    [InlineData("ss")]
    [InlineData("**")]
    [InlineData(@"\\")]
    [InlineData("sstt")]
    public void when_word_contains_all_characters_repeated_result_is_empty_text(string word)
    {
        var result = FirstNonRepeatingLetter(word);
    
        result.Should().Be("");
    }
    
    [Theory(DisplayName = "when word contains a non repeated result is the first letter that non repeated")]
    [InlineData("st", "s")]
    [InlineData("*t", "*")]
    [InlineData(@"\*", @"\")]
    public void when_word_contains_a_non_repeated_result_is_the_first_letter_that_non_repeated(string word, string expected)
    {
        var result = FirstNonRepeatingLetter(word);

        result.Should().Be(expected);
    }
    
    [Theory(DisplayName = "when word contains several repeated letters and result is the first letter that non repeated")]
    [InlineData("sts", "t")]
    [InlineData("s*s", "*")]
    [InlineData(@"\*\", @"*")]
    public void when_word_contains_several_repeated_letters_and_result_is_the_first_letter_that_non_repeated(string word, string expected)
    {
        var result = FirstNonRepeatingLetter(word);

        result.Should().Be(expected);
    }
    
    private static string FirstNonRepeatingLetter(string word)
    {
        if (word.Length == 0)
        {
            return "";
        }

        for (int i = 0; i < word.Length; i++)
        {
            var isNonRepeat = true;

            for (int j = 0; j < word.Length; j++)
            {
                if (i != j && word[i] == word[j])
                {
                    isNonRepeat = false;
                    break;
                }
            }

            if (isNonRepeat)
            {
                return word[i].ToString();
            }
        }
        return "";
    }
}