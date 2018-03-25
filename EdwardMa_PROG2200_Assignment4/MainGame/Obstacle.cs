using System;
using System.Drawing;

namespace MainGame
{
    public class Obstacle
    {
        public Rectangle obsBox;
        private Rectangle mainCanvas;
        private int size = 37;

        private int XVelocity, YVelocity;

        Random random = new Random();

        private Image images = Image.FromFile("Images/nocrossing.png");
        
        public Obstacle(Rectangle mainCanvas)
        {
            this.mainCanvas = mainCanvas;

            obsBox.Height = size;
            obsBox.Width = size;

            obsBox.X = (random.Next(1, mainCanvas.Width - obsBox.Width));
            obsBox.Y = (random.Next(1, mainCanvas.Height - obsBox.Height));

            // set the x and y velocity
            while (XVelocity > -3 && XVelocity < 3)
                XVelocity = random.Next(-15, 15);

            while (YVelocity > -3 && YVelocity < 3)
                YVelocity = random.Next(-15, 15);
        }

        public int CurrentX
        {
            get
            {
                return obsBox.X;
            }
        }

        public int CurrentY
        {
            get
            {
                return obsBox.Y;
            }
        }

        public int Size
        {
            get
            {
                return size;
            }
        }

        public void Move()
        {
            obsBox.X += XVelocity;
            obsBox.Y += YVelocity;
        }

        public void Draw(Graphics graphics)
        {
            graphics.DrawImage(images, obsBox);
        }

        public void FlipX()
        {
            XVelocity *= -1;
        }

        public void FlipY()
        {
            YVelocity *= -1;
        }
    }
}
