using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Move
{
    public partial class Form1 : Form
    {
        Timer time = new Timer();
        bool move = true;
        public Form1()
        {
            InitializeComponent();
            InitializeComponent();
            time.Interval = 1;
            time.Tick += time_Tick;
            //time.Start();
            this.KeyDown += Form1_KeyDown;
        }

        void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            int delta = 10;
            int x = this.button1.Location.X;
            int y = this.button1.Location.Y;
            switch (e.KeyCode)
            {
                case Keys.W:
                    this.button1.Location = new Point(x, y - delta);
                    break;
                case Keys.S:
                    this.button1.Location = new Point(x, y + delta);
                    break;
                case Keys.D:
                    this.button1.Location = new Point(x + delta, y);
                    break;
                case Keys.A:
                    this.button1.Location = new Point(x - delta, y);
                    break;
            }
        }

        void time_Tick(object sender, EventArgs e)
        {
            int x = this.button1.Location.X;
            int y = this.button1.Location.Y;
            this.button1.Location = new Point(x, y + 10);
            if (y > 500)
            {
                Random rand = new Random();
                x = rand.Next(this.Width);
                this.button1.Location = new Point(x, 0);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!move)
                this.time.Stop();
            else
                time.Start();
            move = !move;     
        }
    }
}
