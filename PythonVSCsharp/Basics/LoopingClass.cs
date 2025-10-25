namespace ConsoleAppAlgorithmsExamples.PythonVSCsharp.Basics;

public class LoopingClass
{
    private int[] numbers = { 1, 2, 3 };

    public void PrintNumbers()
    {
        foreach (int number in numbers)
        {
            Console.WriteLine(number);
        }
    }
}
