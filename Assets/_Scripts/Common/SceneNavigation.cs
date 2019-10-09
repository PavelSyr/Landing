using UnityEngine;
using UnityEngine.SceneManagement;

namespace Common
{
    public static class SceneNavigation
    {
        private static AsyncOperation LoadAsync(string name)
        {
            return SceneManager.LoadSceneAsync(name);
        }

        public static AsyncOperation GoToHome()
        {
            return LoadAsync(SceneEnum.Home);
        }

        public static AsyncOperation GoToGame()
        {
            Firebase.Analytics.FirebaseAnalytics.LogEvent(Firebase.Analytics.FirebaseAnalytics.EventLevelStart);
            return LoadAsync(SceneEnum.Game);
        }

        public static AsyncOperation GoToResult()
        {
            return LoadAsync(SceneEnum.Result);
        }
    }
}
