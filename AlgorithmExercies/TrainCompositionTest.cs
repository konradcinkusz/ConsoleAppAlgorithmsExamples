using ConsoleAppAlgorithmsExamples.Interfaces;

namespace ConsoleAppAlgorithmsExamples.AlgorithmExercises;

internal class TrainCompositionTest : ITest
{
    public void Execute()
    {
        var tc = new TrainComposition();
        tc.AttachLeft(7);     // [7]
        tc.AttachLeft(13);    // [13,7]
        tc.AttachRight(9);    // [13,7,9]
        Console.WriteLine(tc.DetachRight() == 9);
        Console.WriteLine(tc.DetachLeft() == 13);
        Console.WriteLine(tc.DetachLeft() == 7);
    }
}
