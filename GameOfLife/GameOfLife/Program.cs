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
        enum FieldState {Alive, Dead}
        static void Main(string[] args)
        {
            FieldState[,] grid = new FieldState[HEIGHT, WIDTH];
            GameStart(grid);
            DrawGrid(grid);
            ConsoleKey tecla = Console.ReadKey().Key;
            while (tecla != ConsoleKey.NumPad0)
            {
                if (tecla == ConsoleKey.Spacebar)
                {
                    //CalculateNewGeneration();
                    DrawGrid(grid);
                }
                tecla = Console.ReadKey().Key;
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
            Console.Clear();
            for (var i = 0; i < HEIGHT; i++)
            {
                for (var j = 0; j < WIDTH; j++)
                {
                    var field = grid[i, j];
                    Console.ForegroundColor = field == FieldState.Alive ? ALIVE_COLOR : DEAD_COLOR;
                    Console.SetCursorPosition(j, i);
                    Console.Write(TO_DRAW);
                }
            }
        }

        static void CalculateNewGeneration()
        {
            
        }
    }
}
