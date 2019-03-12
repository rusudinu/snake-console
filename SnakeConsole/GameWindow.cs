using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace SnakeConsole
{
    public partial class GameWindow : Form
    {
        public GameWindow()
        {
            InitializeComponent();
        }

        int deplasare = 3;
        int countControlTag = 1;
        int deleteControlTag = 1;
        bool spawnObjects = false;
        bool pause = true;
        Keys lastPressedKey = Keys.B;
        double score = 0;
        double scoreMultiplier = 0.5;
        static List<int> colliderLocationX = new List<int>();
        static List<int> colliderLocationY = new List<int>();

        public static void ShowColliders()
        {
            Console.WriteLine("__________________COLLIDERS_______________________");
            for (int i = 1; i < colliderLocationX.Count; i++)
                Console.WriteLine($"{colliderLocationX[i]}     {colliderLocationY[i]}");
            Console.WriteLine("__________________________________________________");
        }

        void spawnObj(int x, int y)
        {
            PictureBox pb = new PictureBox();
            pb.Image = Properties.Resources.white_lowres;
            pb.Location = new Point(x, y);
            pb.Size = new Size(20, 20);
            pb.Name = Convert.ToString(countControlTag);
            pb.Show();
            countControlTag++;
            this.Controls.Add(pb);
            colliderLocationX.Add(x);
            colliderLocationY.Add(y);
            AddSplashCollider(x, y);
        }


       
        private void objectsFallTimer_Tick(object sender, EventArgs e)
        {
            objectsFallTimer.Interval = 10;
                foreach (Control ctrl in this.Controls)
                {
                    if (ctrl.Name != "snake")
                        ctrl.Location = new Point(ctrl.Location.X, ctrl.Location.Y + 5);
                    UpdateSplashCollider(ctrl.Location.X, ctrl.Location.Y + 5);
                }
                spawnObj(DateTime.Now.Second, DateTime.Now.Second / 2);
                Console.WriteLine("Added control");
            objectsFallTimer.Start();
        }

        

        private void UpdateSplashCollider(int valX, int valY)
        {
            AddSplashCollider(valX, valY);
            RemoveSplashCollider(valX, valY-5);
        }

        private void AddSplashCollider(int valX, int valY)
        {
            for (int i = valX + 1; i <= valX + 5; i++)
                colliderLocationX.Add(i); 
            for (int i = valY + 1; i <= valY + 5; i++)
                colliderLocationY.Add(i);
            for (int i = valX - 1; i >= valX - 5; i--)
                colliderLocationX.Add(i);
            for (int i = valY - 1; i >= valY - 5; i--)
                colliderLocationY.Add(i);
        }


        void increaseSpeed()
        {
            if (autoMoveTimer.Interval - 10 > 0) { autoMoveTimer.Interval = autoMoveTimer.Interval - 10; scoreMultiplier = scoreMultiplier + 0.1; }
            else if (autoMoveTimer.Interval - 5 > 0) { autoMoveTimer.Interval = autoMoveTimer.Interval - 5; scoreMultiplier = scoreMultiplier + 0.3; }
            else autoMoveTimer.Interval = 1; scoreMultiplier = 1.7;
        }



        private void GameWindow_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.D1) spawnObj(150, 150);
            if (e.KeyCode == Keys.D2) colliderTimer.Start();
            if (e.KeyCode == Keys.D1)
            {
                if (!spawnObjects) spawnObjects = true;
                else spawnObjects = false;
            }
            if (e.KeyCode == Keys.S) MessageBox.Show($"Your score is {Convert.ToInt32(score)} , and score multiplier is {scoreMultiplier}");
            if (e.KeyCode == Keys.Space)
            {
                if (pause)
                {
                    autoMoveTimer.Start();
                    pause = false;
                    objectsFallTimer.Start();
                }
                else
                {
                    autoMoveTimer.Stop(); pause = true; //ConsoleOps.ConsoleRead(Console.ReadLine()); 
                    ShowColliders();
                    objectsFallTimer.Stop();
                }
            }
            if (!pause)
            {
                if (e.KeyCode == Keys.Enter) increaseSpeed();
                if (e.KeyCode == Keys.Left || e.KeyCode == Keys.A)
                {
                    lastPressedKey = e.KeyCode;
                    int snakePosX = snake.Location.X;
                    int snakePosY = snake.Location.Y;
                    snake.Location = new Point(snakePosX - deplasare, snakePosY);
                }

                if (e.KeyCode == Keys.Right || e.KeyCode == Keys.D)
                {
                    lastPressedKey = e.KeyCode;
                    int snakePosX = snake.Location.X;
                    int snakePosY = snake.Location.Y;
                    snake.Location = new Point(snakePosX + deplasare, snakePosY);
                }

                if (e.KeyCode == Keys.Up || e.KeyCode == Keys.W)
                {
                    lastPressedKey = e.KeyCode;
                    int snakePosX = snake.Location.X;
                    int snakePosY = snake.Location.Y;
                    snake.Location = new Point(snakePosX, snakePosY - deplasare);
                }

                if (e.KeyCode == Keys.Down || e.KeyCode == Keys.S)
                {
                    lastPressedKey = e.KeyCode;
                    int snakePosX = snake.Location.X;
                    int snakePosY = snake.Location.Y;
                    snake.Location = new Point(snakePosX, snakePosY + deplasare);
                }
            }

        }

        private void autoMoveTimer_Tick(object sender, EventArgs e)
        {
            ConsoleOps.WriteToConsoleGreen(snake.Location.X, snake.Location.Y);
            if (!pause)
            {
                score = score + scoreMultiplier * 0.1;
                int snakePosX = snake.Location.X;
                int snakePosY = snake.Location.Y;
                if (snakePosX + deplasare >= this.Size.Width)
                {
                    MessageBox.Show("You lost!");
                    pause = true;
                    autoMoveTimer.Stop();
                }
                else if (snakePosX - deplasare <= 0)
                {
                    MessageBox.Show("You lost!");
                    pause = true;
                    autoMoveTimer.Stop();
                }
                else if (snakePosY + deplasare >= this.Size.Height)
                {
                    MessageBox.Show("You lost!");
                    pause = true;
                    autoMoveTimer.Stop();
                }
                else if (snakePosY - deplasare <= 0)
                {
                    MessageBox.Show("You lost!");
                    pause = true;
                    autoMoveTimer.Stop();
                }
                else if (lastPressedKey == Keys.Right || lastPressedKey == Keys.D)
                {
                    snake.Location = new Point(snakePosX + deplasare, snakePosY);
                    autoMoveTimer.Start();
                }
                else if (lastPressedKey == Keys.Left || lastPressedKey == Keys.A)
                {
                    snake.Location = new Point(snakePosX - deplasare, snakePosY);
                    autoMoveTimer.Start();
                }
                else if (lastPressedKey == Keys.Up || lastPressedKey == Keys.W)
                {
                    snake.Location = new Point(snakePosX, snakePosY - deplasare);
                    autoMoveTimer.Start();
                }
                else if (lastPressedKey == Keys.Down || lastPressedKey == Keys.S)
                {
                    snake.Location = new Point(snakePosX, snakePosY + deplasare);
                    autoMoveTimer.Start();
                }
                for (int i = 1; i <= 5; i++)
                {
                    int cldSz = 1;
                    int testX = snake.Location.X - cldSz;
                    int testY = snake.Location.Y - cldSz;
                    int testX2 = snake.Location.X + cldSz;
                    int testY2 = snake.Location.Y + cldSz;
                    if ((colliderLocationX.Contains(testX) && colliderLocationY.Contains(testY)) || (colliderLocationX.Contains(testX2) && colliderLocationY.Contains(testY2)))
                    {
                        Console.WriteLine("lost");
                        pause = true;
                        ShowColliders();
                    }
                }

                //  Console.WriteLine($"snakeX : {snake.Location.X}  snakeY : {snake.Location.Y}");
            }
            else autoMoveTimer.Stop();
        }

        private void GameWindow_Load(object sender, EventArgs e)
        {
            MessageBox.Show("Press 'space' to start or pause the game, press 'enter' to increase the speed. Press '1' to spawn random things (1v1) :)  Press 's' to see the score. Enjoy!");
        }

        private void colliderTimer_Tick(object sender, EventArgs e)
        {
            colliderTimer.Interval = 1;
            if (deleteControlTag < countControlTag)
            {
                Control[] control = this.Controls.Find(Convert.ToString(deleteControlTag), true);
                foreach (Control ctrl in control)
                {
                    int ctrlX = ctrl.Location.X;
                    int ctrlY = ctrl.Location.Y;
                    colliderLocationX.Remove(ctrlX);
                    colliderLocationY.Remove(ctrlY);
                    RemoveSplashCollider(ctrlX, ctrlY);
                    Console.WriteLine("removed control collider");
                }
                this.Controls.RemoveByKey(Convert.ToString(deleteControlTag));
                deleteControlTag++;
            }

        }
        private void RemoveSplashCollider(int valX, int valY)
        {
            for (int i = valX + 1; i <= valX + 5; i++)
                colliderLocationX.Remove(i);
            for (int i = valY + 1; i <= valY + 5; i++)
                colliderLocationY.Remove(i);
            for (int i = valX - 1; i >= valX - 5; i--)
                colliderLocationX.Remove(i);
            for (int i = valY - 1; i >= valY - 5; i--)
                colliderLocationY.Remove(i);
        }


    }
}
