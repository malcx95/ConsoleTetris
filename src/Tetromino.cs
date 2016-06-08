namespace ConsoleTetris {

    class Tetromino {

        public TetrominoType Type {get; private set;}

        private string[,] bodies = {
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

            { // S-body
            "eeeeeeee",
            "eeeeeeee",
            "eeeeSSSS",
            "eeeeSSSS",
            "eeSSSSee",
            "eeSSSSee",
            "eeeeeeee",
            "eeeeeeee"
            }

        };

        public Tetromino(TetrominoType type) {
            
        }
    
    }
}
