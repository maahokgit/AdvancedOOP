﻿using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace MainGame
{
    public partial class GameForm : Form
    {
        MagaPaddle magaPaddle;
        HashSet<Obstacle> obstacles = new HashSet<Obstacle>();

        public GameForm()
        {
            InitializeComponent();
        }

        private void GameForm_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;

            magaPaddle = new MagaPaddle(DisplayRectangle);
            obstacles.Add(new Obstacle(DisplayRectangle));
        }

        private void GameForm_Paint(object sender, PaintEventArgs e)
        {
            magaPaddle.Draw(e.Graphics);

            foreach (Obstacle obstacle in obstacles)
            {
                obstacle.Draw(e.Graphics);
            }

            obstacleTimer.Start();
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
            // tell the ball to move
            foreach (Obstacle obstacle in obstacles)
            {
                obstacle.Move();
            }
            Invalidate();
        }
    }
}
