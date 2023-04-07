using ConsoleApp1.Excercise2;
using FluentAssertions;

namespace ConsoleApp1.Tests;

public class ListHelperTests
{
    [Theory]
    [MemberData(nameof(OddNumbers))]
    public void FilterOddNumber_ForOnlyOddNumber_ReturnsAllList(List<int> numbers, List<int> expected)
    {
        var result = ListHelper.FilterOddNumber(numbers);

        result.Should().Equal(expected);
    }
    
    [Theory]
    [MemberData(nameof(NonOddNumbers))]
    public void FilterOddNumber_ForNonOddNumber_ReturnsEmptyList(List<int> numbers)
    {
        var result = ListHelper.FilterOddNumber(numbers);

        result.Should().Equal(new List<int>());
    }
    
    public static IEnumerable<object[]> OddNumbers(){
        yield return new object[] { new List<int>() { 1, 1, 3 }, new List<int>() { 1, 1, 3 }  };
        yield return new object[] { new List<int>() { 1 },  new List<int>() { 1 } };
        yield return new object[] { new List<int>() { 1, 1, 3, 111, 121 }, new List<int>() { 1, 1, 3, 111, 121 } };
    }
    
    public static IEnumerable<object[]> NonOddNumbers(){
        yield return new object[] { new List<int>() { 2, 2, 4 } };
        yield return new object[] { new List<int>() { 8 } };
        yield return new object[] { new List<int>() { 2, 2, 8, 6, 4 } };
    }
}