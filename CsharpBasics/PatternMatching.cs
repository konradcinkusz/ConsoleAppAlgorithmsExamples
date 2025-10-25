namespace ConsoleAppAlgorithmsExamples.CsharpBasics;

public class PatternMatching
{
    public static string Describe(object obj) => obj switch
    {
        int i => "It is an int",
        string s => "It is a string",
        null => "Nothing",
        _ => "Something else"
    };
}
