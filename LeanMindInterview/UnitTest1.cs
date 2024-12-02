using FluentAssertions;

namespace LeanMindInterview;
/*
 * "" -> ""
 *
 * "ss" -> ""
 * "**" -> ""
 * "sstt" -> ""
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
public class UnitTest1
{
    [Fact(DisplayName = "when word is empty result is empty text")]
    public void when_word_is_empty_result_is_empty_text()
    {
        var word = "";

        var result = firstNonRepeatingLetter(word);

        result.Should().Be("");
    }
    
    [Fact(DisplayName = "when word contains a non repeated result is this character")]
    public void when_word_contains_a_non_repeated_result_is_this_character()
    {
        var word = "s";

        var result = firstNonRepeatingLetter(word);

        result.Should().Be("s");
    }

    [Fact(DisplayName = "when word contains all characters repeated result is empty text")]
    public void when_word_contains_all_characters_repeated_result_is_empty_text()
    {
        var word = "ss";
    
        var result = firstNonRepeatingLetter(word);
    
        result.Should().Be("");
    }
    
    private string firstNonRepeatingLetter(string word)
    {
        if (word.Length == 0)
        {
            return "";
        }
        var charArray = word.ToCharArray();
        if (word.Length == 2 && charArray[0] == charArray[1])
        {
            return "";
        }
        return word;
    }
}