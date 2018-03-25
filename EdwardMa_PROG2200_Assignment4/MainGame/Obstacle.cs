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

        Random randon = new Random();

        private Image images = Image.FromFile("Images/nocrossing.png");
        
        public Obstacle(Rectangle mainCanvas)
        {
            this.mainCanvas = mainCanvas;

            obsBox.Height = size;
            obsBox.Width = size;


        }
    }
}
