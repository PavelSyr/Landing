using strange.extensions.dispatcher.eventdispatcher.api;
using strange.extensions.mediation.impl;
using System;
using UnityEngine;

namespace Game
{
    public class ModuleView : EventView
    {
#pragma warning disable 0649
        [SerializeField]
        private ForceController forceController;

        [SerializeField]
        private EnginesController enginesController;

        [SerializeField]
        private SpriteRenderer spRenderer;

        [SerializeField]
        private Sprite GoodView;

        [SerializeField]
        private Sprite BadView;
#pragma warning restore 0649

        public void ShowGoodView()
        {
            spRenderer.sprite = GoodView;
        }

        public void ShowBadView()
        {
            spRenderer.sprite = BadView;
        }

        internal void UP()
        {
            enginesController.SwitchBottom();
            forceController.Up();
        }
    }
}
