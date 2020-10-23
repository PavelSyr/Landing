using strange.extensions.dispatcher.eventdispatcher.api;
using strange.extensions.mediation.impl;

namespace Home
{
    class MainMenuView : View
    {
        public const string START = "Home.MainMenuView.START";

        [Inject]
        public IEventDispatcher dispatcher { get; set; }

        public void OnStartButtonClick()
        {
            dispatcher.Dispatch(START);
        }

        public void Show()
        {
            gameObject.SetActive(true);
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }
    }
}
