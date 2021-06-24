using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArrayPractice
{
    public partial class Form1 : Form
    {
        static Random rand = new Random();

        int []vx = new int[100];
        int []vy = new int[100];
        Label[] labels = new Label[100];
        int score = 100;
        

        public Form1()
        {
            InitializeComponent();
            
            for(int i = 0; i < 10; i++)
            {
                vx[i] = rand.Next(-20, 21);
                vy[i] = rand.Next(-20, 21);

                labels[i] = new Label();
                labels[i].AutoSize = true;
                labels[i].Text = "★";
                Controls.Add(labels[i]);

                labels[i].Left = rand.Next(ClientSize.Width - labels[i].Width);
                labels[i].Top = rand.Next(ClientSize.Height - labels[i].Height);
            }
            //timer1.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            score--;
            scoreLabel.Text = $"Score {score:000}";
            int count = 0;

            Point fpos = PointToClient(MousePosition);

            for (int i=0;i<10;i++)
            {
                labels[i].Left += vx[i];
                labels[i].Top += vy[i];

                if (labels[i].Left < 0)
                {
                    vx[i] = Math.Abs(vx[i]);
                }
                if (labels[i].Top < 0)
                {
                    vy[i] = Math.Abs(vy[i]);
                }
                if (labels[i].Right > ClientSize.Width)
                {
                    vx[i] = -Math.Abs(vx[i]);
                }
                if (labels[i].Bottom > ClientSize.Height)
                {
                    vy[i] = -Math.Abs(vy[i]);
                }

                if ((fpos.X >= labels[i].Left)
                && (fpos.X < labels[i].Right)
                && (fpos.Y >= labels[i].Top)
                && (fpos.Y < labels[i].Bottom))
                {
                    labels[i].Visible = false;
                }
            }
            
            for(int i=0;i<10;i++)
            {
                if (labels[i].Visible == false) count++;
            }
            if(count==10) timer1.Enabled = false;

        }
    }
}