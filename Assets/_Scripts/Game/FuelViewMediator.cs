using Assets._Scripts.Models.Data;
using Game.Commands;
using Models;
using Models.Data;
using strange.extensions.dispatcher.eventdispatcher.api;
using strange.extensions.mediation.impl;

namespace Game
{
    class FuelViewMediator : EventMediator
    {

        [Inject(Repositories.KeyDifficalty)]
        public IRepository<int> Repository { get; set; }

        [Inject]
        public IGameSettings gameSettings { get; set; }

        [Inject]
        public FuelView view { get; set; }

        private float m_Total;
        private float m_Consumption;

        private bool IsEmpty => m_Total <= 0;

        public override void OnRegister()
        {
            base.OnRegister();

            dispatcher.AddListener(GameCommands.CONSUME_FUEL, OnConsumeFuel);

            m_Total = gameSettings.TotalFuel;
            m_Consumption = Repository.GetData() * gameSettings.FuelConsumption;

            view.UpdateView(m_Total);
        }

        public override void OnRemove()
        {
            base.OnRemove();
        }

        private void OnConsumeFuel(IEvent payload)
        {
            m_Total -= m_Consumption;
            view.UpdateView(m_Total);

            if (IsEmpty)
            {
                dispatcher?.Dispatch(GameCommands.FUEL_OVER);
            }
        }
    }
}