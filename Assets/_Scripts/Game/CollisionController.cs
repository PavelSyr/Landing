using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Game
{
    public class CollisionController : MonoBehaviour
    {
        public event Action OnGoodCollision;
        public event Action OnBadCollision;

        [SerializeField]
        private Vector2 MaxVelocity = new Vector2(0.2f, 1);

        [SerializeField]
        private float Threshold = 1f;

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (!enabled) return;

            float dist = Vector2.Distance(collision.relativeVelocity, MaxVelocity);

            if (dist > Threshold)
            {
                if (OnBadCollision != null)
                    OnBadCollision();
            }
            else
            {
                if (OnGoodCollision != null)
                    OnGoodCollision();
            }
        }
    }
}
