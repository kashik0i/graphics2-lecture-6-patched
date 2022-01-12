using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lec3
{
     static class Projection
    {
        public static List<Point2D> a;
        public static List<Point2D> Get(List<Point3D> point)
        {
            a = new List<Point2D>();
            for (int i = 0; i < point.Count; i++)
            {
                a.Add(new Point2D((float)point[i].x, (float)point[i].y));
            }
            return a;
        }
        public static List<Point2D> Prespective(ref List<Point3D> point)
        {
            a = new List<Point2D>();
            for (int i = 0; i < point.Count; i++)
            {
                float yp = (float)(point[i].y * (200 / point[i].z));
                float xp = (float)(point[i].x * (200 / point[i].z));
                a.Add(new Point2D(xp, yp));
            }
            return a;
        }
        public static void DoPrespectiveProjection(Point3D e, Point3D n, float focal)//Calculate the presepctive projection equations
        {
            n.x = focal * e.x / e.z;
            n.y = focal * e.y / e.z;
            n.z = focal;
        }

    }
}
