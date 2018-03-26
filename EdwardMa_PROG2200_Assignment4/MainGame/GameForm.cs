﻿using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace MainGame
{
    public partial class GameForm : Form
    {
        MagaPaddle magaPaddle;
        HashSet<Obstacle> obstacles = new HashSet<Obstacle>();
        HashSet<Point> points = new HashSet<Point>();

        int pointNum = 0;
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
    }
}
