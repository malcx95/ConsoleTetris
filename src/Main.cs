using System;

namespace ConsoleTetris
{
	class MainClass
	{
		public static void Main (string[] args)
		{
            BoardWindow w = new BoardWindow();
            w.DrawBoard();
		}
	}
}
