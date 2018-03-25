using System;
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
        }

        private void GameForm_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyData)
            {
                case Keys.Left:
                    {
                        // move the paddle left
                        magaPaddle.Move(MagaPaddle.Direction.Left);
                        Invalidate(); // force paint event to redraw
                        break;
                    }
                case Keys.Right:
                    {
                        // move the paddle right
                        magaPaddle.Move(MagaPaddle.Direction.Right);
                        Invalidate();
                        break;
                    }
                case Keys.Up:
                    {
                        magaPaddle.Move(MagaPaddle.Direction.Up);
                        Invalidate();
                        break;
                    }
                case Keys.Down:
                    {
                        magaPaddle.Move(MagaPaddle.Direction.Down);
                        Invalidate();
                        break;
                    }
            }
        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {

        }
    }
}
