using System;
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
            var leadPlayerName = this._firstPlayerScoreTimes > this._secondPlayerScoreTimes ? "FirstPlayer" : "SecondPlayer";
            var leadScoreTimes = this._firstPlayerScoreTimes > this._secondPlayerScoreTimes ? this._firstPlayerScoreTimes : this._secondPlayerScoreTimes;
            var behindScoreTimes = this._firstPlayerScoreTimes > this._secondPlayerScoreTimes ? this._secondPlayerScoreTimes : this._firstPlayerScoreTimes;

            if (IsSameScore())
            {
                return IsDesue() ? "Deuse" : $"{ _scoreLookup[this._secondPlayerScoreTimes] } All";
            }

            if (IsAdv(leadScoreTimes))
            {
                return $"{leadPlayerName} { (IsWin(leadScoreTimes, behindScoreTimes) ? "Win" : "Adv") }";
            }

            if (this._firstPlayerScoreTimes > 0)
            {
                return $"{ _scoreLookup[this._firstPlayerScoreTimes] } Love";
            }

            if (this._secondPlayerScoreTimes > 0)
            {
                return $"Love { _scoreLookup[this._secondPlayerScoreTimes] }";
            }

            return "";
        }

        private static bool IsWin(int leadScoreTimes, int behindScoreTimes)
        {
            return (leadScoreTimes == 4 && behindScoreTimes == 0) || (leadScoreTimes - behindScoreTimes == 2);
        }

        private bool DifferentScore(int leadScoreTimes)
        {
            return !IsSameScore() && leadScoreTimes > 0;
        }

        private bool IsAdv(int leadScoreTimes)
        {
            return !IsSameScore() && leadScoreTimes > 3;
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