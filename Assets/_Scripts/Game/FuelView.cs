using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Game
{
    public class FuelView : MonoBehaviour
    {
        [SerializeField]
        private FuelController fuelCtrl;

        [SerializeField]
        private Slider fuelSlider;

        private void Update()
        {
            fuelSlider.value = fuelCtrl.Total;
        }
    }
}
