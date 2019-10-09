using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class FuelController : MonoBehaviour
    {
        public event Action OnFuelIsEmptyEvent;

        private float _total;
        private float _cost;

        public float Total { get { return _total; } }
        public bool IsEmpty { get { return _total <= 0; } }

        public void Init(float cost)
        {
            _total = 1;
            _cost = cost;
        }

        public void Spend()
        {
            _total -= _cost;
            if (IsEmpty && OnFuelIsEmptyEvent != null)
            {
                OnFuelIsEmptyEvent();
            }
        }

    }
}