using System.Drawing;

namespace BouncyBall2018
{
    public class Paddle
    {
        public Rectangle paddleBox;
        Rectangle mainCanvas;
        public enum Direction { Left, Right, Up, Down}
        // X and Y coordinate
        // size
        public Paddle(Rectangle mainCanvas)
        {
            this.mainCanvas = mainCanvas;
            // set the size of our paddle box
            paddleBox.Height = 10;
            paddleBox.Width = 100;

            paddleBox.Y = (int)(mainCanvas.Height * 0.9);
            paddleBox.X = (int)(mainCanvas.Width * 0.5);
        }

        // move
        public void Move(Direction direction)
        {
            switch(direction)
            {
                case Direction.Left:
                    {
                        if(paddleBox.X > 25)
                        {
                            paddleBox.X -= 25;
                        }
                        else
                        {
                            paddleBox.X = 0;
                        }
                        
                        break;
                    }
                case Direction.Right:
                    {
                        // if there's less than 25 left before the wall
                        if(mainCanvas.Right - paddleBox.Right < 25)
                        {
                            // move to the wall
                            paddleBox.X = mainCanvas.Width - paddleBox.Width;
                        }
                        else
                        {
                            // move the full 25
                            paddleBox.X += 25;
                        }
                        
                        break;
                    }
                case Direction.Up:
                    {
                        if(mainCanvas.Top - paddleBox.Top < 25)
                        {
                            paddleBox.Y -= 25;
                        }
                        else
                        {
                            paddleBox.Y = 0;
                        }

                        break;
                    }
                case Direction.Down:
                    {
                        if(mainCanvas.Bottom - paddleBox.Bottom > 25)
                        {
                            paddleBox.Y += 25; 
                        }
                        else
                        {
                            paddleBox.Y = mainCanvas.Height - paddleBox.Height;
                        }
                        break;
                    }
            }
        }

        public void Draw(Graphics graphics)
        {
            // need the graphics object to draw

            graphics.FillRectangle(Brushes.White, paddleBox);
        }
    }
}
