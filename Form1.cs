using System;
using System.Drawing;
using System.Windows.Forms;

namespace Paint
{
    public partial class Form1 : Form
    {
        Graphics graphic;
        bool move = false;
        int x = 0;
        int y = 0;

        Pen pen;

        public Form1()
        {
            InitializeComponent();
            graphic = paint_panel.CreateGraphics();
            graphic.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            pen = new Pen(Color.Black, 1);
            pen.StartCap = pen.EndCap = System.Drawing.Drawing2D.LineCap.Round;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            PictureBox p = (PictureBox)sender;
            pen.Color = p.BackColor;
        }

        private void paint_panel_MouseDown(object sender, MouseEventArgs e)
        {
            move = true;
            x = e.X;
            y = e.Y;
        }

        private void paint_panel_MouseMove(object sender, MouseEventArgs e)
        {
            if(move && x != -1 && y != -1)
            {
                graphic.DrawLine(pen, new Point(x, y), e.Location);
                x = e.X;
                y = e.Y;
            }
        }

        private void paint_panel_MouseUp(object sender, MouseEventArgs e)
        {
            move = false;
            x = 0;
            y = 0;
        }
    }
}
