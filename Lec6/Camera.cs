using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Lec3
{
    class Camera
    {
        public Point3D cop;
        public Point3D lookAt;
        public Point3D up;
        public double  front, back;

        public float focal = 3;


        // vectors
        public Point3D basisa, lookDir, basisc;

        public int ceneterX, ceneterY;
        public int cxScreen, cyScreen;

        public Camera()
        {
            cop = new Point3D(0, 0, -350); // new Point3D(0, -50, 0);
            lookAt = new Point3D(0, 0, 50);     //new Point3D(0, 50, 0);
            up = new Point3D(0, 1, 0);
            front = 10; // 70.0;
            back = 300.0;
        }

        public void BuildNewSystem()
        {
            lookDir = new Point3D(0, 0, 0);
            basisa = new Point3D(0, 0, 0);
            basisc = new Point3D(0, 0, 0);

            //Calculate Vector LookDir
            lookDir.x = lookAt.x - cop.x;
            lookDir.y = lookAt.y - cop.y;
            lookDir.z = lookAt.z - cop.z;
            //Normalise between 0-1
            Matrix.Normalize(ref lookDir);

            //Cross product between up and lookDir to get new vector that is perpindicular to both and normalise
            basisa = Matrix.CrossProduct(up, lookDir);
            Matrix.Normalize(ref basisa);

            //Cross product between lookDir and basisa(previous vector) to get new vector that is perpindicular to both and normalise
            basisc = Matrix.CrossProduct(lookDir, basisa);
            Matrix.Normalize(ref basisc);
        }

        public void TransformToOrigin_And_Rotate(Point3D a, Point3D e)
        {
            Point3D w = new Point3D(a.x , a.y , a.z);
            //Translate to origin
            w.x -= cop.x;
            w.y -= cop.y;
            w.z -= cop.z;

            //Calculate new point using the magic matrix created
            e.x = w.x * basisa.x + w.y * basisa.y + w.z * basisa.z;
            e.y = w.x * basisc.x + w.y * basisc.y + w.z * basisc.z;
            e.z = w.x * lookDir.x + w.y * lookDir.y + w.z * lookDir.z;            
        }
       
        public PointF TransformToOrigin_And_Rotate_And_Project(Point3D w1)
        {
            Point3D e1, n1;
            e1 = new Point3D(0, 0, 0);
            n1 = new Point3D(0, 0, 0);

            TransformToOrigin_And_Rotate(w1, e1);
            Projection.DoPrespectiveProjection(e1, n1, focal);

            // view mapping
            n1.x = (int)(ceneterX + cxScreen * n1.x / 2);
            n1.y = (int)(ceneterY - cyScreen * n1.y / 2);

            return new PointF((float)n1.x, (float)n1.y);
        }
    }
}
