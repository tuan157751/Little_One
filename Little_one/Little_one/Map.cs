using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Little_one
{
    public class Map
    {
        public Image ground;
        public Size ground_size;
        public Point ground_pos;

        public Map()
        {

            ground = Image.FromFile("C:\\Users\\Admin\\Desktop\\Luan an TN (TK)\\Little_one\\Graphics\\ground.PNG");
            {
                ground_size = new Size(3648, 3200);
                ground_pos = new Point(0, 0);
            }


        }
        public void Draw(Graphics g)
        {

            g.DrawImage(ground, ground_pos.X, ground_pos.Y, ground_size.Width, ground_size.Height);
        }
    }
}
