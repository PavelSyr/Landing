using Game.Commands;
using strange.extensions.dispatcher.eventdispatcher.api;
using strange.extensions.mediation.impl;
using System;
using System.Diagnostics;

namespace Game
{
    class ModuleViewMediator : EventMediator
    {
        [Inject]
        public ModuleView view { get; set; }

        public override void OnRegister()
        {
            base.OnRegister();
            dispatcher.AddListener(InputViewMediator.CLICK, OnClick);
            dispatcher.AddListener(CollisionMediator.GOOD_COLLISION, OnGoodCollision);
            dispatcher.AddListener(CollisionMediator.BAD_COLLISION, OnBadCollistion);
        }

        public override void OnRemove()
        {
            base.OnRemove();
            dispatcher.RemoveListener(InputViewMediator.CLICK, OnClick);
            dispatcher.RemoveListener(CollisionController.GOOD_COLLISION, OnGoodCollision);
            dispatcher.RemoveListener(CollisionController.BAD_COLLISION, OnBadCollistion);
        }

        private void OnClick(IEvent payload)
        {
            view.UP();
        }

        private void OnBadCollistion(IEvent payload)
        {
            UnityEngine.Debug.Log("Bad ccclsion");
            view.ShowBadView();
            dispatcher.Dispatch(GameCommands.BAD_LANDING);
        }

        private void OnGoodCollision(IEvent payload)
        {
            UnityEngine.Debug.Log("Good ccclsion");
            view.ShowGoodView();
            dispatcher.Dispatch(GameCommands.GOOD_LANDING);
        }
    }
}
