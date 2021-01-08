using System;
using System.Collections.Generic;

namespace TennisGame.Library
{
    public class TennisGame
    {
        private int _firstPlayerScoreTimes = 0;

        public TennisGame()
        {

        }

        public string Score()
        {
            Dictionary<int, string> scoreLookup = new Dictionary<int, string>()
            {
                { 1,"Fifteen" },
                { 2,"Thirty" },
                { 3,"Forty" }

            };

            if (this._firstPlayerScoreTimes > 0)
            {
                return $"{ scoreLookup[this._firstPlayerScoreTimes] } Love";
            }
            return "Love All";
        }

        public void FirstPlayerScore()
        {
            this._firstPlayerScoreTimes++;
        }
    }
}