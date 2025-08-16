using ConsoleAppAlgorithmsExamples.AlgorithmExercises;
using ConsoleAppAlgorithmsExamples.Interfaces;

namespace ConsoleAppAlgorithmsExamples
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<ITest> tests = [new CycleDetectorTest(), new RouteExistOnGridTest(), new RouteExistOnGridDFSTest(), new TrainCompositionTest()];
            tests.ForEach(t => {

                Console.WriteLine($"[TEST] {nameof(t)} started");
                t.Execute();
                Console.WriteLine($"[ENDTEST] {nameof(t)} started"); 
                Console.WriteLine(); 
            });
        }
    }
}
