using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Lec3
{
    class ParametricSphere : Model3D
    {
        public void Design()
        {
            int R = 100;
            double x, y, z = 0;
            double xx;
            int iP = 0;
            // float th = 270;


            for (float th = 270; th < 270 + 180; th += 10)
            {
                x = R * Math.Cos(th * Math.PI / 180);
                y = R * Math.Sin(th * Math.PI / 180);
                AddPoint(new Point3D((float)x, (float)y, (float)z));
                if (iP > 0)
                    AddEdge(iP, iP - 1, Color.Red);
                iP++;

                for (float th2 = 0; th2 < 360; th2 += 10)
                {
                    xx = x * Math.Cos(th2 * Math.PI / 180);
                    z = x * Math.Sin(th2 * Math.PI / 180);

                    AddPoint(new Point3D((float)xx, (float)y, (float)z));
                    if (iP > 0)
                        AddEdge(iP, iP - 1, Color.Green);
                    iP++;

                }

            }
        }
    }
}
