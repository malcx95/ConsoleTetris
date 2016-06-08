namespace ConsoleTetris {

    class Tetromino {

        private const int TETROMINO_WIDTH = 8;

        public TetrominoType Type {get; private set;}
        
        private SquareType[,] Body;

        // TODO fix compile error
        private const string[][] BODIES = {
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

        public Tetromino(TetrominoType type) {
            CreateTetromino(BODIES[(int) type]);
        }

        private void CreateTetromino(string[] stringBody) {
            for (int x = 0; x < TETROMINO_WIDTH; ++x) {
                for (int y = 0; y < TETROMINO_WIDTH; ++y) {
                    // TODO assign the Body field from stringBody
                }
            }
        }
    
    }
}
