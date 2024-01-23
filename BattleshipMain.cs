using battleship.enums;
using battleship.ship;
using Battleship;
using System.Threading;

namespace battleship
{
    class BattleshipMain
    {
        static int Main(string[] args)
        {
            GridPosition gp1 = new GridPosition('a', 1);
            // Console.WriteLine(gp1.toString());
            Carrier cv = new Carrier(gp1, Orientation.VERTICAL);

            Console.WriteLine(cv.getShipType());
            List<GridPosition> temp = cv.getBoardSpan();
            foreach (GridPosition gp in temp)
            {
                Console.WriteLine(gp.toString());
            }

            //GridPosition gp1 = new GridPosition('a', 1);
            //Console.WriteLine(gp1.toString());

            //string name = Console.ReadLine();
            return 0;
        }
    }
}
