public class AddNumbers
{
    public static void Main(String[] args)
    {
        Sum(1,1);
    }

    
    public static int Sum(int numberOne, int numberTwo)
    {
        var total = numberOne + numberTwo;
        Console.WriteLine($"The sum of two number is : {total}");
        return total;
    }
}