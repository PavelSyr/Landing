using strange.extensions.dispatcher.eventdispatcher.api;
using strange.extensions.mediation.impl;

namespace Game
{
    class InputViewMediator : EventMediator
    {
        public const string CLICK = "CLICK";

        [Inject]
        public InputView view { get; set; }

        public override void OnRegister()
        {
            base.OnRegister();
            view.Init();

            view.dispatcher.AddListener(InputView.CLICK, OnClick);
        }

        public override void OnRemove()
        {
            base.OnRemove();
            view.dispatcher.RemoveListener(InputView.CLICK, OnClick);
        }

        private void OnClick(IEvent payload)
        {
            dispatcher.Dispatch(CLICK, payload.data);
        }
    }
}
