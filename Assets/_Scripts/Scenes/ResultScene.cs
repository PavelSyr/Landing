using Common;
using Firebase.Analytics;
using UnityEngine;

namespace Scenes
{
    public class ResultScene : BaseScene
    {
        private enum State { Win, Lose };
        private State state;

        [SerializeField]
        private GameObject LoseView;
        [SerializeField]
        private GameObject WinView;
        
        protected override void Initialisation()
        {
            base.Initialisation();
            FirebaseAnalytics.LogEvent(FirebaseAnalytics.EventLevelEnd);

            //if (Model.Instance.IsWin)
            //{
            //    SetState(State.Win);
            //}
            //else
            //{
            //    SetState(State.Lose);
            //}
        }

        protected override void GoToNextScene()
        {
            SceneNavigation.GoToHome();
        }

        protected override void GoToPrevScene()
        {
            SceneNavigation.GoToGame();
        }

        private void SetState (State value)
        {
            state = value;
            switch (state)
            {
                case State.Lose:
                    ShowLose();
                    break;
                case State.Win:
                    ShowWin();
                    break;
            }
        }

        private void ShowWin()
        {
            //FirebaseAnalytics.LogEvent("Win", "Difficalty", Model.Instance.Difficulty);
            LoseView.SetActive(false);
            WinView.SetActive(true);
        }

        private void ShowLose()
        {
            //FirebaseAnalytics.LogEvent("Lose", "Difficalty", Model.Instance.Difficulty);
            LoseView.SetActive(true);
            WinView.SetActive(false);
        }

        public void RestartButton_OnClick()
        {
            FirebaseAnalytics.LogEvent("RestartButton_OnClick");
            GoToPrevScene();
        }

        public void HomeButton_OnClick()
        {
            FirebaseAnalytics.LogEvent("HomeButton_OnClick");
            GoToNextScene();
        }
    }
}
