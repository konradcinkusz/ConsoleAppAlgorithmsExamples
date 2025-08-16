using ConsoleAppAlgorithmsExamples.Interfaces;

namespace ConsoleAppAlgorithmsExamples.AlgorithmExercises;
internal class RouteExistOnGridTest : ITest
{
    /// <summary>
    /// T T F
    /// F T T
    /// F F T
    /// </summary>
    /// <exception cref="NotImplementedException"></exception>
    public void Execute()
    {
        Console.WriteLine("[TEST] Route Exists on Grid start");
        var routeExistOnGrid = new RouteExistOnGrid();
        var grid = new bool[,]
        {
            { true, true, false},
            { false, true, true },
            { false, false, true },
        };
        Console.WriteLine($"Route exist: {routeExistOnGrid.RouteExist(grid, (0, 0), (2, 2)) == true}");


        Console.WriteLine("[TESTEND] Route Exists on Grid end");
    }
}
