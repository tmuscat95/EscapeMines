using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscapeMines.Types
{
    class Position
    {
        public int x { get; set; } = 0;
        public int y { get; set; } = 0;
        public Direction direction { get; set; } = Direction.North;
    }
}
