using System.Drawing;

namespace GameOfLife
{
    internal class Program
    {
        private const int HEIGHT = 25;
        private const int WIDTH = 50;
        private const ConsoleColor BACKGROUND_COLOR = ConsoleColor.Black;
        private const ConsoleColor DEAD_COLOR = ConsoleColor.Gray;
        private const ConsoleColor ALIVE_COLOR = ConsoleColor.DarkYellow;
        private const char TO_DRAW = '█';
        public static int numberOfAlive;
        enum FieldState {Alive, Dead}
        static void Main(string[] args)
        {
            FieldState[,] grid = new FieldState[HEIGHT, WIDTH];
            GameStart(grid);
            DrawGrid(grid);
            Thread.Sleep(500);
            while (numberOfAlive > 20)
            {
                Thread.Sleep(5);
                CalculateNewGeneration(grid);
                DrawGrid(grid);
            }
        }
/// <summary>
/// Starts the grid giving each field a value of death or alive in 1 into 3
/// </summary>
/// <param name="grid">Grid to start</param>
        static void GameStart(FieldState[,] grid)
        {
            Console.WriteLine("aaaaa");
            Random r = new();
            for (int i = 0; i < HEIGHT; i++)
            {
                for (int j = 0; j < WIDTH; j++)
                {
                    grid[i, j] = r.Next(3) == 1 ? FieldState.Alive : FieldState.Dead;
                    if (grid[i, j] == FieldState.Alive) numberOfAlive++;
                }
            }
        }

/// <summary>
/// Draws the grid depending if the field is alive or dead
/// </summary>
/// <param name="grid">Grid to draw</param>
        static void DrawGrid(FieldState[,] grid)
        {
            Console.BackgroundColor = BACKGROUND_COLOR;
            for (var i = 0; i < HEIGHT; i++)
            {
                for (var j = 0; j < WIDTH; j++)
                {
                    var field = grid[i, j];
                    Console.ForegroundColor = field == FieldState.Alive ? ALIVE_COLOR : DEAD_COLOR;
                    Console.SetCursorPosition(j*2, i);
                    Console.Write(TO_DRAW);
                    Console.SetCursorPosition(j*2+1, i);
                    Console.Write(TO_DRAW);
                }
            }
        }
/// <summary>
/// Calculates the new generation based in some rules
/// </summary>
/// <param name="grid">The base grid</param>
        static void CalculateNewGeneration(FieldState[,] grid)
        {
            numberOfAlive = 0;
            var newGeneration = new FieldState[HEIGHT, WIDTH];
            for (var i = 0; i < HEIGHT; i++)
            {
                for (var j = 0; j < WIDTH; j++)
                {
                    var numOfNeig = CountNeighbors(i, j, grid);
                    if (grid[i, j] == FieldState.Alive)
                    {
                        newGeneration[i, j] = numOfNeig is 2 or 3 ? FieldState.Alive : FieldState.Dead;
                    }
                    else
                    {
                        newGeneration[i, j] = numOfNeig == 3 ? FieldState.Alive : FieldState.Dead;
                    }

                    if (newGeneration[i, j] == FieldState.Alive) numberOfAlive++;
                }
            }

            CopyGrid(newGeneration, grid);
        }
/// <summary>
/// Copy from one matix to another  
/// </summary>
/// <param name="newGeneration">Matrix to copy from</param>
/// <param name="grid">Matrix to copy to</param>
        private static void CopyGrid(FieldState[,] newGeneration, FieldState[,] grid)
        {
            for (int i = 0; i < HEIGHT; i++)
            {
                for (int j = 0; j < WIDTH; j++)
                {
                    grid[i, j] = newGeneration[i, j];
                }
            }
        }
/// <summary>
/// Counts the amount of neighbours alive
/// </summary>
/// <param name="row">row number</param>
/// <param name="column">colum number</param>
/// <param name="grid">grid to check</param>
/// <returns></returns>
        private static int CountNeighbors(int row, int column, FieldState[,] grid)
        {
            int neigh = 0;
            neigh += NeighAtPos(row - 1, column - 1,grid);
            neigh += NeighAtPos(row - 1, column,grid);
            neigh += NeighAtPos(row - 1, column + 1,grid);
            neigh += NeighAtPos(row, column - 1,grid);
            neigh += NeighAtPos(row, column + 1,grid);
            neigh += NeighAtPos(row + 1, column - 1,grid);
            neigh += NeighAtPos(row + 1, column,grid);
            neigh += NeighAtPos(row + 1, column + 1,grid);
            return neigh;
        }

        private static int NeighAtPos(int row, int column, FieldState[,] grid)
        {
            int toRet = 0;
            int tempRow = row;
            int tempColumn = column;
            if (row >= HEIGHT) tempRow = 0;
            else if (row < 0) tempRow = HEIGHT - 1;

            if (column >= WIDTH) tempColumn = 0;
            else if (column < 0) tempColumn = WIDTH - 1;

            if (grid[tempRow, tempColumn] == FieldState.Alive) toRet = 1;
            return toRet;
        }
    }
}
