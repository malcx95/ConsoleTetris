using System;
using System.Threading;

namespace ConsoleTetris
{
	class MainClass
	{
        private static BoardWindow Window;

        private static Timer timer;
        private static bool Ticked;
        private static bool Rushing;

		public static void Main (string[] args)
		{
            Console.Clear();
            Console.CursorVisible = false;
            string oldTitle = Console.Title;
            Console.Title = "Fucking Tetris";
            Window = new BoardWindow();
            timer = new Timer(Tick, null, 0, 100);
            ListenToInput();
            Console.CursorVisible = true;
            Console.Clear();
            Console.Title = oldTitle;
		}

        private static void Tick(Object o) {
            if (!Rushing) {
                if (!Ticked) {
                    Window.Tick();
                }
                Window.DrawBoard();
                Ticked = !Ticked;
            }
        }

        private static void ListenToInput() {
            ConsoleKey key;
            do {
                key = Console.ReadKey().Key;
                switch(key) {
                    case ConsoleKey.UpArrow:
                        Window.Rotate(true);
                        break;
                    case ConsoleKey.DownArrow:
                        Window.Rotate(false);
                        break;
                    case ConsoleKey.LeftArrow:
                        Window.Move(true);
                        break;
                    case ConsoleKey.RightArrow:
                        Window.Move(false);
                        break;
                    case ConsoleKey.Spacebar:
                        RushDown();
                        break;
                }
            } while (key != ConsoleKey.Enter);
        }

        private static void RushDown() {
            Rushing = true;
            Window.RushDown();
            Rushing = false;
        }
	}
}
