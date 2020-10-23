using UnityEngine;
using System.Collections;
using System;

namespace Models
{
    public class Model
    {
        public bool IsWin { get; private set; }
        public float Score { get; private set; }
        public int Difficulty { get; private set; }

        public Model()
        {
        }

        public void SetDifficulty(int value)
        {
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