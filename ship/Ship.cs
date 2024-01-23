using battleship.enums;
using Battleship;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace battleship.ship
{
    abstract class Ship
    {
        private GridPosition startLoc;
        private Orientation orient;
        private int health;

        public GridPosition getStartLoc()
        {
            return startLoc;
        }
        protected Ship(GridPosition gp, Orientation or)
        {
            startLoc = gp;
            orient = or;
            health = getSize();
        }

        public abstract string getShipType();

        public abstract int getSize();

        public void increaseDamage()
        {
            health -= 1;
        }

        public bool isDestroyed()
        {
            if (health == 0) return true;
            else return false;
        }

        public bool atPosition(GridPosition gp)
        {
            if (getBoardSpan().Contains(gp)) return true;
            else return false;
        }

        public List<GridPosition> getBoardSpan()
        {
            List<GridPosition> result = new List<GridPosition>();
            int count = getSize();
            int newCol = startLoc.col;
            char newRow = startLoc.row;
            if (orient == Orientation.HORIZONTAL)
            {
                for (int i = 0; i < count; i++)
                {
                    result.Add(new GridPosition(newRow, newCol));
                    newCol++;
                }
            }
            if (orient == Orientation.VERTICAL)
            {
                for (int i = 0; i < count; i++)
                {
                    result.Add(new GridPosition(newRow, newCol));
                    newRow++;
                }

            }
            return result;
        }

        public Orientation getOrientation()
        {
            return orient;
        }
    }
}
