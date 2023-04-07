using FluentAssertions;

namespace ConsoleApp1.Tests;

public class StringHelperTests
{
    [Theory]
    [InlineData("ala ma kota", "kota ma ala")]
    [InlineData("to jest test", "test jest to")]
    public void ReverseWords_ForValidString_ReturnsReversedSentence(string actual, string expected)
    {
        // arrange
        
        // act
        var result = StringHelper.ReverseWords(actual);

        // assert
        result.Should().Be(expected);
    }
    
    [Theory]
    [InlineData("alamakota", "alamakota")]
    public void ReverseWords_ForWordsWithoutSpace_ReturnsTheSameString(string actual, string expected)
    {
        // arrange
        
        // act
        var result = StringHelper.ReverseWords(actual);

        // assert
        result.Should().Be(expected);
    }    
    
    [Fact]
    public void ReverseWords_ForNull_ThrowsNullReferenceException()
    {
        // arrange
        
        // act
        Action result = () => StringHelper.ReverseWords(null);

        // assert
        result.Should().Throw<NullReferenceException>();
    }

    [Theory]
    [InlineData("ala")]
    [InlineData("abba")]
    [InlineData("zakaz")]
    public void IsPalindrome_ForValidString_ReturnsTrue(string word)
    {
        // arrange
        
        // act
        var result = StringHelper.IsPalindrome(word);

        // assert
        result.Should().Be(true);
    }
    
    [Theory]
    [InlineData("Ala")]
    [InlineData("Baba")]
    [InlineData("baba")]
    public void IsPalindrome_ForInvalidString_ReturnsFalse(string word)
    {
        // arrange
        
        // act
        var result = StringHelper.IsPalindrome(word);

        // assert
        result.Should().Be(false);
    }
}