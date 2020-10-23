using Home.Commands;
using strange.extensions.dispatcher.eventdispatcher.api;
using strange.extensions.mediation.impl;
using UnityEngine;

namespace Home
{
    class DifficaltyMenuMediator : EventMediator
    {
        [Inject]
        public DifficaltyMenuView view { get; set; }

        public override void OnRegister()
        {
            base.OnRegister();
            view.dispatcher.AddListener(DifficaltyMenuView.DIFICALTY, OnDifficalty);
            dispatcher.AddListener(HomeCommands.START, OnStart);
            view.Hide();
        }

        public override void OnRemove()
        {
            base.OnRemove();
            view.dispatcher.RemoveListener(DifficaltyMenuView.DIFICALTY, OnDifficalty);
            dispatcher.RemoveListener(HomeCommands.START, OnStart);
        }

        private void OnDifficalty(IEvent payload)
        {
            dispatcher.Dispatch(HomeCommands.SET_DIFFICALTY, payload.data);
        }

        private void OnStart(IEvent payload)
        {
            view.Show();
        }
    }
}
