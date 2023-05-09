internal class Program
{
  private static void Main(string[] args)
  {

    int[] sample1 = new int[] { 8, 3, 9, 1, 5, 7, 2 };
    int[] sample2 = new int[] { 4, 6, 2, -111, 9, 5, 3 };

    int min1 = MinV2(sample1);
    int min2 = MinV2(sample2);

    Console.WriteLine($"Min value of sample1 is {min1}");
    Console.WriteLine($"Min value of sample2 is {min2}");

  }

  public static int MinV2(params int[] numbers)
  {
    int min = int.MaxValue;

    foreach (int number in numbers)
    {
      if (number < min)
      {
        min = number;
      }
    }

    return min;
  }
}
