using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RaceGamewithBet
{
    public partial class Form1 : Form
    {
        //global variable that is used topeform the task of the race from starting to end 
        int player1 = 80, player2 = 60, player3 = 100, betAmount1 = 0, betAmount2 = 0, betAmount3 = 0;
        int choosedog1 = 0, choosedog2 = 0, choosedog3 = 0;
        int frstPlayer = 0, secndPlayer = 0, thrdPlayer = 0, winnerDog = 0;

        //object of the Random class to move the dog from one location to another 
        Random rd = new Random();
        Player1 p1 = new Player1();
        player2 p2 = new player2();
        Player3 p3 = new Player3();

        // find the winner of the game by using the concept of the conditional statement 
        public void winner() {
            MessageBox.Show("dog " + winnerDog + " won the Race");
            if (frstPlayer == 1 && choosedog1 == winnerDog)
            {
                player1 = player1 + betAmount1;
                Player1.Text = "Sandy has " + player1 + " Dollar";

                timer1.Enabled = false;

            }
            else if (frstPlayer == 1 && choosedog1 != winnerDog)
            {
                player1 = player1 - betAmount1;
                Player1.Text = "Sandy has " + player1 + " Dollar";
                timer1.Enabled = false;
            }

            if (secndPlayer == 1 && choosedog2 == winnerDog)
            {
                player2 = player2 + betAmount2;
                Player2.Text = "Akshit has " + player2 + " Dollar";

                timer1.Enabled = false;
            }
            else if (secndPlayer == 1 && choosedog2 != winnerDog)
            {
                player2 = player2 + betAmount2;
                Player2.Text = "Akshit has " + player2 + " Dollar";
                timer1.Enabled = false;
            }
            if (thrdPlayer == 1 && choosedog3 == winnerDog)
            {

                player3 = player3 + betAmount3;
                Player3.Text = "Kuldeep has " + player3 + " Dollar";
                timer1.Enabled = false;
            }
            else if (thrdPlayer == 1 && choosedog3 != winnerDog)
            {
                player3 = player3 + betAmount3;
                Player3.Text = "Kuldeep has " + player3 + " Dollar";
                timer1.Enabled = false;
            }

            reply();
        }
        
        // to restart the whole game once again 

        public void reply() {
            choosedog1 = 0; choosedog2 = 0; choosedog3 = 0;
            betAmount1 = 0;betAmount2 = 0;betAmount3 = 0;

            frstPlayer = 0; secndPlayer = 0; thrdPlayer = 0; winnerDog = 0;
            playerBet1.Text = "Player1";
            Playerbet2.Text = "Player2";
            Playerbet3.Text = "Player3";
            dog1.Left = 0;
            dog2.Left = 0;
            dog3.Left = 0;
            txtPlayer.Text = "";
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            /// move the dog from one location to another y using the random class object and the function of the class
            dog1.Left = dog1.Left +p1.run();
            dog2.Left = dog2.Left + p2.run();
            dog3.Left = dog3.Left + p3.run();

            if (dog1.Left >= 870)
            {

                // pass  the winner dog value to the global variable and clalling the winner method
                winnerDog = 1;
                timer1.Stop();
                winner();
                btnStart.Enabled = false;
            }
            else if (dog2.Left >= 870)
            {
                // pass  the winner dog value to the global variable and clalling the winner method
                winnerDog = 2;
                timer1.Stop();
                winner();
                btnStart.Enabled = false;
            }
           else if (dog3.Left >= 870)
            {
                // pass  the winner dog value to the global variable and clalling the winner method
                winnerDog = 3;
                timer1.Stop();
                winner();
                btnStart.Enabled = false;
            }
           



        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            //generate the fire sound to start the game of the race
            System.Media.SoundPlayer player = new System.Media.SoundPlayer("fire.wav");
            player.Play();
            timer1.Start();

        }

        
        public Form1()
        {
            InitializeComponent();
            MessageBox.Show("Read the Instruction to Start the Game first \n  the game bet is starting from minimum 9 dollar \n so you can put the bet greater than or equal to 9 dolllar ");
            btnStart.Enabled = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnBet_Click(object sender, EventArgs e)
        {
            // code to set the player name and choose the bet amount with the best suitable amount depends upon the cindition wether  the condition is true then the block will execute otherwise the error message will be generated 
            if (txtPlayer.Text.ToString().Equals("Sandy") && Convert.ToInt32(nmAmount.Value) <= player1 && Convert.ToInt32(nmAmount.Value) > 8)
            {
                
                betAmount1 = Convert.ToInt32(nmAmount.Value);
                choosedog1 = Convert.ToInt32(nmDog.Value);
                playerBet1.Text = "Sandy choose the " + choosedog1 + " with Bet Amount of " + betAmount1;
                frstPlayer = 1;
                btnStart.Enabled = true;
            }
            else if (txtPlayer.Text.ToString().Equals("Akshit") && Convert.ToInt32(nmAmount.Value) <= player2 && Convert.ToInt32(nmAmount.Value) > 8)
            {
                
                betAmount2 = Convert.ToInt32(nmAmount.Value);
                choosedog2 = Convert.ToInt32(nmDog.Value);
                Playerbet2.Text = "Akshit Choose the " + choosedog2 + " with the Bet Amount of " + betAmount2;
                secndPlayer = 1;
                btnStart.Enabled = true;
            }
            else if (txtPlayer.Text.ToString().Equals("Kuldeep") && Convert.ToInt32(nmAmount.Value) <= player3 && Convert.ToInt32(nmAmount.Value) > 8)
            {
                
                betAmount3 = Convert.ToInt32(nmAmount.Value);
                choosedog3 = Convert.ToInt32(nmDog.Value);
                Playerbet3.Text = "Kuldeep Choose the " + choosedog3 + " with the Bet Amount of " + betAmount3;
                thrdPlayer = 1;
                btnStart.Enabled = true;
            }
            else {
                MessageBox.Show("fill the Suitable Player Name or Suitable Amount ");
            }

        }

    }
}
