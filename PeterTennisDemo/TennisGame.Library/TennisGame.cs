using System;
using System.Collections.Generic;

namespace TennisGame.Library
{
    public class TennisGame
    {
        private int _firstPlayerScoreTimes = 0;
        private Dictionary<int, string> _scoreDic = new Dictionary<int, string>();
        public TennisGame()
        {
            this._scoreDic.Add(1, "Fifteen Love");
            this._scoreDic.Add(2, "Thirty Love");
        }

        public string Score()
        {
            if(this._firstPlayerScoreTimes > 0)
            {
                return this._scoreDic[this._firstPlayerScoreTimes];
            }
            return "Love All";
        }

        public void FirstPlayerScore()
        {
            this._firstPlayerScoreTimes++;
        }
    }
}