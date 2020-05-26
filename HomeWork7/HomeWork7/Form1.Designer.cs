namespace HomeWork7
{
    partial class mainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mainForm));
            this.btnPlay = new System.Windows.Forms.Button();
            this.leftTimer = new System.Windows.Forms.Timer(this.components);
            this.downTimer = new System.Windows.Forms.Timer(this.components);
            this.rightTimer = new System.Windows.Forms.Timer(this.components);
            this.upTimer = new System.Windows.Forms.Timer(this.components);
            this.scene = new System.Windows.Forms.Panel();
            this.lMisses = new System.Windows.Forms.Label();
            this.explode = new System.Windows.Forms.PictureBox();
            this.ball = new System.Windows.Forms.PictureBox();
            this.tbSpeed = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.scene.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.explode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ball)).BeginInit();
            this.SuspendLayout();
            // 
            // btnPlay
            // 
            this.btnPlay.Location = new System.Drawing.Point(713, 396);
            this.btnPlay.Name = "btnPlay";
            this.btnPlay.Size = new System.Drawing.Size(75, 23);
            this.btnPlay.TabIndex = 1;
            this.btnPlay.Text = "Играть";
            this.btnPlay.UseVisualStyleBackColor = true;
            this.btnPlay.Click += new System.EventHandler(this.btnPlay_Click);
            // 
            // leftTimer
            // 
            this.leftTimer.Interval = 1;
            this.leftTimer.Tick += new System.EventHandler(this.leftTimer_Tick_1);
            // 
            // downTimer
            // 
            this.downTimer.Interval = 1;
            this.downTimer.Tick += new System.EventHandler(this.downTimer_Tick_1);
            // 
            // rightTimer
            // 
            this.rightTimer.Interval = 1;
            this.rightTimer.Tick += new System.EventHandler(this.rightTimer_Tick_1);
            // 
            // upTimer
            // 
            this.upTimer.Interval = 1;
            this.upTimer.Tick += new System.EventHandler(this.upTimer_Tick_1);
            // 
            // scene
            // 
            this.scene.BackColor = System.Drawing.SystemColors.ControlLight;
            this.scene.Controls.Add(this.explode);
            this.scene.Controls.Add(this.ball);
            this.scene.Location = new System.Drawing.Point(12, 12);
            this.scene.Name = "scene";
            this.scene.Size = new System.Drawing.Size(776, 378);
            this.scene.TabIndex = 2;
            this.scene.Click += new System.EventHandler(this.scene_Click);
            // 
            // lMisses
            // 
            this.lMisses.AutoSize = true;
            this.lMisses.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lMisses.Location = new System.Drawing.Point(311, 399);
            this.lMisses.Name = "lMisses";
            this.lMisses.Size = new System.Drawing.Size(132, 20);
            this.lMisses.TabIndex = 2;
            this.lMisses.Text = "Пойман с 0 раза";
            this.lMisses.Visible = false;
            // 
            // explode
            // 
            this.explode.Image = global::HomeWork7.Properties.Resources.hotpng1;
            this.explode.Location = new System.Drawing.Point(711, 0);
            this.explode.Name = "explode";
            this.explode.Size = new System.Drawing.Size(65, 64);
            this.explode.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.explode.TabIndex = 1;
            this.explode.TabStop = false;
            this.explode.Visible = false;
            // 
            // ball
            // 
            this.ball.Image = global::HomeWork7.Properties.Resources.hotpng_com;
            this.ball.InitialImage = ((System.Drawing.Image)(resources.GetObject("ball.InitialImage")));
            this.ball.Location = new System.Drawing.Point(458, 92);
            this.ball.Name = "ball";
            this.ball.Size = new System.Drawing.Size(32, 32);
            this.ball.TabIndex = 0;
            this.ball.TabStop = false;
            this.ball.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ball_MouseDown);
            // 
            // tbSpeed
            // 
            this.tbSpeed.Location = new System.Drawing.Point(132, 398);
            this.tbSpeed.Name = "tbSpeed";
            this.tbSpeed.Size = new System.Drawing.Size(27, 20);
            this.tbSpeed.TabIndex = 3;
            this.tbSpeed.Text = "7";
            this.tbSpeed.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbSpeed_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(12, 399);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 17);
            this.label1.TabIndex = 5;
            this.label1.Text = "Скорость мяча: ";
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 427);
            this.Controls.Add(this.lMisses);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbSpeed);
            this.Controls.Add(this.scene);
            this.Controls.Add(this.btnPlay);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "mainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Поймай меня";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.mainForm_FormClosed);
            this.Load += new System.EventHandler(this.mainForm_Load);
            this.scene.ResumeLayout(false);
            this.scene.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.explode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ball)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox ball;
        private System.Windows.Forms.Button btnPlay;
        private System.Windows.Forms.Timer leftTimer;
        private System.Windows.Forms.Timer downTimer;
        private System.Windows.Forms.Timer rightTimer;
        private System.Windows.Forms.Timer upTimer;
        private System.Windows.Forms.Panel scene;
        private System.Windows.Forms.TextBox tbSpeed;
        private System.Windows.Forms.PictureBox explode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lMisses;
    }
}

