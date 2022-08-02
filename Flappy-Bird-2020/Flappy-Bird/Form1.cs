using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Flappy_Bird
{
    public partial class Form1 : Form
    {
        int pipeSpeed = 5; // initalize pipe speed
        int gravity = 15; // initalize gravity speed 
        int score = 0; // initalize score = 0
        




        public Form1()
        {
            InitializeComponent();
            Game_menu.Hide();//Hide menu
            high_score.Text = Properties.Settings.Default.h_score;//show the current high score 
        }


        
        private void gameTimerEvent(object sender, EventArgs e)
        {
            flappyBird.Top += gravity;
            pipeBottom.Left -= pipeSpeed; // reduce the pipe speed value from the left position of the pipe picture box so it will move left with each tick
            pipeTop.Left -= pipeSpeed; // the same is happening with the top pipe
            scoreText.Text = "Score: " + score; // show the current score 

            if (pipeBottom.Left < -150)
            {
                // if the bottom pipes location is -150 then we will reset it back to 800 and add 1 to the score
                pipeBottom.Left = 800;
                score++;
                
            }
            if (pipeTop.Left < -180)
            {
                // if the top pipe location is -180 then we will reset the pipe back to the 950 and add 1 to the score
                pipeTop.Left = 950;
                score++;
              
            }
            // pipe speed increase every 5 score
            if (score % 5 == 0 && score != 0)
            {
                pipeSpeed += 1;
            }
            if (flappyBird.Bounds.IntersectsWith(pipeBottom.Bounds) ||
                flappyBird.Bounds.IntersectsWith(pipeTop.Bounds) ||
                flappyBird.Bounds.IntersectsWith(ground.Bounds) || flappyBird.Top < -25
                )
            {
               
                // end game function
                endGame();
                
            }
            

            
            




        }


        private void gamekeyisup(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                // if the space key is released then gravity is set back to 15
                gravity = 15;
            }
        }
        private void endGame()
        {
            // this is the game end function, this function will when the bird touches the ground or the pipes
            gameTimer.Stop(); // stop the main timer
            int a = Int32.Parse(high_score.Text);
            if (score > a)
            {
                high_score.Text = score.ToString();
                Properties.Settings.Default.h_score = high_score.Text;
                Properties.Settings.Default.Save();
            }
            scoreText2.Text += " Game over!!!"; // show the game over text on the score text
            Game_menu.Show();//Show menu
            
        }

        private void gamekeyisdown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                // if the space key is released then gravity is set back to 15
                gravity = -15;
            }
        }

        private void Restart_game(object sender, MouseEventArgs e)
        {
            Application.Restart();// game restart with 1 click
        }

        private void Quit_game(object sender, MouseEventArgs e)
        {
            Application.Exit();//game exit without double click
        }

    }

}
