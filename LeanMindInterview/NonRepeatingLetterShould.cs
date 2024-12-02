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
    
    private static string FirstNonRepeatingLetter(string word)
    {
        if (word.Length == 0)
        {
            return "";
        }
        var charArray = word.ToCharArray();
        if (word.Length != 1)
        {
            for (int i = 0; i < charArray.Length; i++)
            {
                if (charArray[i] == charArray[i + 1])
                {
                    return "";
                }
            }
        }
        return word;
    }
}