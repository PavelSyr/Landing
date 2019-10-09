using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class ModuleView : MonoBehaviour
    {
        [SerializeField]
        private SpriteRenderer spRenderer;

        [SerializeField]
        private Sprite GoodView;

        [SerializeField]
        private Sprite BadView;

        public void ShowGoodView()
        {
            spRenderer.sprite = GoodView;
        }

        public void ShowBadView()
        {
            spRenderer.sprite = BadView;
        }
    }
}
