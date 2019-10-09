using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class LaunchGame : MonoBehaviour
    {
        private const int LOUNCHES = 1;
        private static int CountLounches = 0;

        [SerializeField]
        private InputController InputCtrl;

        [SerializeField]
        private Rigidbody2D ModuleRigidBody;

        [SerializeField]
        private LaunchView CountDownView;

        private void Awake()
        {
            CountLounches++;

            CountDownView.SetActive(true);
            CountDownView.SetWaitText(string.Empty);
            InputCtrl.enabled = false;
            ModuleRigidBody.simulated = false;
        }

        private void Start()
        {
            if (CountLounches > LOUNCHES)
            {
                StartCoroutine(DefaultPrelaunch());
            }
            else
            {
                StartCoroutine(FirstPrelaunch());
            }
        }

        private void Launch()
        {
            CountDownView.SetActive(false);
            InputCtrl.enabled = true;
            ModuleRigidBody.simulated = true;
            DestroyImmediate(this);
            Destroy(CountDownView.gameObject);
        }

        private IEnumerator FirstPrelaunch()
        {
            yield return CountDown();

            yield return Fade();

            Launch();
        }

        private IEnumerator DefaultPrelaunch()
        {
            yield return Fade();

            Launch();
        }

        //Count down animation;
        private IEnumerator CountDown()
        {
            yield return null;

            int Count = 3;
            while (Count > 0)
            {
                CountDownView.SetWaitText(Count.ToString());
                yield return new WaitForSeconds(1f);
                Count--;
            }

            CountDownView.SetWaitText(string.Empty);
        }

        //fade animation;
        private IEnumerator Fade()
        {
            yield return null;

            float t = 1;
            while (t > 0)
            {
                CountDownView.SetAlpha(t);
                yield return null;
                t -= Time.deltaTime * 0.8f;
            }
        }
    }
}
