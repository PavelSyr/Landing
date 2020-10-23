using strange.extensions.dispatcher.eventdispatcher.api;
using strange.extensions.mediation.impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home
{
    class DifficaltyMenuView : View
    {
        public const string DIFICALTY = "Home.DifficaltyMenuView.DIFICALTY";

        [Inject]
        public IEventDispatcher dispatcher { get; set; }

        public void Show()
        {
            gameObject.SetActive(true);
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }

        public void OnDifficaltyButtonClick(int difficalty)
        {
            dispatcher.Dispatch(DIFICALTY, difficalty);
        }
    }
}
