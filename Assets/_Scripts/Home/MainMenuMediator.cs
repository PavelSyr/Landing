using Home.Commands;
using strange.extensions.dispatcher.eventdispatcher.api;
using strange.extensions.mediation.impl;

namespace Home
{
    class MainMenuMediator : EventMediator
    {
        [Inject]
        public MainMenuView view { get; set; }

        public override void OnRegister()
        {
            base.OnRegister();
            view.dispatcher.AddListener(MainMenuView.START, OnStart);
        }

        public override void OnRemove()
        {
            base.OnRemove();
            view.dispatcher.RemoveListener(MainMenuView.START, OnStart);
        }

        private void OnStart(IEvent payload)
        {
            view.Hide();
            dispatcher.Dispatch(HomeCommands.START);
        }
    }
}
