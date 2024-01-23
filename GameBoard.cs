using battleship.enums;
using battleship.ship;
using Battleship;

namespace battleship
{
    class GameBoard
    {
        private List<Ship> shipList = new List<Ship>();
        private List<GridPosition> gpList = new List<GridPosition>();
        private List<GridPosition> hitList = new List<GridPosition>();
        private List<GridPosition> missList = new List<GridPosition>();
        private int shotsFired = 0;

        public GameBoard() { }

        public int getHitShotsSize()
        {
            return hitList.Count();
        }

        public void reset()
        {
            shipList = new List<Ship>();
            gpList = new List<GridPosition>();
            hitList = new List<GridPosition>();
            missList = new List<GridPosition>();
            shotsFired = 0;
        }

        public bool addShip(Ship ship)
        {
            //look into replacing all of this with LINQ statement
            bool add = true;
            //look into replacing with LINQ contains statement
            foreach (Ship s in shipList)
            {
                if (s.getShipType().Equals(ship.getShipType()))
                {
                    add = false;
                }
            }
            List<GridPosition> temp = ship.getBoardSpan();
            //look into replacing with LINQ statement, possibly a join
            foreach (GridPosition gp in temp)
            {
                foreach (GridPosition gp2 in gpList)
                {
                    if (gp.equals(gp2))
                    {
                        add = false;
                    }
                }
            }
            if ((ship.getOrientation() == Orientation.HORIZONTAL &&
                (ship.getStartLoc().col + ship.getSize() > 10)) ||
                (ship.getOrientation() == Orientation.VERTICAL &&
                (ship.getStartLoc().row + ship.getSize() > 'j')))
            {
                add = false;
            }
            if (add)
            {
                //look into replacing with LINQ contains statement
                foreach (GridPosition gp in temp)
                {
                    gpList.Add(gp);
                }
            }
            return add;
        }

        public int getShotsFired()
        {
            return shotsFired;
        }

        public int getShipsRemainingCount()
        {
            int result = 0;
            foreach (Ship ship in shipList)
            {
                if (!ship.isDestroyed()) result++;
            }
            return result;
        }

        public AttackResult attack(GridPosition pos)
        {
            shotsFired++;
            AttackResult result = AttackResult.NONE;
            bool found = false;
            foreach (GridPosition gp in gpList)
            {
                if (gp.equals(pos))
                {
                    result = AttackResult.HIT;
                    foreach (GridPosition gp2 in hitList)
                    {
                        if (gp2.equals(pos))
                        {
                            result = AttackResult.PREVIOUS_HIT;
                        }
                    }
                    hitList.Add(pos);
                    found = true;
                }
            }
            if (!found)
            {
                result = AttackResult.MISS;
                foreach (GridPosition gp in missList)
                {
                    if (gp.equals(pos))
                    {
                        result = AttackResult.PREVIOUS_MISS;
                    }
                }
                missList.Add(pos);
            }
            return result;
        }

        public Ship getShipAtPosition(GridPosition pos)
        {
            Ship result = null;
            foreach (Ship ship in shipList)
            {
                foreach (GridPosition gp in ship.getBoardSpan())
                {
                    if (gp.equals(pos)) result = ship;
                }
            }
            return result;
        }

        public char checkShots(GridPosition pos)
        {
            char result = '.';
            foreach (GridPosition gp in missList) if (gp.toString().Equals(pos.toString())) result = 'M';
            foreach (GridPosition gp in hitList) if (gp.toString().Equals(pos.toString())) result = 'H';
            return result;
        }
    }
}
