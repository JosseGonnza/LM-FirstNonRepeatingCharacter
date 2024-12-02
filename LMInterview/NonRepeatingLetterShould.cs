using FluentAssertions;

namespace LMInterview;
/*
 * "" -> ""
 *
 * "ss" -> ""
 * "**" -> ""
 * "sstt" -> ""
 *
 * "s" -> "s"
 * "S" -> "S"
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
 *
 * "sTs" -> "T"
 * "stTrs" -> "r"
 * "sTreSS" -> "T"
 */
public class NonRepeatingLetterShould
{
    [Fact(DisplayName = "when word is empty result is empty text")]
    public void when_word_is_empty_result_is_empty_text()
    {
        FirstNonRepeatingLetter("").Should().Be("");
    }
    
    [Theory(DisplayName = "when word contains a non repeated result is this character")]
    [InlineData("s", "s")]
    [InlineData("*", "*")]
    [InlineData(@"\", @"\")]
    public void when_word_contains_a_non_repeated_result_is_this_character(string word, string expected)
    {
        FirstNonRepeatingLetter(word).Should().Be(expected);
    }
    
    [Theory(DisplayName = "when word contains all characters repeated result is empty text")]
    [InlineData("ss")]
    [InlineData("**")]
    [InlineData(@"\\")]
    [InlineData("sstt")]
    public void when_word_contains_all_characters_repeated_result_is_empty_text(string word)
    {
        FirstNonRepeatingLetter(word).Should().Be("");
    }
    
    [Theory(DisplayName = "when word contains a non repeated result is the first letter that non repeated")]
    [InlineData("st", "s")]
    [InlineData("*t", "*")]
    [InlineData(@"\*", @"\")]
    public void when_word_contains_a_non_repeated_result_is_the_first_letter_that_non_repeated(string word, string expected)
    {
        FirstNonRepeatingLetter(word).Should().Be(expected);
    }
    
    [Theory(DisplayName = "when word contains several repeated letters and result is the first letter that non repeated")]
    [InlineData("sts", "t")]
    [InlineData("s*s", "*")]
    [InlineData(@"\*\", @"*")]
    [InlineData("sttrs", @"r")]
    [InlineData("stt*s", @"*")]
    public void when_word_contains_several_repeated_letters_and_result_is_the_first_letter_that_non_repeated(string word, string expected)
    {
        FirstNonRepeatingLetter(word).Should().Be(expected);
    }
    
    [Theory(DisplayName = "when word contains upper and lower case and result be the correct case")]
    [InlineData("sTs", "T")]
    [InlineData("stTrs", @"r")]
    [InlineData("sTreSS", @"T")]
    public void when_word_contains_upper_and_lower_case_and_result_be_the_correct_case(string word, string expected)
    {
        FirstNonRepeatingLetter(word).Should().Be(expected);
    }
    
    private static string FirstNonRepeatingLetter(string word)
    {
        var lowerWord = word.ToLower();
        for (var i = 0; i < lowerWord.Length; i++)
        {
            var isNonRepeat = !lowerWord.Where((t, j) => i != j && lowerWord[i] == t).Any();
            if (isNonRepeat)
            {
                return word[i].ToString();
            }
        }
        return "";
    }
}