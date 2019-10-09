using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class EnginesController : MonoBehaviour
    {
        [SerializeField]
        private ParticleSystem Left;
        [SerializeField]
        private ParticleSystem Right;
        [SerializeField]
        private ParticleSystem Top;
        [SerializeField]
        private ParticleSystem Bottom;


        public void SwitchLeft()
        {
            PlayPS(Left);
        }

        public void SwitchRight()
        {
            PlayPS(Right);
        }

        public void SwitchTop()
        {
            PlayPS(Top);
        }

        public void SwitchBottom()
        {
            PlayPS(Bottom);
        }

        private void PlayPS(ParticleSystem ps)
        {
            ps.Emit(5);
        }
    }
}
