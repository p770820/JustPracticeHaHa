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
            return IsSameScore() ? (IsDesue() ? DeuseResult() : SameScoreResult())
                : (IsAdv() ? AdvOrWinResult() : DifferentScoreResult());
        }

        private int GetBehindScoreTimes()
        {
            return IsFirstPlayerLeadSecondPlayer() ? this._secondPlayerScoreTimes : this._firstPlayerScoreTimes;
        }

        private int GetLeadScoreTimes()
        {
            return IsFirstPlayerLeadSecondPlayer() ? this._firstPlayerScoreTimes : this._secondPlayerScoreTimes;
        }

        private bool IsFirstPlayerLeadSecondPlayer()
        {
            return this._firstPlayerScoreTimes > this._secondPlayerScoreTimes;
        }

        private string SameScoreResult()
        {
            return $"{ _scoreLookup[this._secondPlayerScoreTimes] } All";
        }

        private string DeuseResult()
        {
            return "Deuse";
        }

        private string DifferentScoreResult()
        {
            return $"{ _scoreLookup[this._firstPlayerScoreTimes] } { _scoreLookup[this._secondPlayerScoreTimes] }";
        }

        private string AdvOrWinResult()
        {
            return $"{ GetLeadPlayerName() } { (IsWin(GetLeadScoreTimes(), GetBehindScoreTimes()) ? "Win" : "Adv") }";
        }

        private string GetLeadPlayerName()
        {
            return (IsFirstPlayerLeadSecondPlayer() ? "FirstPlayer" : "SecondPlayer");
        }

        private bool IsWin(int leadScoreTimes, int behindScoreTimes)
        {
            return (leadScoreTimes == 4 && behindScoreTimes == 0) || (leadScoreTimes - behindScoreTimes == 2);
        }

        private bool IsAdv()
        {
            return !IsSameScore() && GetLeadScoreTimes() > 3;
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