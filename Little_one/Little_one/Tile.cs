using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using Newtonsoft.Json;
using System.Security.Cryptography.X509Certificates;
using System.Collections.Generic;

namespace Little_one
{
    public class Tiles
    {
        public Image tile_img;
        public Point tilePosition { get; private set; }
        public Size tileSize;
        public Size HitBox_size;
        public Point HitBox_Pos;
        public int x { get; private set; }
        public int y { get; private set; }
        public Tiles(int X, int Y)
        {
            x = X;
            y = Y;

            tile_img = Image.FromFile("C:\\Users\\Admin\\Desktop\\Luan an TN (TK)\\My Game\\Images\\Tile1.PNG");
            tilePosition = new Point(X,Y);
            tileSize = new Size(64, 64);

            // Hit box put player on or behind tile so the graphic feel better
            HitBox_size = new Size(64, 64-28); 
            HitBox_Pos = new Point(X, Y + 14);



        }
        public void Draw(Graphics g)
        {
            // Draw the tile (e.g., as a rectangle for now)
            g.DrawImage(tile_img, x, y, tileSize.Width, tileSize.Height); // Example size 50x50, adjust as needed
        }
        
        public Rectangle GetBounds()
        {
            return new Rectangle(HitBox_Pos, HitBox_size);
        }

        public int left_side()
        {
            int x;
            x = this.tilePosition.X + tileSize.Width;
            return x;
        }
    }
}

public class TileMap{

   // public string Name { get; set; }
    public int[,] data { get; set; } 



}
