using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace MainGame
{
    public partial class GameForm : Form
    {
        MagaPaddle magaPaddle;
        HashSet<Obstacle> obstacles = new HashSet<Obstacle>();
        HashSet<Point> points = new HashSet<Point>();

        int pointNum = 0;
        int totalPoint = 7;
        public GameForm()
        {
            InitializeComponent();
        }

        private void GameForm_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;

            magaPaddle = new MagaPaddle(DisplayRectangle);
            obstacles.Add(new Obstacle(DisplayRectangle));
            points.Add(new Point(DisplayRectangle));
        }

        private void GameForm_Paint(object sender, PaintEventArgs e)
        {
            magaPaddle.Draw(e.Graphics);

            foreach (Obstacle obstacle in obstacles)
            {
                obstacle.Draw(e.Graphics);
            }

            foreach (Point point in points)
            {
                point.Draw(e.Graphics);
            }
            DisplayBallCount(e.Graphics);
            gameTimer.Start();
            obstacleTimer.Start();
            pointTimer.Start();
        }

        private void GameForm_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyData)
            {
                case Keys.Left:
                    {
                        // move the paddle left
                        magaPaddle.Move(MagaPaddle.Direction.Left);                      
                        break;
                    }
                case Keys.Right:
                    {
                        // move the paddle right
                        magaPaddle.Move(MagaPaddle.Direction.Right);
                        break;
                    }
                case Keys.Up:
                    {
                        magaPaddle.Move(MagaPaddle.Direction.Up);
                        break;
                    }
                case Keys.Down:
                    {
                        magaPaddle.Move(MagaPaddle.Direction.Down);
                        break;
                    }
            }
        }

        private void ObstacleTimer_Tick(object sender, EventArgs e)
        {
            obstacles.Add(new Obstacle(DisplayRectangle));
        }

        private void CheckForCollisions()
        {
            points.RemoveWhere(PointTouchPaddle);

            foreach (Obstacle obstacle in obstacles)
            {
                // collision with left wall
                if (obstacle.CurrentX <= DisplayRectangle.Left)
                {
                    obstacle.FlipX();
                }

                // collision with right wall
                if (obstacle.CurrentX + obstacle.Size >= DisplayRectangle.Right)
                {
                    obstacle.FlipX();
                }
                // collision with ceiling
                if (obstacle.CurrentY <= DisplayRectangle.Top)
                {
                    obstacle.FlipY();
                }

                if (obstacle.CurrentY + obstacle.Size > DisplayRectangle.Bottom)
                {
                    obstacle.FlipY();
                }

                if (magaPaddle.magaBox.IntersectsWith(obstacle.obsBox))
                {
                    obstacleTimer.Stop();
                    pointTimer.Stop();
                    gameTimer.Stop();
                    MessageBox.Show("You got hit!");
                    Environment.Exit(1);
                }
            }


        }

        private void pointTimer_Tick(object sender, EventArgs e)
        {
            if(pointNum != 6)
            {
                points.Add(new Point(DisplayRectangle));
                pointNum += 1;
            }
        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            // tell the obstacle to move
            foreach (Obstacle obstacle in obstacles)
            {
                obstacle.Move();
            }

            CheckForCollisions();

            Invalidate();
        }

        public bool PointTouchPaddle(Point point)
        {
            return magaPaddle.magaBox.IntersectsWith(point.pointBall);
        }

        public void DisplayBallCount(Graphics graphics)
        {
            // ask the hashset for it's current count
            string display = String.Format("Point Count: {0}", points.Count);

            Font font = new Font("Verdana", 30);

            graphics.DrawString(display, font, Brushes.White, 20, 20);
        }
    }
}
