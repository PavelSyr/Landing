using Common;
using Game;
using Models;
using strange.extensions.context.api;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Scenes
{
    public class GameScene : BaseScene
    {
        [SerializeField]
        private GameSettings m_GameSettings;

        [SerializeField]
        private ModuleView ModuleView;

        [SerializeField]
        private CollisionController CollisionCtrl;

        [SerializeField]
        private GraphicRaycaster Raycaster;

        [SerializeField]
        private InputView InputCtrl;

        [SerializeField]
        private Camera Camera;

        protected override void Initialisation()
        {
            base.Initialisation();

            context = new GameContext(this, ContextStartupFlags.MANUAL_MAPPING, m_GameSettings, Camera);
            context.Start();
            //Model.Instance.Reset();
            //FuelCtrl.Init(Model.Instance.Difficulty / 1000f);
        }

        protected override void GoToNextScene()
        {
            SceneNavigation.GoToResult();
        }

        public void OnCollision_Good()
        {
            print("Good work!");
            //Model.Instance.SetResults(true, 1000);
            ModuleView.ShowGoodView();
            StartCoroutine(SwitchToNextScene());
        }

        public void OnColision_Bad()
        {
            print("You can better!");
            //Model.Instance.SetResults(false, 0);
            ModuleView.ShowBadView();
            StartCoroutine(SwitchToNextScene());
        }

        private IEnumerator SwitchToNextScene()
        {
            CollisionCtrl.enabled = false;
            Raycaster.enabled = false;
            InputCtrl.enabled = false;
            yield return new WaitForSeconds(3f);
            GoToNextScene();
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();
        }
    }
}
