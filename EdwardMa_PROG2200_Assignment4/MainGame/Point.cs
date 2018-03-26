using System;
using System.Drawing;

namespace MainGame
{
    public class Point
    {
        public Rectangle pointBall;
        private Rectangle mainCanvas;
        private int size = 40;

        Random random = new Random();

        string[] imageArray =
        {
            "Images/Ball 1 Star.png",
            "Images/Ball 2 Stars.png",
            "Images/Ball 3 Stars.png",
            "Images/Ball 4 Stars.png",
            "Images/Ball 5 Stars.png",
            "Images/Ball 6 Stars.png",
            "Images/Ball 7 Stars.png"
        };

        Image images;
        public Point(Rectangle mainCanvas)
        {
            this.mainCanvas = mainCanvas;

            pointBall.Height = size;
            pointBall.Width = size;

            pointBall.X = (random.Next(1, mainCanvas.Width - pointBall.Width));
            pointBall.Y = (random.Next(1, mainCanvas.Height - pointBall.Height));

            int num = random.Next(0, 6);
            images = Image.FromFile(imageArray[num]);
        }

        public void Draw (Graphics graphics)
        {
            graphics.DrawImage(images, pointBall);
        }
    }
}
