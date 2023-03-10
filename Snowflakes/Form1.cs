using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Snowflakes
{
    public partial class Form1 : Form

    {
        IList<Snowflake> snowflakes = new List<Snowflake>();
        Timer t = new Timer();
        Image s = Resource1.S;
        Image b = Resource1.Les;
        Graphics g;
        Random r = new Random();
        public Form1()
        {
            InitializeComponent();
            g = Graphics.FromImage(pictureBox1.BackgroundImage);
            
            for (int i=0; i<50;i++)
            {
                snowflakes.Add(new Snowflake()
                {
                    size = r.Next(15, 30),
                    x = r.Next(8, Width),
                    y = r.Next(-Height,-30),
                });
            }
            t = new Timer();
            t.Interval = 10;
            t.Tick += T_Tick;
            
        }

        private void T_Tick(object sender, EventArgs e)
        {   Refresh();
            g.DrawImage(b, 0, 0);
            foreach(Snowflake snowflake in snowflakes)
            {
                g.DrawImage(s, snowflake.x, snowflake.y, snowflake.size, snowflake.size);
                snowflake.y += snowflake.size/10;
                if(snowflake.y>Height)
                {
                    snowflake.x = r.Next(8, Width);
                    snowflake.y = -30;
                }
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(t.Enabled)
            {
                g.DrawImage(b, 0, 0);
                Refresh();
                button1.Text = "Начать";
                t.Stop();
            }
            else
            {
                foreach(Snowflake snowflake in snowflakes)
                {
                    snowflake.x = r.Next(0, Width);
                    snowflake.y = r.Next(-Height, -30);
                }
                button1.Text = "Остановить";
                t.Start();
            }
        }
    }
}
