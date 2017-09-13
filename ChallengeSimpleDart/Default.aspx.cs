using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Darts;

namespace ChallengeSimpleDart
{   
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void startButton_Click(object sender, EventArgs e)
        {
            Player playerOne = new Player
            {
                score = 0
            };
            Player playerTwo = new Player
            {
                score = 0
            };

            Dart toss = new Dart();
            Random random = new Random();
            int throwTotal = 0;
            int scoreCurrent = 0;


            Game(toss, random, playerOne, playerTwo, throwTotal, scoreCurrent);
        }

        public class Player
        {
            public int score;
        }

        public int Game(Dart toss, Random random, Player playerOne, Player playerTwo, int throwTotal, int scoreCurrent)
        {
            while (playerOne.score < 300 && playerTwo.score < 300)
            {
                throwTotal = toss.Throw(random);
                Odds(throwTotal, random, out scoreCurrent);
                playerOne.score = playerOne.score + scoreCurrent;

                if (playerOne.score >= 300)
                {
                    Results(playerOne, playerTwo);
                    return 0;
                }

                throwTotal = toss.Throw(random);
                Odds(throwTotal, random, out scoreCurrent);
                playerTwo.score = playerTwo.score + scoreCurrent;

                if (playerTwo.score >= 300)
                {
                    Results(playerOne, playerTwo);
                    return 0;
                }
            }
            return 0;
        }

        public int Odds(int throwTotal, Random random, out int scoreCurrent)
        {
            if (throwTotal == 0)
            {
                int odds = random.Next(0, 2);
                if (odds == 0)
                {
                    return scoreCurrent = 50;
                }
                else
                {
                    return scoreCurrent = 25;
                }
            }
            else
            {
                int odds = random.Next(1, 21);
                if (odds == 1)
                {
                    return scoreCurrent = throwTotal * 2;
                }
                else if (odds == 20)
                {
                    return scoreCurrent = throwTotal * 3;
                }
                else return scoreCurrent = throwTotal;
            }
        }

        public string Results(Player playerOne, Player playerTwo)
        {
            return resultLabel.Text = String.Format("Player 1: " + playerOne.score.ToString() + "<br>" + "Player 2: " + playerTwo.score.ToString() + "<br><br>");
        }
    }
}