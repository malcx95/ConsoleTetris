using System;

namespace ConsoleTetris
{
	class MainClass
	{
		public static void Main (string[] args)
		{
            Board b = new Board();
            Console.Write("Brädans höjd: ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(b.GetHeight());
            Console.Write('\n');
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Kebab");
		}
	}
}
