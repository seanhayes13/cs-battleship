namespace Battleship
{
    class GridPosition
    {
        public readonly char row;
        public readonly int col;

        public bool equals(GridPosition gp)
        {
            //look into replacing wieht LINQ contains statement
            if (gp.row == row && gp.col == col) return true;
            else return false;
        }

        public GridPosition(char r, int c)
        {
            row = r;
            col = c;
        }

        public string toString()
        {
            return String.Format("{0}, {1}", row, col);
        }

        public GridPosition generateRandom()
        {
            System.Random rand = new System.Random();
            int c = rand.Next(10);
            char r = (char)(rand.Next(10) + 'a');
            return new GridPosition(r, c);
        }

        public static GridPosition parse(String s)
        {
            string[] temp = s.Split(',');
            return new GridPosition(temp[0].ToCharArray().ElementAt(0), Int32.Parse(temp[1]));
        }

        public static bool verifyGrid(GridPosition pos)
        {
            if (pos.col < 1 || pos.col > 10 || pos.row > 'j' || pos.row < 'a') return false;
            else return true;
        }
    }
}
