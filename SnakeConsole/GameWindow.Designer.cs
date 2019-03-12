namespace SnakeConsole
{
    partial class GameWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.snake = new System.Windows.Forms.PictureBox();
            this.autoMoveTimer = new System.Windows.Forms.Timer(this.components);
            this.colliderTimer = new System.Windows.Forms.Timer(this.components);
            this.objectsFallTimer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.snake)).BeginInit();
            this.SuspendLayout();
            // 
            // snake
            // 
            this.snake.Image = global::SnakeConsole.Properties.Resources.white_lowres;
            this.snake.Location = new System.Drawing.Point(509, 297);
            this.snake.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.snake.Name = "snake";
            this.snake.Size = new System.Drawing.Size(10, 10);
            this.snake.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.snake.TabIndex = 0;
            this.snake.TabStop = false;
            // 
            // autoMoveTimer
            // 
            this.autoMoveTimer.Interval = 130;
            this.autoMoveTimer.Tick += new System.EventHandler(this.autoMoveTimer_Tick);
            // 
            // colliderTimer
            // 
            this.colliderTimer.Tick += new System.EventHandler(this.colliderTimer_Tick);
            // 
            // objectsFallTimer
            // 
            this.objectsFallTimer.Tick += new System.EventHandler(this.objectsFallTimer_Tick);
            // 
            // GameWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(730, 482);
            this.Controls.Add(this.snake);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "GameWindow";
            this.Text = "GameWindow";
            this.Load += new System.EventHandler(this.GameWindow_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.GameWindow_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.snake)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox snake;
        private System.Windows.Forms.Timer autoMoveTimer;
        private System.Windows.Forms.Timer colliderTimer;
        private System.Windows.Forms.Timer objectsFallTimer;
    }
}