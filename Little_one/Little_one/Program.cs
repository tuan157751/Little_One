using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Printing;
using Newtonsoft.Json;


namespace Little_one
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new GameForm());
        }
    }

    public class GameForm : Form
    {
        private Player player;
        private Tiles tile;
        private Timer timer;
        private Level level;
        private Camera camera;
        private Map map;

        public GameForm()
        {
            // background
            this.BackColor = Color.Black;
            this.Size = new Size(1080, 720);
            this.Text = "Little One";
            this.DoubleBuffered = true;

            // level, map
            level = new Level();
            level.create_map();

            // player
            player = new Player();
            player.AttachKeyEvents(this);


            // set timer
            timer = new Timer();
            timer.Interval = 16;
            timer.Tick += Timer_Tick;
            timer.Start();

            //Camera
            camera = new Camera(new  Size(this.ClientSize.Width, this.ClientSize.Height));

            // map
            map = new Map();


            foreach (var tile in level.tiles)
            {
               
            }




        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            // Draw the player image at the current position
            //player.Draw(g);

           // map.Draw(g);
            var transformedPosition0 = camera.ApplyTransform(map.ground_pos);
            g.DrawImage(map.ground, transformedPosition0.X, transformedPosition0.Y, map.ground_size.Width, map.ground_size.Height);
            var transformedPosition = camera.ApplyTransform(player.Position);
            g.DrawImage(player.player_img, transformedPosition.X, transformedPosition.Y, player.playerSize.Width, player.playerSize.Height);

            foreach (var tile in level.tiles)
            {
                var transformedPosition2 = camera.ApplyTransform(tile.tilePosition);
                g.DrawImage(tile.tile_img, transformedPosition2.X, transformedPosition2.Y, tile.tileSize.Width, tile.tileSize.Height);
            }
            // For debugging: draw the player's bounds
            /* using (Pen pen = new Pen(Color.Red, 2))
             {
                 g.DrawRectangle(pen, transformedPosition.X, transformedPosition.Y, player.playerSize.Width, player.playerSize.Height);
             }
             using (Pen pen = new Pen(Color.Red, 2))
             {
                 g.DrawRectangle(pen, camera.cameraPosition.X, camera.cameraPosition.Y, camera.screenSize.Width, camera.screenSize.Height);
             }*/


            /*foreach (var tile in level.tiles)
            {
                if (tile.tilePosition.Y < player.Position.Y)
                {
                    var transformedPosition = camera.ApplyTransform(player.Position);
                    g.DrawImage(player.player_img, transformedPosition.X, transformedPosition.Y, player.playerSize.Width, player.playerSize.Height);
                    var transformedPosition2 = camera.ApplyTransform(tile.tilePosition);
                    g.DrawImage(tile.tile_img, transformedPosition2.X, transformedPosition2.Y, tile.tileSize.Width, tile.tileSize.Height);
                    //tile.Draw(g);
                }
                else
                {
                        var transformedPosition2 = camera.ApplyTransform(tile.tilePosition);
                        g.DrawImage(tile.tile_img, transformedPosition2.X, transformedPosition2.Y, tile.tileSize.Width, tile.tileSize.Height);
                }

                
            }*/



        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            player.move();
            camera.Update(player.Position);
            //UpdatePlayerPosition();
            this.Invalidate();

        }
       
        private void Collisions(string direction)
        {
            if (direction == "Horizontal")
            {
                foreach (var tiles in level.tiles)

                {

                    //Console.WriteLine(tiles.tilePosition);
                    if (player.GetBounds().IntersectsWith(tiles.GetBounds()))
                    {

                        if (player.velocity.X < 0)
                        {
                            player.velocity.X = 0;
                            player.Position = new PointF(tiles.tilePosition.X + tiles.tileSize.Width, player.Position.Y);
                        }
                        if (player.velocity.X > 0)
                        {
                            player.velocity.X = 0;
                            player.Position = new PointF(tiles.tilePosition.X - player.playerSize.Width, player.Position.Y);
                        }
                    }
                }
            }
            if (direction == "Vertical")
            {
                foreach (var tiles in level.tiles)

                {
                    if (player.GetBounds().IntersectsWith(tiles.GetBounds()))
                    {
                        if (player.velocity.Y < 0)
                        {
                            player.velocity.Y = 0;
                            player.Position = new PointF(player.Position.X, tiles.tilePosition.Y + tiles.tileSize.Height);
                        }
                        if (player.velocity.Y > 0)
                        {
                            player.velocity.Y = 0;
                            player.Position = new PointF(player.Position.X, tiles.tilePosition.Y - player.playerSize.Height);
                        }
                    }

                }
            }

        }
    }
}

    

