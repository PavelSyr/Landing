using strange.extensions.mediation.impl;
using UnityEngine;

namespace Game
{
    public class CollisionController : EventView
    {
        public static string GOOD_COLLISION = "GOOD_COLLISION";
        public static string BAD_COLLISION = "BAD_COLLISION";

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
                Debug.Log("Bad collision");
                dispatcher.Dispatch(BAD_COLLISION);
            }
            else
            {
                Debug.Log("Good collision");
                dispatcher.Dispatch(GOOD_COLLISION);
            }
        }
    }
}
