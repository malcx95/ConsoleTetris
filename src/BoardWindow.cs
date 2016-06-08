using System;
using System.Collections.Generic;

namespace ConsoleTetris {

    /*
     * Class handling the graphical representation of 
     * the board.
     */ 

    class BoardWindow {

        private Dictionary<SquareType, ConsoleColor> ColorMap;
        private Dictionary<SquareType, char> CharMap;

        private TetrisBoard Board;
        private SquareType[,] RenderedBoard;
        private int WindowHeight;
        private int WindowWidth;

        public BoardWindow() {
            InitializeMaps();
            WindowWidth = Console.WindowWidth;
            WindowHeight = Console.WindowHeight;
            Board = new TetrisBoard(WindowHeight, WindowWidth);
            RenderedBoard = new SquareType[WindowWidth, WindowHeight];
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
            RenderBoard();
            Console.Clear();
            for (int y = 0; y < WindowHeight; ++y) {
                // do this twice
                Console.Write('\n');
                for (int x = 0; x < WindowWidth; ++x) {
                    SquareType square = RenderedBoard[x, y];
                    Console.ForegroundColor = ColorMap[square];
                    Console.Write(CharMap[square]);
                }
            }
        }

        /*
         * Renders the board by drawing the tetromino and
         * the board.
         */
        private void RenderBoard() {
            // draw the board
            for (int x = 0; x < WindowWidth; ++x) {
                for (int y = 0; y < WindowHeight; ++y) {
                    RenderedBoard[x, y] = Board.GetSquare(x, y);
                }
            }
            // put tetromino on top of it
            int tx = Board.TetrominoX;
            int ty = Board.TetrominoY;
            Tetromino t = Board.FallingTetromino;

            for (int x = 0; x < Tetromino.TETROMINO_WIDTH; ++x) {
                for (int y = 0; y < Tetromino.TETROMINO_WIDTH; ++y) {
                    RenderedBoard[x + tx, y + ty] = t.GetSquare(x, y);
                }
            }
        }
    }
}
