using ConsoleAppAlgorithmsExamples.Interfaces;
using ConsoleAppAlgorithmsExamples.Models;

namespace ConsoleAppAlgorithmsExamples.AlgorithmExercises;

internal class CycleDetectorTest : ITest
{
    public void Execute()
    {
        Console.WriteLine("[TEST]Start cycle detector");

        var cycleDetector = new CycleDetector();

        var a = new Node(1);
        var b = new Node(2);
        var c = new Node(3);
        var d = new Node(4);
        a.Next = b;
        b.Next = c;
        c.Next = d;
        //1->2->3->4
        bool noCycle = cycleDetector.HasCycleWithHashSet(a);
        Console.WriteLine($"No cycle detected: {noCycle == false}");
        a.Next = b;
        b.Next = c;
        c.Next = d;
        d.Next = b;
        //1->2->3->4->2->finish
        bool cycleDetected = cycleDetector.HasCycleWithHashSet(a);
        Console.WriteLine($"cycle detected: {cycleDetected == true}");

        Console.WriteLine("[ENDTEST] Cycle detector has completed");
    }
}