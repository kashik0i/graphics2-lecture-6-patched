using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Lec3
{
    public partial class Form1 : Form
    {
        int XB = 0;
        int YB = 0;
        int cx = 400;
        int cy = 400;
        Bitmap offscreen;

        Camera cam = new Camera();
        _3DModel model;
        _3DModel []cubes= new _3DModel[3];
       
        
        public Form1()
        {
            //InitializeComponent();
            WindowState = FormWindowState.Maximized;
            Load+=new EventHandler(Form1_Load);
            Paint += new PaintEventHandler(Form1_Paint);
            KeyDown+=new KeyEventHandler(Form1_KeyDown);
        }
        void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:
                    cam.cop.z++;
                    break;
                case Keys.Down:
                    cam.cop.z--;
                    break;

                case Keys.Right:
                    cam.cop.x++;
                    break;
                case Keys.Left:
                    cam.cop.x--;
                    break;

                case Keys.Y:
                    cam.cop.y++;
                    break;
                case Keys.H:
                    cam.cop.y--;
                    break;
                case Keys.T:
                    Transform.RotateArbitrary(cubes[1], cubes[0].points[3], cubes[0].points[7], 1);
                    //Transform.Rotateall(cubes[2], cubes[0].points[3], cubes[0].points[7], 1);
                    //Transform.Rotateall(cubes[0], cubes[0].points[3], cubes[0].points[7], 1);
                    break;

            }
            cam.BuildNewSystem();

            DrawDoubleBuffer(this.CreateGraphics());
        }
        void Form1_Paint(object sender, PaintEventArgs e)
        {
            DrawDoubleBuffer(e.Graphics);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            offscreen = new Bitmap(Width, Height);
            model = new _3DModel();
            
            cam.ceneterX = XB + (cx / 2);
            cam.ceneterY = YB + (cy / 2);
            cam.cxScreen = cx;
            cam.cyScreen = cy;
            for (int i = 0; i < 3; i++)
            {
                cubes[i] = new _3DModel();

                Transform.Scale(cubes[i], 0.2f, 0.2f, 0.2f);

                //See text file
                Transform.Translate(cubes[i], (i * (float)(cubes[i].points[2].x - cubes[i].points[3].x)), (i * (float)(cubes[i].points[2].x - cubes[i].points[3].x)), 0);
                //Transform.Translate(cubes[i], (i * 40), (i * 40), 0);
                cubes[i].cam = cam;
            }
            model.cam = cam;
            cam.BuildNewSystem();
            DrawDoubleBuffer(CreateGraphics());
            
        }
        void DrawDoubleBuffer(Graphics g)
        {
            DrawScene(Graphics.FromImage(offscreen));
            g.DrawImage(offscreen, 0, 0);
        }
        void DrawScene(Graphics g)
        {
            g.Clear(Color.White);
            model.Draw(g);
            for (int i = 0; i < 3; i++)
            {
                cubes[i].Draw(g);
            }
        }
    }
}
