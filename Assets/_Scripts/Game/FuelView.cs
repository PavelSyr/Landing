using strange.extensions.mediation.impl;
using UnityEngine;
using UnityEngine.UI;

namespace Game
{
    public class FuelView : View
    {
        [SerializeField]
        private Slider fuelSlider;

        public void UpdateView(float fuelValue)
        {
            fuelSlider.value = fuelValue;
        }
    }
}
