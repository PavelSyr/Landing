using Home;
using UnityEngine;

namespace Scenes
{
    public class HomeScene : BaseScene
    {
        protected override void Initialisation()
        {
            base.Initialisation();
            context = new HomeContext(this);

            //ShowMainMenu();
        }

        public void GoButton_OnClick()
        {
            ShowDifficaltyView();
        }

        public void Difficalty_OnClick(int value)
        {
            //Model.Instance.SetDifficulty(value);
            GoToNextScene();
        }

        public void PrivatePolicy_OnClick()
        {
            Application.OpenURL("https://groupozzy.wixsite.com/landing");
        }

        private void ShowDifficaltyView()
        {
            //MainMenu.SetActive(false);
            //DifficaltyMenu.SetActive(true);
        }

        private void ShowMainMenu()
        {
            //MainMenu.SetActive(true);
            //DifficaltyMenu.SetActive(false);
        }

        protected override void GoToNextScene()
        {
            base.GoToNextScene();
            Common.SceneNavigation.GoToGame();
        }
    }
}
