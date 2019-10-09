using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Game
{
    public class InputController : MonoBehaviour
    {
        [SerializeField]
        private ForceController fController;
        [SerializeField]
        private EnginesController eController;
        [SerializeField]
        private FuelController fuelCtrl;

        private List<Action> MethodsToInvoke;

        private void Awake()
        {
            MethodsToInvoke = new List<Action>();
        }

        private void LateUpdate()
        {
            for (int i = 0; i < MethodsToInvoke.Count; i++)
            {
                MethodsToInvoke[i]();
            }
        }

        private void AddMethod(Action method)
        {
            if(!MethodsToInvoke.Contains(method))
            {
                MethodsToInvoke.Add(method);
            }
        }

        private void RemoveMethod(Action method)
        {
            if (MethodsToInvoke.Contains(method))
            {
                MethodsToInvoke.Remove(method);
            }
        }

        private void SetMethod(Action method, bool needSet)
        {
            if (needSet) AddMethod(method);
            else RemoveMethod(method);
        }

        private void ToLeft()
        {
            eController.SwitchLeft();
            fController.Left();
            fuelCtrl.Spend();
        }

        private void ToRight()
        {
            eController.SwitchRight();
            fController.Right();
            fuelCtrl.Spend();
        }

        private void ToUp()
        {
            eController.SwitchBottom();
            fController.Up();
            fuelCtrl.Spend();
        }

        private void ToDown()
        {
            eController.SwitchTop();
            fController.Down();
            fuelCtrl.Spend();
        }

        public void OnLeft(bool isButtonDown)
        {
            SetMethod(ToLeft, isButtonDown);
        }

        public void OnRight(bool isButtonDown)
        {
            SetMethod(ToRight, isButtonDown);
        }

        public void OnUp(bool isButtonDown)
        {
            SetMethod(ToUp, isButtonDown);
        }

        public void OnDown(bool isButtonDown)
        {
            SetMethod(ToDown, isButtonDown);
        }
#if UNITY_EDITOR
        private void Update()
        {
            if (EventSystem.current.currentSelectedGameObject != null) return;

            float ha = Input.GetAxis("Horizontal");
            float va = Input.GetAxis("Vertical");

            if (ha != 0)
            {
                OnLeft(ha > 0f);
                OnRight(ha < 0f);
            }
            else
            {
                OnLeft(false);
                OnRight(false);
            }

            if (va != 0)
            {
                OnUp(va < 0f);
                OnDown(va > 0f);
            }
            else
            {
                OnUp(false);
                OnDown(false);
            }
        }
#endif
    }
}
