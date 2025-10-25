namespace ConsoleAppAlgorithmsExamples.CsharpBasics;

public class AsyncBasicExampleClass
{
    public static async Task SayHelloAsync()
    {
        await Task.Delay(1000);
        Console.WriteLine("Hello after 1 second");
    }
}
