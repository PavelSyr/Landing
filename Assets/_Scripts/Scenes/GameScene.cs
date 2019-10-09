using Common;
using Game;
using Game.Models;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Scenes
{
    public class GameScene : BaseScene
    {
        [SerializeField]
        private ModuleView ModuleView;

        [SerializeField]
        private CollisionController CollisionCtrl;

        [SerializeField]
        private FuelController FuelCtrl;

        [SerializeField]
        private GraphicRaycaster Raycaster;

        [SerializeField]
        private InputController InputCtrl;

        protected override void Initialisation()
        {
            base.Initialisation();
            Model.Instance.Reset();
            FuelCtrl.Init(Model.Instance.Difficulty / 1000f);
            AddListeners();
        }

        protected override void GoToNextScene()
        {
            SceneNavigation.GoToResult();
        }

        public void OnCollision_Good()
        {
            print("Good work!");
            Model.Instance.SetResults(true, 1000);
            ModuleView.ShowGoodView();
            StartCoroutine(SwitchToNextScene());
        }

        public void OnColision_Bad()
        {
            print("You can better!");
            Model.Instance.SetResults(false, 0);
            ModuleView.ShowBadView();
            StartCoroutine(SwitchToNextScene());
        }

        private void OnFuelEmpty()
        {
            InputCtrl.enabled = false;
            Raycaster.enabled = false;
        }

        private IEnumerator SwitchToNextScene()
        {
            RemoveListeners();
            CollisionCtrl.enabled = false;
            Raycaster.enabled = false;
            InputCtrl.enabled = false;
            yield return new WaitForSeconds(3f);
            GoToNextScene();
        }

        private void AddListeners()
        {
            CollisionCtrl.OnBadCollision += OnColision_Bad;
            CollisionCtrl.OnGoodCollision += OnCollision_Good;
            FuelCtrl.OnFuelIsEmptyEvent += OnFuelEmpty;
        }

        private void RemoveListeners()
        {
            CollisionCtrl.OnBadCollision -= OnColision_Bad;
            CollisionCtrl.OnGoodCollision -= OnCollision_Good;
        }

        private void OnDestroy()
        {
            RemoveListeners();
        }
    }
}
