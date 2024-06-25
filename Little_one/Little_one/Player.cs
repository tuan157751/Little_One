using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Little_one
{
    public class Player
    {
        public float speed = 4;
        //public PictureBox player_img;
        public Image player_img;
        public Size playerSize;
        public PointF velocity;
        public PointF Position;
        private Level level;

        private bool isMovingLeft;
        private bool isMovingRight;
        private bool isMovingUp;
        private bool isMovingDown;
        public Player()
        {
            player_img = Image.FromFile("C:\\Users\\Admin\\Desktop\\Luan an TN (TK)\\My Game\\Images\\player1.PNG");
            playerSize = new Size(28, 32);
            velocity = new PointF();
            Position = new PointF(50,50);

            level = new Level();
            level.create_map();
        }
        public void AttachKeyEvents(Form form)
        {
            form.KeyDown += new KeyEventHandler(Player_KeyDown);
            form.KeyUp += new KeyEventHandler(Player_KeyUp);
            form.KeyPreview = true;
        }
            public void Draw (Graphics g)
        {
            g.DrawImage(player_img, Position.X, Position.Y, playerSize.Width, playerSize.Height);
        }
        /* public void Player_KeyDown(object sender, KeyEventArgs e)
         {
             switch (e.KeyCode)
             {
                 case Keys.Left:

                     this.velocity.X = -1;
                     Console.WriteLine("left on!");
                     break;
                 case Keys.Right:                   
                     this.velocity.X = 1;
                     Console.WriteLine("right on!");
                     break;
                 case Keys.Up:

                     this.velocity.Y = -1;
                     Console.WriteLine("Up on!");
                     break;
                 case Keys.Down:

                     this.velocity.Y = 1;
                     Console.WriteLine("Down on!");
                     break;


             }
         }
         public void Player_KeyUp(object sender, KeyEventArgs e)
         {
             switch (e.KeyCode)
             {
                 case Keys.Left:

                     this.velocity.X = 0;
                     break;
                 case Keys.Right:

                     this.velocity.X = 0;
                     break;
                 case Keys.Up:

                     this.velocity.Y = 0;
                     break;
                 case Keys.Down:
                     this.velocity.Y = 0;
                     break;
             }
         }*/
        public void Player_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Left:
                    isMovingLeft = true;
                    break;
                case Keys.Right:
                    isMovingRight = true;
                    break;
                case Keys.Up:
                    isMovingUp = true;
                    break;
                case Keys.Down:
                    isMovingDown = true;
                    break;
            }

            UpdateVelocity();
        }

        public void Player_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Left:
                    isMovingLeft = false;
                    break;
                case Keys.Right:
                    isMovingRight = false;
                    break;
                case Keys.Up:
                    isMovingUp = false;
                    break;
                case Keys.Down:
                    isMovingDown = false;
                    break;
            }

            UpdateVelocity();
        }
        private void UpdateVelocity()
        {
            velocity = new PointF(0, 0);

            if (isMovingLeft)
            {
                velocity.X = -1;
            }
            if (isMovingRight)
            {
                velocity.X = 1;
            }
            if (isMovingUp)
            {
                velocity.Y = -1;
            }
            if (isMovingDown)
            {
                velocity.Y = 1;
            }

            // Normalize the velocity vector if both components are non-zero
            if (velocity.X != 0 && velocity.Y != 0)
            {
                float length = (float)Math.Sqrt(velocity.X * velocity.X + velocity.Y * velocity.Y);
                velocity.X /= length;
                velocity.Y /= length;
            }
        }
        public void move()
        {
            /*if (velocity.X != 0 && velocity.Y != 0)
            { 
                // normalize vector (chuan hoa)
                float Lenght =  (float)Math.Sqrt(velocity.X* velocity.X + velocity.Y *velocity.Y);
                velocity.X /= Lenght; // if vetor has lenght set it to 1 no matter which direction it goes  
                velocity.Y /= Lenght;
            }*/
            Position.X += velocity.X * speed;
            Collision("Horizontal");
            Position.Y += velocity.Y * speed;
            Collision("Vertical");
            //Position = new PointF(Position.X + velocity.X * speed, Position.Y + velocity.Y * speed);
        
        }

    

        public RectangleF GetBounds()
        {
            return new RectangleF(Position.X, Position.Y, playerSize.Width, playerSize.Height);
        }

        public void Collision(string direction)
        {
            
            if (direction == "Horizontal")
            {
                
                foreach (var tiles in level.tiles)

                {
                    
                    if (this.GetBounds().IntersectsWith(tiles.GetBounds()))
                    {
                        Console.WriteLine("Collision detected!!!");

                        if (this.velocity.X < 0)
                        {
                            this.velocity.X = 0;
                            this.Position = new PointF(tiles.tilePosition.X + tiles.tileSizeX, this.Position.Y);
                        }
                        if (this.velocity.X > 0)
                        {
                            this.velocity.X = 0;
                            this.Position = new PointF(tiles.tilePosition.X - this.playerSize.Width, this.Position.Y);
                        }
                    }
                }
            }
            if (direction == "Vertical")
            {
                foreach (var tiles in level.tiles)

                {
                    if (this.GetBounds().IntersectsWith(tiles.GetBounds()))
                    {
                        if (this.velocity.Y < 0)
                        {
                            this.velocity.Y = 0;
                            this.Position = new PointF(this.Position.X, tiles.tilePosition.Y + tiles.tileSize.Height);
                        }
                        if (this.velocity.Y > 0)
                        {
                            this.velocity.Y = 0;
                            this.Position = new PointF(this.Position.X, tiles.tilePosition.Y - this.playerSize.Height);
                        }
                    }
                }
            }

        }
    }
}
    



