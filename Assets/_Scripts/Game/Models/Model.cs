using UnityEngine;
using System.Collections;
using System;

namespace Game.Models
{
    public class Model
    {
        private static Model _inst;

        public static Model Instance
        {
            get
            {
                if (_inst == null)
                {
                    _inst = new Model();
                }
                return _inst;
            }
        }


        public bool IsWin { get; private set; }
        public float Score { get; private set; }
        public int Difficulty { get; private set; }

        private Model()
        {
        }

        public void SetDifficulty(int value)
        {
            Firebase.Analytics.FirebaseAnalytics.LogEvent("SetDifficulty", "value", value);
            Difficulty = value;
        }

        public void SetResults(bool isWin, float score)
        {
            IsWin = isWin;
            Score = score;
        }

        public void Reset()
        {
            IsWin = false;
            Score = 0;
        }
    }
}