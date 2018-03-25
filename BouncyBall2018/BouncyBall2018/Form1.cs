using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace BouncyBall2018
{
    public partial class gameCanvas : Form
    {
        Paddle paddle;
        HashSet<Ball> balls = new HashSet<Ball>();

        public gameCanvas()
        {
            InitializeComponent();
        }

        private void gameCanvas_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;

            // create our paddle
            paddle = new Paddle(DisplayRectangle);
            balls.Add(new Ball(DisplayRectangle));
        }

        private void gameCanvas_Paint(object sender, PaintEventArgs e)
        {
            paddle.Draw(e.Graphics);

            foreach (Ball ball in balls)
            {
                ball.Draw(e.Graphics);
            }

            DisplayBallCount(e.Graphics);
        }

        private void gameCanvas_KeyDown(object sender, KeyEventArgs e)
        {
            switch(e.KeyData)
            {
                case Keys.Left:
                    {
                        // move the paddle left
                        paddle.Move(Paddle.Direction.Left);
                        //Invalidate(); // force paint event to redraw
                        break;
                    }
                case Keys.Right:
                    {
                        // move the paddle right
                        paddle.Move(Paddle.Direction.Right);
                        //Invalidate();
                        break;
                    }
                case Keys.Up:
                    {
                        paddle.Move(Paddle.Direction.Up);
                        break;
                    }
                case Keys.Down:
                    {
                        paddle.Move(Paddle.Direction.Down);
                        break;
                    }
                case Keys.Space:
                    {
                        animationTimer.Enabled = !animationTimer.Enabled;
                        break;
                    }
                case Keys.N:
                    {
                        balls.Add(new Ball(DisplayRectangle));
                        break;
                    }
            }
        }

        private void animationTimer_Tick(object sender, EventArgs e)
        {
            // tell the ball to move
            foreach (Ball ball in balls)
            {
                ball.Move();
            }

            // check for collision
            CheckForCollisions();

            // tell the form to redraw intself
            Invalidate();
        }

        private void CheckForCollisions()
        {
            // first remove any ball object that miss the paddle
            balls.RemoveWhere(BallMissesPaddle);

            foreach (Ball ball in balls)
            {
                // collision with left wall
                if (ball.CurrentX <= DisplayRectangle.Left)
                {
                    ball.FlipX();
                }

                // collision with right wall
                if (ball.CurrentX + ball.Size >= DisplayRectangle.Right)
                {
                    ball.FlipX();
                }
                // collision with ceiling
                if (ball.CurrentY <= DisplayRectangle.Top)
                {
                    ball.FlipY();
                }

                if (ball.CurrentY + ball.Size > DisplayRectangle.Bottom)
                {
                    ball.FlipY();
                }

                // collision with paddle
                // check if ball bounding box intersect with paddle bounding box
                //if (paddle.paddleBox.IntersectsWith(ball.ballBox))
                //{
                //    ball.FlipY();
                //    //balls.Remove(ball);
                //}

                //    // determine if ball is missed by the paddle
                //    if(ball.ballBox.Y <paddle.paddleBox.Y)
                //    {
                //        balls.Remove(ball);
                //    }
            }
        }

        private bool BallMissesPaddle(Ball ball)
        {
            //return ball.ballBox.Y > paddle.paddleBox.Y;
            return paddle.paddleBox.IntersectsWith(ball.ballBox);
        }

        public void DisplayBallCount(Graphics graphics)
        {
            // ask the hashset for it's current count
            string display = String.Format("Ball Count: {0}", balls.Count);

            Font font = new Font("Verdana", 30);

            graphics.DrawString(display, font, Brushes.White, 20, 20);
        }
    }
}
