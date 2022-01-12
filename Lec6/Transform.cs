using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lec3
{
    class Transform
    {
        public Transform()
        {
        }
        public static void Scale(Model3D a, double sx, double sy, double sz)//Resize the object, either bigger or smaller
        {
            for (int i = 0; i < a.points.Count; i++)
            {
                a.points[i].x *=sx;
                a.points[i].y *= sy;
                a.points[i].z *= sz;

            }
        }
        public static void Translate(Model3D a,double xr, double yr, double zr)
        {
            for (int i = 0; i < a.points.Count; i++)
            {
                a.points[i].x += xr;
                a.points[i].y += yr;
                a.points[i].z += zr;

            }
        }
        public static void RotateX(Model3D a,double theta)
        {
            //theta = (theta * Math.PI / 180.0);
            for (int i = 0; i < a.points.Count; i++)
            {
                double y1=((a.points[i].y)*Math.Cos(theta));
                double z1=((a.points[i].z)* Math.Sin(theta));

                double z2 = ((a.points[i].z) * Math.Cos(theta));
                double y2 = ((a.points[i].y) * Math.Sin(theta));
                a.points[i].y = (y1 - z1);
                a.points[i].z = (y2 + z2);
            }
        }
        public static void RotateY(Model3D a, double theta)
        {
            //theta = (theta * Math.PI / 180.0);
            for (int i = 0; i < a.points.Count; i++)
            {
                double z1 = ((a.points[i].z) * Math.Cos(theta));
                double x1 = ((a.points[i].x) * Math.Sin(theta));

                double x2 = ((a.points[i].x) * Math.Cos(theta));
                double z2 = ((a.points[i].z) * Math.Sin(theta));
                a.points[i].z = (z1 - x1);
                a.points[i].x = (x2 + z2);
            }
        }
        public static void RotateZ(Model3D a, double theta)
        {
            //theta = (theta * Math.PI / 180.0);

            for (int i = 0; i < a.points.Count; i++)
            {
                double x1 = ((a.points[i].x) * Math.Cos(theta));
                double y1 = ((a.points[i].y) * Math.Sin(theta));

                double y2 = ((a.points[i].y) * Math.Cos(theta));
                double x2 = ((a.points[i].x) * Math.Sin(theta));
                a.points[i].x = (x1 - y1);
                a.points[i].y = (x2 + y2);
            }
        }
        public static void RotateArbitrary(Model3D a, Point3D p1, Point3D p2, double ang)
        {
            double oldx = p1.x;
            double oldy = p1.y;
            double oldz = p1.z;
            Translate(a, (float)-(p1.x), (float)-(p1.y), (float)-(p1.z));

            double v1 = p1.x - p2.x;
            double v2 = p1.y - p2.y;
            double v3 = p1.z - p2.z;
            double theta = Math.Atan2(v2, v1);
            //theta = (float)(theta * Math.PI / 180.0);
            double sq = Math.Sqrt((v2 * v2) + (v1 * v1));
            double phi = Math.Atan2(sq, v3);
            //phi = (float)(phi * Math.PI / 180.0);
            RotateZ(a, -theta);
            RotateY(a, -phi);
            RotateZ(a, ang);
            RotateY(a, phi);
            RotateZ(a, theta);
            Translate(a, (float)oldx, (float)oldy, (float)oldz);
        }
    }
}
