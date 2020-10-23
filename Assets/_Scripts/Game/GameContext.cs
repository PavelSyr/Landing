using Common;
using Game.Commands;
using Models;
using strange.extensions.command.api;
using strange.extensions.command.impl;
using strange.extensions.context.api;
using strange.extensions.injector.impl;
using System;
using UnityEngine;

namespace Game
{
    class GameContext : CommonContext
    {
        public const string MAIN_CAMERA = "MAIN_CAMERA";

        private IGameSettings m_GameSettings;
        private Camera m_Camera;

        public GameContext(MonoBehaviour view, IGameSettings gameSettings, Camera camera) : base(view)
        {
            Init(gameSettings, camera);
        }

        public GameContext(MonoBehaviour view, ContextStartupFlags flags, IGameSettings gameSettings, Camera camera) : base(view, flags)
        {
            Init(gameSettings, camera);
        }

        private void Init(IGameSettings gameSettings, Camera camera)
        {
            if (gameSettings == null)
            {
                throw new ArgumentNullException(nameof(gameSettings));
            }

            if (camera == null)
            {
                throw new ArgumentNullException(nameof(camera));
            }

            m_GameSettings = gameSettings;
            m_Camera = camera;
        }

        protected override void mapBindings()
        {
            base.mapBindings();

            injectionBinder.Bind<IInput>().To<UnityInput>().ToSingleton();
            injectionBinder.Bind<IGameSettings>().ToValue(m_GameSettings);
            injectionBinder.Bind<Camera>().ToValue(m_Camera).ToName(MAIN_CAMERA);

            mediationBinder.Bind<FuelView>().To<FuelViewMediator>();
            mediationBinder.Bind<ModuleView>().To<ModuleViewMediator>();
            mediationBinder.Bind<InputView>().To<InputViewMediator>();
            mediationBinder.Bind<CollisionController>().To<CollisionMediator>();
            //mediationBinder.Bind<DifficaltyMenuView>().To<DifficaltyMenuMediator>();
            //
            //commandBinder.Bind(HomeCommands.START).To<HomeStartCommand>();
            //commandBinder.Bind(HomeCommands.SET_DIFFICALTY)
            //    .To<AnaliticsSetDifficaltyCommand>()
            //    .To<SetDifficaltyCommand>()
            //    .To<StartGameCommand>()
            //    .InSequence();


            //TODO bind commands
            commandBinder.Bind(GameCommands.START).To<StartGameCommand>();
            commandBinder.Bind(GameCommands.BAD_LANDING).To<GameOverCommand>();
            commandBinder.Bind(GameCommands.FUEL_OVER).To<FuelOverCommand>();
            commandBinder.Bind(GameCommands.GOOD_LANDING).To<LandingCompletedCommand>();
            commandBinder.Bind(GameCommands.BAD_COLLISION).To<BadCollisionCommand>();
        }

        protected override void addCoreComponents()
        {
            base.addCoreComponents();
            injectionBinder.Unbind<ICommandBinder>();
            injectionBinder.Bind<ICommandBinder>().To<EventCommandBinder>().ToSingleton();
        }
    }
}
