using ConsoleAppAlgorithmsExamples.AlgorithmExercises;
using ConsoleAppAlgorithmsExamples.Interfaces;

namespace ConsoleAppAlgorithmsExamples
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<ITest> tests = [new CycleDetectorTest(), new RouteExistOnGridTest(), new RouteExistOnGridDFSTest()];
            tests.ForEach(t => { t.Execute(); Console.WriteLine(); });
        }
    }
}
