using System;
namespace ConsoleTetris {

    /*
     * Class containing the current state of the board.
     */

	class TetrisBoard {
		
        //int height;
		//public int Height {
        //    get {return height;} 
        //    private set {height = value;}
        //}

        public int Height {get; private set;}

		public int Width {get; private set;}

        private SquareType[,] Squares;

		public TetrisBoard(int height, int width) {
            // each square is 2x2 chars and the board
            // containg a single char wide border
			Height = height;
			Width = width;
            Squares = new SquareType[width,Height];
            InitializeEmptyBoard();
		}

        private void InitializeEmptyBoard() {
            // Set all Squares to be empty, except the border
            for (int i = 0; i < Width; ++i) {
                for (int j = 0; j < Height; ++j) {
                    if (i == 0 || j == 0 || 
                            i == Width - 1 || j == Height - 1) { // border
                        Squares[i, j] = SquareType.OUTSIDE;
                    } else {
                        Squares[i, j] = SquareType.EMPTY;
                    }
                }
            }
        }

        public SquareType GetSquare(int x, int y) {
            return Squares[x, y];
        }

	}
}
