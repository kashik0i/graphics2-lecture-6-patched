using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Lec3
{
    class Edge
    {
        public int i, j;
        public Color cl=Color.Black;

        public Edge(int i, int j,Color cl)
        {
            this.i = i;
            this.j = j;
            this.cl = cl;
        }
    }
}
