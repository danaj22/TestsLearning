using System.Text;

namespace ConsoleApp1.Tests;

public class StringBuilderTests
{
    [Fact]
    public void Append_ForTwoStrings_ReturnsConcatenatedString()
    {
        // Arrange
        StringBuilder sb = new StringBuilder();

        // Act
        sb.Append("test").Append("test2");
        var result = sb.ToString();
        
        // Assert
        Assert.Equal("testtest2", result);
    }
}