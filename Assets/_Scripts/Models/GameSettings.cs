using UnityEngine;

namespace Models
{
    [CreateAssetMenu(fileName = "GameSettings", menuName = "ScriptableObjects/GameSettings", order = 1)]
    class GameSettings : ScriptableObject, IGameSettings
    {
        [SerializeField]
        private float m_TotalFuel;

        [SerializeField]
        private float m_FuelConsumption;

        public float TotalFuel => m_TotalFuel;
        public float FuelConsumption => m_FuelConsumption;
    }
}
