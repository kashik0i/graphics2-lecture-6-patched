using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lec3
{
    class Point3D
    {
        public double x, y, z;
        public Point3D(double x1, double y1, double z1)
        {
            x = x1;
            y = y1;
            z = z1;
        }
        public Point3D(Point3D p)
        {
            x = p.x;
            y = p.y;
            z = p.z;
        }
    }
}
