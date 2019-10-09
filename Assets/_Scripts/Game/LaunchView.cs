using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Game
{
    public class LaunchView : MonoBehaviour
    {
        [SerializeField]
        private Text WaitText;

        [SerializeField]
        private CanvasGroup cGroup;

        public void SetActive(bool value)
        {
            gameObject.SetActive(value);
        }

        public void SetWaitText(string value)
        {
            WaitText.text = value;
        }

        public void SetAlpha(float value)
        {
            cGroup.alpha = value;
        }
    }
}
