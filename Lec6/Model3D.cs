using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using System.Drawing;
namespace Lec3
{
     class Model3D
    {
        public List<Point3D> points;
        public List<Point2D> points2d;
        public List<Edge> edges;
        public int XB = 0;
        public int YB = 0;

        public Camera cam;
        public Model3D()
        {
            points = new List<Point3D>();
            points2d = new List<Point2D>();
            edges = new List<Edge>();
            //OpenFileDialog dlg = new OpenFileDialog();
            //dlg.ShowDialog();
            StreamReader sr = new StreamReader("Cube.txt");
            string strPt;
            while ((strPt = sr.ReadLine()) != null)
            {
                if (strPt[0] == 'L')
                    break;

                string[] s = strPt.Split(',');
                float[] v = new float[3];
                for (int i = 0; i < 3; i++)
                { v[i] = int.Parse(s[i]); }
                points.Add(new Point3D(v[0], v[1], v[2]));

            }
            while ((strPt = sr.ReadLine()) != null)
            {
                string[] s1 = strPt.Split(',');
                int[] indx = new int[2];
                indx[0] = int.Parse(s1[0]);
                indx[1] = int.Parse(s1[1]);
                edges.Add(new Edge(indx[0], indx[1],Color.Blue));
            }
            sr.Close();
            points2d= Projection.Get(points);

        }

        public void AddPoint(Point3D pnn)
        {
            points.Add(pnn);
        }

        public void AddEdge(int i, int j, Color cl)
        {
            Edge pnn = new Edge(i, j,cl);
            pnn.cl = cl;
            edges.Add(pnn);
        }


        public void RotateAroundArbitraryEdge(Model3D m, Edge e, double th)
        {
            Point3D p1 = new Point3D(m.points[e.i]);
            Point3D p2 = new Point3D(m.points[e.j]);
            Transform.RotateArbitrary(this, p1, p2, th);
        }
        public void Draw(Graphics g)
        {
            Font systemFont = new Font("System", 10);
            Pen pen = new Pen(Color.Black, 2);
            for (int k = 0; k < edges.Count; k++)
            {
                int i = edges[k].i;
                int j = edges[k].j;

                Point3D pi = points[i];
                Point3D pj = points[j];

                PointF pi_2D = cam.TransformToOrigin_And_Rotate_And_Project(pi);
                PointF pj_2D = cam.TransformToOrigin_And_Rotate_And_Project(pj);



                pen.Color = edges[k].cl;

                g.DrawLine(pen, pi_2D.X, pi_2D.Y, pj_2D.X, pj_2D.Y);
                g.DrawString(""+i,systemFont, Brushes.Blue, pi_2D.X + XB, pi_2D.Y + YB);
            }
            pen.Dispose();
            systemFont.Dispose();

        }
        
    }
}
