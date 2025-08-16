using System.Transactions;

namespace ConsoleAppAlgorithmsExamples.AlgorithmExercises;

internal class RouteExistOnGrid
{
    /// T T F
    /// F T T
    /// F F T
    public bool RouteExist(bool[,] grid, (int r, int c) start, (int r, int c) goal)
    {
        //BFS - breadth-first search
        if (grid == null) throw new ArgumentNullException(nameof(grid));

        int rows = grid.GetLength(0);
        int cols = grid.GetLength(1);

        bool InBounds(int r, int c) => r >= 0 && r < rows && c >= 0 && c < cols;
        bool Passable(int r, int c) => InBounds(r, c) && grid[r, c];

        //0. quick checks of entry parameters
        if (!Passable(start.r, start.c) || !Passable(goal.r, goal.c)) return false;
        if (start == goal) return true;

        //1. defining some variables visited + queue
        var visited = new bool[rows, cols];
        var q = new Queue<(int r, int c)>();
        visited[start.r, start.c] = true;
        q.Enqueue(start);

        //2. BFS loop
        int[] dr = { -1, 1, 0, 0 };
        int[] dc = { 0, 0, -1, 1 };

        while (q.Count > 0)
        {
            var (r, c) = q.Dequeue();

            //3. explore neighbors
            for (int k = 0; k < 4; k++)
            {
                int nr = r + dr[k], nc = c + dc[k];
                if (!InBounds(nr, nc) || visited[nr, nc] || !grid[nr, nc])
                    continue;

                if (nr == goal.r && nc == goal.c) return true; //found the solution

                visited[nr, nc] = true;
                q.Enqueue((nr, nc));
            }
        }

        //queue drained and result unreachable
        return false;
    }

    public bool RouteExistDFS(bool[,] grid, (int r, int c) start, (int r, int c) goal)
    {
        //DFS - depth-first search
        if (grid == null) throw new ArgumentNullException(nameof(grid));

        int rows = grid.GetLength(0);
        int cols = grid.GetLength(1);

        bool InBounds(int r, int c) => r >= 0 && r < rows && c >= 0 && c < cols;
        bool Passable(int r, int c) => InBounds(r, c) && grid[r, c];

        //0. quick checks of entry parameters
        if (!Passable(start.r, start.c) || !Passable(goal.r, goal.c)) return false;
        if (start == goal) return true;

        var visited = new bool[rows, cols];
        var stack = new Stack<(int r, int c)>();
        stack.Push(start);
        visited[start.r, start.c] = true;

        int[] dr = { -1, 1, 0, 0 };
        int[] dc = { 0, 0, -1, 1 };

        while (stack.Count > 0)
        {
            var (r, c) = stack.Pop();

            if ((r, c) == goal) return true; // found

            //3. explore neighbors
            for (int k = 0; k < 4; k++)
            {
                int nr = r + dr[k], nc = c + dc[k];
                if (!InBounds(nr, nc) || visited[nr, nc] || !grid[nr, nc])
                    continue;

                if (nr == goal.r && nc == goal.c) return true; //found the solution

                visited[nr, nc] = true;
                stack.Push((nr, nc));
            }
        }

        return false;
    }

}
