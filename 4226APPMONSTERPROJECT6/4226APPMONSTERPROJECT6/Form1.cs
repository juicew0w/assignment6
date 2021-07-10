using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _4226APPMONSTERPROJECT6
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();


            InitializeComponent();
            this.Width = 900;
            this.Height = 700;
            bm = new Bitmap(pic.Width, pic.Height);
            g = Graphics.FromImage(bm);
            g.Clear(Color.White);
            pic.Image = bm;

        }


        Bitmap bm;
        Graphics g;
        bool paint = false;
        Point px, py;
        Pen p = new Pen(Color.Black, 1);
        Pen erase = new Pen(Color.White, 10);
        int x, y, sX, sY, cX, cY;
        ColorDialog cd = new ColorDialog();
        Color new_color;

        private void button5_Click(object sender, EventArgs e)
        {
            index = 3;

        }

        private void button6_Click(object sender, EventArgs e)
        {
            index = 4;

        }

        private void button7_Click(object sender, EventArgs e)
        {
            index = 5;

        }

        private void pic_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            if (paint) {
                if (index == 3)
                {
                    g.DrawEllipse(p, cX, cY, sX, sY);

                }
                if (index == 4)
                {
                    g.DrawRectangle(p, cX, cY, sX, sY);

                }
                if (index == 5)
                {
                    g.DrawLine(p, cX, cY, sX, sY);

                }
            }
            
        }

        private void button11_Click(object sender, EventArgs e)
        {
            g.Clear(Color.White);
            pic.Image = bm;
            index = 0;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            cd.ShowDialog();
            new_color = cd.Color;
            button1.BackColor = cd.Color;
            p.Color = cd.Color;


        }

        private void pic_MouseDown(object sender, MouseEventArgs e)
        {
            paint = true;
            py = e.Location;
            cX = e.X;
            cY = e.Y;


        }

        private void pic_MouseMove(object sender, MouseEventArgs e)
        {
            if(paint)
            {
                if(index==1)
                {
                    px = e.Location;
                    g.DrawLine(p, px, py);
                    py = px;

                }

                if (index == 2)
                {
                    px = e.Location;
                    g.DrawLine(erase, px, py);
                    py = px;

                }
            }
            pic.Refresh();

            x = e.X;
            y = e.Y;
            sX = e.X - cX;
            sY = e.Y - cY;


        }

        private void pic_MouseUp(object sender, MouseEventArgs e)
        {
            paint = false;


            sX = x - cX;
            sY = y - cY;
            if (index == 3)
            {
                g.DrawEllipse(p, cX, cY, sX, sY);

            }
            if (index == 4)
            {
                g.DrawRectangle(p, cX, cY, sX, sY);

            }
            if(index==5)
            {
                g.DrawLine(p, cX, cY, sX, sY);

            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            index = 1;

        }

        private void button4_Click(object sender, EventArgs e)
        {
            index = 2;

        }

        int index;



    }

}

