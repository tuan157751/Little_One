using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Little_one
{
    public class Tiles
    {
        public Image tile_img;
        public Point tilePosition { get; private set; }
        public Size tileSize;
        public int tileSizeX = 32;
        public int tileSizeY = 32;
        public int x { get; private set; }
        public int y { get; private set; }
        public Tiles(int X, int Y)
        {
            x = X;
            y = Y;

            tile_img = Image.FromFile("C:\\Users\\Admin\\Desktop\\Luan an TN (TK)\\My Game\\Images\\Tile1.PNG");
            tilePosition = new Point(X,Y);
            tileSize = new Size(32, 32);

        }
        public void Draw(Graphics g)
        {
            // Draw the tile (e.g., as a rectangle for now)
            g.DrawImage(tile_img, x, y, tileSize.Width, tileSize.Height); // Example size 50x50, adjust as needed
        }
        /*public (int X11, int Y11, int X22, int Y22) right()
        {

            int X11 = tile_img[0].Location.X + tile_img[0].Size.Width;
            int Y11 = tile_img[0].Location.Y;

            int X22 = tile_img[0].Location.X + tile_img[0].Size.Width;
            int Y22 = tile_img[0].Location.Y + tile_img[0].Size.Height;

            return (X11, Y11, X22, Y22);
        }*/
        public Rectangle GetBounds()
        {
            return new Rectangle(tilePosition, tileSize);
        }

        public int left_side()
        {
            int x;
            x = this.tilePosition.X + tileSize.Width;
            return x;
        }
    }
}
