using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lec3
{
    public class Point2D
    {
        public double x, y;
        public Point2D(double x, double y)
        {
            this.x = x;
            this.y = y;
        }
        public Point2D(Point2D p)
        {
            x = p.x;
            y = p.y;
            
        }
    }
}
