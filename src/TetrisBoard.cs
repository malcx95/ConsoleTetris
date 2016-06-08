namespace ConsoleTetris {

    /*
     * Class containing the current state of the board.
     */

	class TetrisBoard {

        public int Height {get; private set;}
		public int Width {get; private set;}

        public Tetromino FallingTetromino {get; private set;}
        public int TetrominoX {get; set;}
        public int TetrominoY {get; set;}

        private SquareType[,] Squares;

		public TetrisBoard(int height, int width) {
			Height = height;
			Width = width;
            Squares = new SquareType[width,Height];
            InitializeEmptyBoard();
            CreateTetromino();
		}

        private void InitializeEmptyBoard() {
            // Set all Squares to be empty, except the border
            for (int i = 0; i < Width; ++i) {
                for (int j = 0; j < Height; ++j) {
                    if (i <= 1 || i >= Width - 2 || j >= Height - 2) { // border
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

        public void CreateTetromino() {
            FallingTetromino = new Tetromino();
            // start at the top in the center
            TetrominoX = Width / 2 - Tetromino.TETROMINO_WIDTH / 2;
            TetrominoY = 0;
        }
	}
}
