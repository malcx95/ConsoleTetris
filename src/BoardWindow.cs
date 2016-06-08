using System;
using System.Collections.Generic;

namespace ConsoleTetris {

    class BoardWindow {

        private Dictionary<SquareType, ConsoleColor> ColorMap;
        private Dictionary<SquareType, char> CharMap;

        private TetrisBoard Board;
        private int WindowHeight;
        private int WindowWidth;

        public BoardWindow() {
            InitializeMaps();
            WindowWidth = Console.WindowWidth;
            WindowHeight = Console.WindowHeight;
            Board = new TetrisBoard(WindowHeight / 2,
                                    WindowWidth / 2);
        }

        private void InitializeMaps() {
            ColorMap = new Dictionary<SquareType, ConsoleColor>();
            ColorMap.Add(SquareType.EMPTY, ConsoleColor.White);
            ColorMap.Add(SquareType.OUTSIDE, ConsoleColor.DarkGray);
            ColorMap.Add(SquareType.I, ConsoleColor.Cyan);
            ColorMap.Add(SquareType.L, ConsoleColor.DarkYellow);
            ColorMap.Add(SquareType.J, ConsoleColor.Blue);
            ColorMap.Add(SquareType.O, ConsoleColor.Yellow);
            ColorMap.Add(SquareType.S, ConsoleColor.Green);
            ColorMap.Add(SquareType.T, ConsoleColor.DarkMagenta);
            ColorMap.Add(SquareType.Z, ConsoleColor.Red);

            CharMap = new Dictionary<SquareType, char>();
            CharMap.Add(SquareType.EMPTY, ' ');
            CharMap.Add(SquareType.OUTSIDE, 'X');
            CharMap.Add(SquareType.I, 'I');
            CharMap.Add(SquareType.L, 'L');
            CharMap.Add(SquareType.J, 'J');
            CharMap.Add(SquareType.O, 'O');
            CharMap.Add(SquareType.S, 'S');
            CharMap.Add(SquareType.T, 'T');
            CharMap.Add(SquareType.Z, 'Z');
        }
        
        public void DrawBoard() {
            Console.Clear();
            for (int y = 0; y < Board.Height; ++y) {
                // do this twice
                for (int i = 0; i < 2; ++i) {
                    Console.Write('\n');
                    for (int x = 0; x < Board.Width; ++x) {
                        SquareType square = Board.GetSquare(x, y);
                        Console.ForegroundColor = ColorMap[square];
                        Console.Write(CharMap[square]);
                        Console.Write(CharMap[square]);
                    }
                }
            }
        }
    }
}
