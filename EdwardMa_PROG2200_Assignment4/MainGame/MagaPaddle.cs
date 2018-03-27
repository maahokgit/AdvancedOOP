using System.Drawing;

namespace MainGame
{
    public class MagaPaddle
    {
        public Rectangle magaBox;
        Rectangle mainCanvas;
        private int size = 40
            
            ;
        private Image image = Image.FromFile("Images/q1z_010.png");
        public enum Direction
        {
            Left,
            Right,
            Up,
            Down
        }

        public MagaPaddle(Rectangle mainCanvas)
        {
            this.mainCanvas = mainCanvas;
            magaBox.Width = size;
            magaBox.Height = size;
            magaBox.Y = (mainCanvas.Height / 2);
            magaBox.X = (mainCanvas.Width / 2);
        }

        public void Move(Direction direction)
        {
            switch (direction)
            {
                case Direction.Left:
                    {
                        if (magaBox.X > 25)
                        {
                            magaBox.X -= 25;
                        }
                        else
                        {
                            magaBox.X = 0;
                        }

                        break;
                    }
                case Direction.Right:
                    {
                        // if there's less than 25 left before the wall
                        if (mainCanvas.Right - magaBox.Right < 25)
                        {
                            // move to the wall
                            magaBox.X = mainCanvas.Width - magaBox.Width;
                        }
                        else
                        {
                            // move the full 25
                            magaBox.X += 25;
                        }

                        break;
                    }
                case Direction.Up:
                    {
                        if (mainCanvas.Top - magaBox.Top < mainCanvas.Top)
                        {
                            magaBox.Y -= 25;
                        }
                        else
                        {
                            magaBox.Y = 0;
                        }

                        break;
                    }
                case Direction.Down:
                    {
                        if (mainCanvas.Bottom - magaBox.Bottom > 25)
                        {
                            magaBox.Y += 25;
                        }
                        else
                        {
                            magaBox.Y = mainCanvas.Height - magaBox.Height;
                        }
                        break;
                    }
            }
        }

        public void Draw(Graphics graphics)
        {
            graphics.DrawImage(image, magaBox);
        }
    }
}
