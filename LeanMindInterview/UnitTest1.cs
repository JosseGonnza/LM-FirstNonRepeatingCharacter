using FluentAssertions;

namespace LeanMindInterview;
/*
 * "" -> ""
 *
 * "s" -> "s"
 * "*" -> "*"
 * "ss" -> ""
 * "**" -> ""
 * "sstt" -> ""
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

    private string firstNonRepeatingLetter(string word)
    {
        return "";
    }
}