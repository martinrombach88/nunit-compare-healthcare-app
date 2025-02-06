namespace DefaultNamespace;
using Nunit;
public class Printer
{
    public static void PrintType<T>(T input)
    {
        Console.WriteLine($"Type: {typeof(T)}, Value: {input}");
    }

    public static void PlaceholderTests()
    {
        int[] array = { 1, 2, 3 };
        /* example tests, cannot be printed.
        Assert.That(array, Has.Exactly(1).EqualTo(3));
        Assert.That(array, Has.Exactly(2).GreaterThan(1));
        Assert.That(array, Has.Exactly(3).LessThan(100));
        */
        
        
    }
}
