using System;

namespace TennisGame.Library
{
    public class TennisGame
    {
        private int _firstPlayerScore = 0;
        public TennisGame()
        {
        }

        public string Score()
        {
            if(this._firstPlayerScore > 0)
            {
                return "Fifteen Love";
            }
            return "Love All";
        }

        public void FirstPlayerScore()
        {
            this._firstPlayerScore++;
        }
    }
}