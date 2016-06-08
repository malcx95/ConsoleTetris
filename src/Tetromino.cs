using System;

namespace ConsoleTetris {

    class Tetromino {

        public const int TETROMINO_WIDTH = 8;

        public TetrominoType Type {get; private set;}
        
        private SquareType[,] Body;

        private string[][] BODIES = {
            new string[]
            { // I-body
            "eeeeeeee",
            "eeeeeeee",
            "IIIIIIII",
            "IIIIIIII",
            "eeeeeeee",
            "eeeeeeee",
            "eeeeeeee",
            "eeeeeeee"
            },

            new string[]
            { // L-body
            "eeeeeeee",
            "eeeeeeee",
            "LLLLLLee",
            "LLLLLLee",
            "LLeeeeee",
            "LLeeeeee",
            "eeeeeeee",
            "eeeeeeee"
            },

            new string[]
            { // J-body
            "eeeeeeee",
            "eeeeeeee",
            "eeJJJJJJ",
            "eeJJJJJJ",
            "eeeeeeJJ",
            "eeeeeeJJ",
            "eeeeeeee",
            "eeeeeeee"
            },

            new string[]
            { // O-body
            "eeeeeeee",
            "eeeeeeee",
            "eeOOOOee",
            "eeOOOOee",
            "eeOOOOee",
            "eeOOOOee",
            "eeeeeeee",
            "eeeeeeee"
            },

            new string[]
            { // S-body
            "eeeeeeee",
            "eeeeeeee",
            "eeeeSSSS",
            "eeeeSSSS",
            "eeSSSSee",
            "eeSSSSee",
            "eeeeeeee",
            "eeeeeeee"
            },

            new string[]
            { // T-body
            "eeeeeeee",
            "eeeeeeee",
            "eeTTTTTT",
            "eeTTTTTT",
            "eeeeTTee",
            "eeeeTTee",
            "eeeeeeee",
            "eeeeeeee"
            },

            new string[]
            { // Z-body
            "eeeeeeee",
            "eeeeeeee",
            "ZZZZeeee",
            "ZZZZeeee",
            "eeZZZZee",
            "eeZZZZee",
            "eeeeeeee",
            "eeeeeeee"
            }

        };

        public Tetromino() {
            var rnd = new Random();
            Type = (TetrominoType) rnd.Next(0, 6);
            Body = new SquareType[TETROMINO_WIDTH,TETROMINO_WIDTH];
            CreateTetromino(BODIES[(int) Type]);
        }

        private void CreateTetromino(string[] stringBody) {
            for (int y = 0; y < TETROMINO_WIDTH; ++y) {
                char[] row = stringBody[y].ToCharArray();
                for (int x = 0; x < TETROMINO_WIDTH; ++x) {
                    Body[x, y] = ToSquareType(row[x]);
                }
            }
        }

        private SquareType ToSquareType(char c) {
            switch(c) {
                case 'I':
                    return SquareType.I;
                case 'L':
                    return SquareType.L;
                case 'J':
                    return SquareType.J;
                case 'O':
                    return SquareType.O;
                case 'S':
                    return SquareType.S;
                case 'T':
                    return SquareType.T;
                case 'Z':
                    return SquareType.Z;
                default:
                    return SquareType.EMPTY;
            }
        }

        public SquareType GetSquare(int x, int y) {
            return Body[x, y];
        }

        public void RotateRight() {
            SquareType[,] result = 
                new SquareType[TETROMINO_WIDTH,TETROMINO_WIDTH];
            for (int i = 0; i < TETROMINO_WIDTH; ++i) {
                for (int j = 0; j < TETROMINO_WIDTH; ++j) {
                    result[i, j] = Body[TETROMINO_WIDTH - j - 1, i];
                }
            }
            Body = result;
        }
    
        public void RotateLeft() {
            // Deal with it.
            RotateRight();
            RotateRight();
            RotateRight();
        }
    }
}
