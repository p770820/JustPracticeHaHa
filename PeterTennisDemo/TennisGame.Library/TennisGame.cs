﻿using System;
using System.Collections.Generic;

namespace TennisGame.Library
{
    public class TennisGame
    {
        private int _firstPlayerScoreTimes = 0;
        private int _secondPlayerScoreTimes = 0;
        private Dictionary<int, string> _scoreLookup = new Dictionary<int, string>()
            {
                { 0, "Love" },
                { 1, "Fifteen" },
                { 2, "Thirty" },
                { 3, "Forty" }
            };

        public TennisGame()
        {

        }

        public string Score()
        {
            var leadPlayerName = "";
            if (this._firstPlayerScoreTimes > this._secondPlayerScoreTimes)
            {
                leadPlayerName = "FirstPlayer";
                if (this._firstPlayerScoreTimes > 3)
                {
                    if (this._firstPlayerScoreTimes == 4 && this._secondPlayerScoreTimes == 0)
                    {
                        return $"{leadPlayerName} Win";
                    }

                    if (this._firstPlayerScoreTimes - this._secondPlayerScoreTimes == 2)
                    {
                        return $"{leadPlayerName} Win";
                    }
                    return $"{leadPlayerName} Adv";
                }

                if (this._firstPlayerScoreTimes > 0)
                {
                    return $"{ _scoreLookup[this._firstPlayerScoreTimes] } Love";
                }
            }
            else if (this._secondPlayerScoreTimes > this._firstPlayerScoreTimes)
            {
                leadPlayerName = "SecondPlayer";
                if (this._secondPlayerScoreTimes > 3)
                {
                    if (this._secondPlayerScoreTimes - this._firstPlayerScoreTimes == 4)
                    {
                        return $"{leadPlayerName} Win";
                    }

                    if (this._secondPlayerScoreTimes - this._firstPlayerScoreTimes == 2)
                    {
                        return $"{leadPlayerName} Win";
                    }

                    return $"{leadPlayerName} Adv";
                }

                if (this._secondPlayerScoreTimes > 0)
                {
                    return $"Love { _scoreLookup[this._secondPlayerScoreTimes] }";
                }
            }
            else
            {
                return IsDesue() ? "Deuse" : $"{ _scoreLookup[this._secondPlayerScoreTimes] } All";
            }
            return "";
        }

        private bool IsDesue()
        {
            return IsSameScore() && this._firstPlayerScoreTimes > 2;
        }

        private bool IsSameScore()
        {
            return this._firstPlayerScoreTimes == this._secondPlayerScoreTimes;
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