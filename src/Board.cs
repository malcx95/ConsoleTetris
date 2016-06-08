using System;

namespace ConsoleTetris {

    /*
     * Class containing the current state of the board.
     */

	class Board {
		
		private int height;
		private int width;
        private SquareType[,] squares;

		public Board() {
            // each square is 2x2 chars and the board
            // containg a single char wide border
			height = Console.WindowHeight / 4 + 2;
			width = Console.WindowWidth / 4 + 2;
            squares = new SquareType[width,height];
		}

		public int GetHeight() {
			return height;
        }

		public int GetWidth() {
			return width;
		}

        private void GenerateEmptyBoard() {
            // Set all squares to be empty, except the border
            for (int i = 0; i < width; ++i) {
                for (int j = 0; j < height; ++j) {
                    if (i == 0 || j == 0) { // border
                        squares[i, j] = SquareType.OUTSIDE;
                    } else {
                        squares[i, j] = SquareType.EMPTY;
                    }
                }
            }
        }

	}
}
