namespace ConsoleTetris {

    /*
     * Class containing the current state of the board. Also handles
     * part of the game mechanics.
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
            FallingTetromino = null;
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

        public void SpawnTetromino() {
            FallingTetromino = new Tetromino();
            // start at the top in the center
            TetrominoX = Width / 2 - Tetromino.TETROMINO_WIDTH / 2 - 1;
            TetrominoY = -2;
        }

        public void Tick() {
            if (FallingTetromino == null) {
                SpawnTetromino();
            }
            else if (CanMoveTo(0, 1)) {
                TetrominoY += 1;
            } else {
                TransferTetrominoToBoard();
            }
        }

        private void TransferTetrominoToBoard() {
            for (int x = 0; x < Tetromino.TETROMINO_WIDTH; ++x) {
                for (int y = 0; y < Tetromino.TETROMINO_WIDTH; ++y) {
                    SquareType sq = FallingTetromino.GetSquare(x, y);
                    if (sq != SquareType.EMPTY) {
                        Squares[TetrominoX + x, TetrominoY + y] = sq;
                    }
                }
            }
            FallingTetromino = null;
        }

        private bool CanMoveTo(int dx, int dy) {
            int newY = TetrominoY + dy;
            int newX = TetrominoX + dx;
            for (int x = 0; x < Tetromino.TETROMINO_WIDTH; ++x) {
                for (int y = 0; y < Tetromino.TETROMINO_WIDTH; ++y) {
                    if (FallingTetromino.GetSquare(x, y) != SquareType.EMPTY) {
                        if (Squares[newX + x, newY + y] != SquareType.EMPTY) {
                            return false;
                        }
                    }
                }
            }
            return true;
        }

        private bool CanRotate(bool left) {
            Tetromino temp = (Tetromino) FallingTetromino.Clone();
            if (left) {
                temp.RotateLeft();
            } else {
                temp.RotateRight();
            }
            for (int x = 0; x < Tetromino.TETROMINO_WIDTH; ++x) {
                for (int y = 0; y < Tetromino.TETROMINO_WIDTH; ++y) {
                    if (temp.GetSquare(x, y) != SquareType.EMPTY) {
                        if (Squares[TetrominoX + x, TetrominoY + y] 
                                != SquareType.EMPTY) {
                            return false;
                        }
                    }
                }
            }
            return true;
        }

        public void Move(bool left) {
            if (FallingTetromino == null) return;
            if (left && CanMoveTo(-2, 0)) {
                TetrominoX -= 2;
            } else if (!left && CanMoveTo(2, 0)) {
                TetrominoX += 2;
            }
        }

        public void Rotate(bool left) {
            if (FallingTetromino == null) return;
            if (left && CanRotate(true)) {
                FallingTetromino.RotateLeft();
            } else if (!left && CanRotate(false)) {
                FallingTetromino.RotateRight();
            }
        }

        public void RushDown() {
            if (FallingTetromino == null) return;
            while (CanMoveTo(0, 2)) {
                TetrominoY += 2;
            }
        }
	}
}
