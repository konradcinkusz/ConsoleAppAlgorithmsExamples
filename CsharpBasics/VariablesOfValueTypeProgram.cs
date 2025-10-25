namespace ConsoleAppAlgorithmsExamples.CsharpBasics.var2;
class Program
{
    //Variable of a Value Type
    static void Main()
    {
        //Concept: Value types store
        //the actual data directly.
        int a = 10;
        int b = a; // copy of the value

        b = 20;
        //change b, a stays the same

        Console.WriteLine(a); // 10
        Console.WriteLine(b);  // 20
    }
}
