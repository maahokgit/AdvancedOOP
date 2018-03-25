using System;
using System.Drawing;

namespace BouncyBall2018
{
    class Ball
    {
        public Rectangle ballBox;
        private Rectangle mainCanvas;
        private int size = 40;

        private int XVelocity, YVelocity;

        private Random random = new Random();

        private Color color;
        string[] imageNames = 
            {
            "images/q1z_001.png",
            "images/q1z_002.png",
            "images/q1z_003.png",
            "images/q1z_004.png",
            "images/q1z_005.png",
            "images/q1z_006.png",
            "images/q1z_007.png",
            "images/q1z_008.png",
            "images/q1z_009.png",
            "images/q1z_010.png",
            "images/q1z_011.png",
            "images/q1z_012.png",
            "images/q1z_013.png",
            "images/q1z_014.png",
            "images/q1z_015.png"
        };

        //private Image images = Image.FromFile("images/Aqua-Ball-icon.png");
        public Ball(Rectangle mainCanvas)
        {
            this.mainCanvas = mainCanvas;
            
            // set the size of our ballbox
            ballBox.Height = size;
            ballBox.Width = size;

            // set initial position of ball
            //ballBox.X = (mainCanvas.Width / 2);
            //ballBox.Y = (mainCanvas.Height / 2);

            ballBox.X = (random.Next(1, mainCanvas.Width - ballBox.Width));
            ballBox.Y = (random.Next(1, mainCanvas.Height - ballBox.Height));

            // set the x and y velocity
            while (XVelocity > -3 && XVelocity < 3)
            XVelocity = random.Next(-15, 15);

            while(YVelocity > -3 && YVelocity <3 )
            YVelocity = random.Next(-15, 15);

            // set the ball's color
            color = Color.FromArgb
                (255, random.Next(0, 255), random.Next(0, 255), random.Next(0, 255));
        }

        // create two properties
        public int CurrentX
        {
            get
            {
                return ballBox.X;
            }
        }

        public int CurrentY
        {
            get
            {
                return ballBox.Y;
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
            ballBox.X += XVelocity;
            ballBox.Y += YVelocity;
        }

        public void Draw(Graphics graphics)
        {
            //SolidBrush brush = new SolidBrush(color);
            //graphics.FillEllipse(brush, ballBox);
            graphics.DrawImage(Image.FromFile(imageNames[random.Next(0,14)]), ballBox);
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
