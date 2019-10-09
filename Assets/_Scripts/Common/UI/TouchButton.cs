using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace Common.UI
{
    [Serializable]
    class TounchButtonEvent : UnityEvent<bool> { }

    public class TouchButton : MonoBehaviour, IPointerUpHandler, IPointerDownHandler 
    {
        [SerializeField]
        private TounchButtonEvent OnChange;

        public void OnPointerDown(PointerEventData eventData)
        {
            OnChange.Invoke(true);
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            OnChange.Invoke(false);
        }
    }
}