# ConsoleAppAlgorithmsExamples

This repository contains a simple .NET console application that demonstrates several fundamental algorithms and data structure exercises. Each exercise is implemented as a small class with an accompanying test class that implements the `ITest` interface. The `Program` class runs each test to showcase the algorithm behavior.

## Algorithms Included
- **Cycle Detector** – determines whether a linked list contains a cycle.
- **Route Exists on Grid (BFS)** – breadth-first search to check if a route exists between two points on a grid.
- **Route Exists on Grid (DFS)** – depth-first search variant of the grid routing problem.
- **Train Composition** – models a train where cars can be attached or detached from either end.

## Getting Started
1. Ensure you have the [.NET SDK](https://dotnet.microsoft.com/download) installed.
2. Build and run the application:

   ```bash
   dotnet run
   ```

   The output will display the result of each algorithm test.

## Project Structure
- `AlgorithmExercies/` – algorithm implementations and their associated tests.
- `Interfaces/` – shared interfaces such as `ITest`.
- `Models/` – data models, e.g., linked list `Node`.
- `Program.cs` – entry point that executes each test.

## Contributing
Contributions are welcome! If you have an algorithm example or improvement, feel free to open an issue or submit a pull request.

## License
This project is licensed under the [MIT License](LICENSE).
