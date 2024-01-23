using battleship.enums;
using battleship;

namespace Battleship
{
    class GameEngine
    {
        private int turn = 0;
        private string[] ships = { "Carrier", "Battleship", "Cruiser", "Submarine", "Destroyer" };
        public void onePlayer()
        {
            bool aiFirst = true;
            Console.WriteLine("What is your name?");
            string playerName = Console.ReadLine();
            GameBoard gb1 = new GameBoard();
            //Rest to come after writing the AI
        }

        public void twoPlayer()
        {
            Console.WriteLine("Player 1, what is your name?");
            string player1Name = Console.ReadLine();
            Console.WriteLine("Player 2, what is your name?");
            string player2Name = Console.ReadLine();
            GameBoard gb1 = new GameBoard();
            GameBoard gb2 = new GameBoard();
            Console.WriteLine("Alright {0}, time to set your board. {1} go get something to drink.", player1Name, player2Name);
            buildMap(player1Name, gb1);
        }

        public void twoAI() { }

        public void buildMap(string player, GameBoard gb)
        {
            GridPosition pos = null;
            Orientation orient = Orientation.NONE;
            Console.WriteLine("Enter grid positions by first selecting the letter row, a comma, and the number column.\nExample (without quotes): 'a,1' or 'j,10'");
            foreach (string ship in ships)
            {
                bool shipAdded = false;
                bool orientationChk = false;
                while (!shipAdded)
                {
                    bool gpChk = false;
                    while (!gpChk)
                    {
                        Console.WriteLine("{0}, enter the top left corner of your {1}", player, ship);
                        string input = Console.ReadLine();
                        GridPosition gp = GridPosition.parse(input);
                        if (GridPosition.verifyGrid(gp)) pos = gp;
                    }
                }
            }
        }
    }
}
