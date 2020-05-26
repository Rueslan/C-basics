using HomeWork7.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WMPLib;

namespace HomeWork7
{
    public partial class mainForm : Form
    {
        public int speed = 0;
        public int misses = 0;
        public WMPLib.WindowsMediaPlayer WMP = new WMPLib.WindowsMediaPlayer();
        public bool isPlay;
        public bool isGameOver;
        public bool toTop, toBottom = true, toLeft, toRight = true;
        public mainForm()
        {
            InitializeComponent();            
        }

        public void resetBall()
        {
            explode.Visible = false;
            ball.Visible = true;
            toLeft = false;
            toTop = false;
            toRight = true;
            toBottom = true;
        }

        private void startNewGame()
        {
            btnPlay.Text = "Пауза";
            isGameOver = false;
            isPlay = true;
            lMisses.Visible = false;
            misses = 0;
            resetBall();
            loadDirection();
        }

        private void setBallSpeed()
        {
            speed = Int32.Parse(tbSpeed.Text);

        }
        
        private void playCollideSound()
        {
            using (SoundPlayer soundPlayer = new SoundPlayer())//AppDomain.CurrentDomain.BaseDirectory + "ballCollide.wav"))
            {
                soundPlayer.Stream = Properties.Resources.ballCollide;
                soundPlayer.Play();
            }
        }

        private void gameOver()
        {
            upTimer.Stop();
            leftTimer.Stop();
            downTimer.Stop();
            rightTimer.Stop();
            ball.Visible = false;
            explode.Top = (ball.Top - explode.Height / 2 + ball.Height / 2);
            explode.Left = (ball.Left - explode.Width / 2 + ball.Width / 2);
            explode.Visible = true;
            toRight = false;
            toBottom = false;
            toLeft = false;
            toTop = false;
            isGameOver = true;
            isPlay = false;
            lMisses.Text = $"Пойман с {misses + 1} раза!";
                lMisses.Visible = true;
            btnPlay.Text = "Новая игра";
        }

        private void pauseGame()
        {
            saveDirection();
            btnPlay.Text = "Продолжить";
            upTimer.Enabled = false;
            leftTimer.Enabled = false;
            downTimer.Enabled = false;
            rightTimer.Enabled = false;
            isPlay = false;
        }

        private void resumeGame()
        {
            loadDirection();
            btnPlay.Text = "Пауза";
            isPlay = true;
        }

        private void saveDirection()
        {
            if (upTimer.Enabled)
            {
                toTop = true;
                upTimer.Enabled = false;
            }
            if (leftTimer.Enabled)
            {
                toLeft = true;
                leftTimer.Enabled = false;
            }
            if (downTimer.Enabled)
            {
                toBottom = true;
                downTimer.Enabled = false;
            }
            if (rightTimer.Enabled)
            {
                toRight = true;
                rightTimer.Enabled = false;
            }
        }

        private void loadDirection()
        {
            if (toBottom)
                downTimer.Start();
            if (toTop)
                upTimer.Start();
            if (toLeft)
                leftTimer.Start();
            if (toRight)
                rightTimer.Start();
        }

        private void leftTimer_Tick_1(object sender, EventArgs e)
        {
            if (ball.Left >= 0)
            {
                ball.Left -= speed;
                toLeft = true;
                
            }
            else
            {
                playCollideSound();
                toLeft = false;
                rightTimer.Start();
                leftTimer.Stop();
            }
                
        }

        private void rightTimer_Tick_1(object sender, EventArgs e)
        {
            if ((ball.Left + ball.Width) <= scene.Width)
            {
                ball.Left += speed;
                toRight = true;
            }
            else
            {
                playCollideSound();
                toRight = false;
                leftTimer.Start();
                rightTimer.Stop();
            }
            
        }

        private void downTimer_Tick_1(object sender, EventArgs e)
        {
            if ((ball.Top + ball.Height) <= scene.Height)
            {
                ball.Top += speed;
                toBottom = true;
            }
            else
            {
                playCollideSound();
                toBottom = false;
                upTimer.Start();
                downTimer.Stop();
            }
            
        }        

        private void upTimer_Tick_1(object sender, EventArgs e)
        {
            if ((ball.Top >= 0))
            {
                ball.Top -= speed;
                toTop = true;
            }
            else
            {
                playCollideSound();
                toTop = false;
                downTimer.Start();
                upTimer.Stop();
            }
            
        }

        private void scene_Click(object sender, EventArgs e)
        {
            if (isPlay)
            {
                misses++;
            }            
        }

        private void tbSpeed_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsDigit(number))
            {
                e.Handled = true;
            }
        }

        private void mainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            WMP.close();
        }

        private void mainForm_Load(object sender, EventArgs e)
        {
            WMP.URL = AppDomain.CurrentDomain.BaseDirectory + "bkg.wav";
            WMP.settings.setMode("loop", true);
            WMP.controls.play();
            
        }

        private void ball_MouseDown(object sender, MouseEventArgs e)
        {
            if (isPlay)
            {
                using (SoundPlayer soundPlayer = new SoundPlayer())
                {
                    soundPlayer.Stream = Properties.Resources.Sound_blow;
                    soundPlayer.Play();
                }
                gameOver();
            }
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            setBallSpeed();
            if (isGameOver)
            {
                startNewGame();
                return;
            }
            else if (isPlay)   
                pauseGame();
            else 
                resumeGame();            
        }
    }
}
