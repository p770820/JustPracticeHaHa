﻿using System;
using System.Collections.Generic;

namespace TennisGame.Library
{
    public class TennisGame
    {
        private int _firstPlayerScoreTimes = 0;
        private int _secondPlayerScoreTimes = 0;

        public TennisGame()
        {

        }

        public string Score()
        {
            Dictionary<int, string> scoreLookup = new Dictionary<int, string>()
            {
                { 0, "Love" },
                { 1, "Fifteen" },
                { 2, "Thirty" },
                { 3, "Forty" }
            };

            if (this._firstPlayerScoreTimes == this._secondPlayerScoreTimes)
            {
                if (this._firstPlayerScoreTimes > 2)
                {
                    return "Deuse";
                }

                return $"{ scoreLookup[this._secondPlayerScoreTimes] } All";
            }

            if (this._firstPlayerScoreTimes == 4 && this._secondPlayerScoreTimes == 0)
            {
                return $"FirstPlayer Win";
            }

            if (this._secondPlayerScoreTimes > 3)
            {
                return $"SecondPlayer Adv";
            }

            if (this._firstPlayerScoreTimes > 3)
            {
                return $"FirstPlayer Adv";
            }

            if (this._firstPlayerScoreTimes > 0)
            {
                return $"{ scoreLookup[this._firstPlayerScoreTimes] } Love";
            }

            if (this._secondPlayerScoreTimes > 0)
            {
                return $"Love { scoreLookup[this._secondPlayerScoreTimes] }";
            }

            return "Love All";
        }

        public void FirstPlayerScore()
        {
            this._firstPlayerScoreTimes++;
        }

        public void SecondPlayerScore()
        {
            this._secondPlayerScoreTimes++;
        }
    }
}