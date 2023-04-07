namespace ConsoleApp1.Excercise2;

public static class ListHelper
{
    public static List<int> FilterOddNumber(List<int> listOfNumbers)
    {
        List<int> result = new List<int>();

        for (int i = 0; i < listOfNumbers.Count; i++)
        {
            if (listOfNumbers[i] % 2 != 0)
            {
                result.Add(listOfNumbers[i]);
            }
        }
        return result;
    }
}