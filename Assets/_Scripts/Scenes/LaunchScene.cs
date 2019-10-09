using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scenes
{
    public class LaunchScene : BaseScene
    {
        protected override void Initialisation()
        {
            base.Initialisation();
            Firebase.Analytics.FirebaseAnalytics.LogEvent(Firebase.Analytics.FirebaseAnalytics.EventAppOpen);
            GoToNextScene();
        }

        protected override void GoToNextScene()
        {
            base.GoToNextScene();
            Common.SceneNavigation.GoToHome();
        }
    }
}
