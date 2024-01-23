using battleship.enums;
using Battleship;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace battleship.ship
{
    class Carrier : Ship
    {
        public Carrier(GridPosition gp, Orientation or) : base(gp, or) { }
        public override string getShipType()
        {
            return "Carrier";
        }

        public override int getSize()
        {
            return 5;
        }
    }
}
