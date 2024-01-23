using battleship.enums;
using Battleship;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace battleship.ship
{
    class Destroyer : Ship
    {
        public Destroyer(GridPosition gp, Orientation or) : base(gp, or) { }
        public override string getShipType()
        {
            return "Destroyer";
        }

        public override int getSize()
        {
            return 2;
        }
    }
}
