using System;
using System.Windows.Forms;

namespace MainGame
{
    public partial class GameForm : Form
    {
        MagaPaddle magaPaddle;
        public GameForm()
        {
            InitializeComponent();
        }

        private void GameForm_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;

            magaPaddle = new MagaPaddle(DisplayRectangle);
        }

        private void GameForm_Paint(object sender, PaintEventArgs e)
        {
            magaPaddle.Draw(e.Graphics);
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
    }
}
