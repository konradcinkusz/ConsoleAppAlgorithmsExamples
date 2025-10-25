using ConsoleAppAlgorithmsExamples.AlgorithmExercises;
using ConsoleAppAlgorithmsExamples.Interfaces;

namespace ConsoleAppAlgorithmsExamples
{
    public class TestFactory
    {
        public static void Run()
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
