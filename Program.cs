using System;
using System.IO;

namespace LabirintNewGameDevCourse
{
    public class Variables
    {
        public static int MapHeight = 10;
        public static int MapWight = 12;
        public static int[,] LabirintLimit = new int[MapHeight, MapWight];
        public static int PlayerPositionX = 1;
        public static int PlayerPositionY = 1;
        public static int RandomPutObject = 28;
    }
    class Program
    {
        static void Main()
        {
            GameStart();
        }
        #region GameFunctionCompilator
        static void GameStart()
        {
            Console.CursorVisible = false;
            ReDrawField();
            while (true)
            {
                DrawField();
                Movment();
            }
        }
        #endregion
        #region MapDraw
        static void DrawField()
        {
            Console.Clear();
            for (int i = 0; i < Variables.LabirintLimit.GetLength(0); i++)
            {
                for (int j = 0; j < Variables.LabirintLimit.GetLength(1); j++)
                {
                    if (Variables.LabirintLimit[i, j] > Variables.RandomPutObject) Console.Write(".");
                    if (Variables.LabirintLimit[i, j] < Variables.RandomPutObject) Console.Write("#");
                    if (Variables.LabirintLimit[i, j] == Variables.RandomPutObject) Console.Write("F");
                }
                Console.WriteLine();
            }
            PlayerPlaceDraw();
        }
        static void PlayerPlaceDraw()
        {
            Console.CursorLeft = Variables.PlayerPositionX;
            Console.CursorTop = Variables.PlayerPositionY;
            Console.Write("@");
        }
        static void ReDrawField()
        {
            Random RandomSizeOfMap = new Random();
            for (int Height = 0; Height < Variables.MapHeight; Height++)
            {
                for (int Width = 0; Width < Variables.MapWight; Width++)
                {
                    Variables.LabirintLimit[Height, Width] = RandomSizeOfMap.Next(0, 100);
                }

            }
        }
        #endregion
        #region MovmentControl
        static void Movment()
        {
            ConsoleKeyInfo KeyDown = Console.ReadKey(true);
            if (KeyDown.Key == ConsoleKey.LeftArrow && Variables.LabirintLimit[Variables.PlayerPositionY, Variables.PlayerPositionX - 1] >= Variables.RandomPutObject) Variables.PlayerPositionX--;
            if (KeyDown.Key == ConsoleKey.RightArrow && Variables.LabirintLimit[Variables.PlayerPositionY, Variables.PlayerPositionX + 1] >= Variables.RandomPutObject) Variables.PlayerPositionX++;
            if (KeyDown.Key == ConsoleKey.UpArrow && Variables.LabirintLimit[Variables.PlayerPositionY - 1, Variables.PlayerPositionX] >= Variables.RandomPutObject) Variables.PlayerPositionY--;
            if (KeyDown.Key == ConsoleKey.DownArrow && Variables.LabirintLimit[Variables.PlayerPositionY + 1, Variables.PlayerPositionX] >= Variables.RandomPutObject) Variables.PlayerPositionY++;
            if (Variables.LabirintLimit[Variables.PlayerPositionY, Variables.PlayerPositionX] == Variables.RandomPutObject)
            {
                Console.WriteLine("Win");
                KeyDown = Console.ReadKey(false);
                if (KeyDown.Key == ConsoleKey.LeftArrow && Variables.LabirintLimit[Variables.PlayerPositionY, Variables.PlayerPositionX - 1] >= Variables.RandomPutObject) Variables.PlayerPositionX += 0;
                if (KeyDown.Key == ConsoleKey.RightArrow && Variables.LabirintLimit[Variables.PlayerPositionY, Variables.PlayerPositionX + 1] >= Variables.RandomPutObject) Variables.PlayerPositionX += 0;
                if (KeyDown.Key == ConsoleKey.UpArrow && Variables.LabirintLimit[Variables.PlayerPositionY - 1, Variables.PlayerPositionX] >= Variables.RandomPutObject) Variables.PlayerPositionY += 0;
                if (KeyDown.Key == ConsoleKey.DownArrow && Variables.LabirintLimit[Variables.PlayerPositionY + 1, Variables.PlayerPositionX] >= Variables.RandomPutObject) Variables.PlayerPositionY += 0;
            }

        }

        #endregion
    }
}
