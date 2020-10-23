using Home.Commands;
using Common;
using strange.extensions.command.api;
using strange.extensions.command.impl;
using strange.extensions.context.api;
using UnityEngine;

namespace Home
{
    class HomeContext : CommonContext
    {
		public HomeContext(MonoBehaviour view) : base(view){}

		public HomeContext(MonoBehaviour view, ContextStartupFlags flags) : base(view, flags){}

        protected override void mapBindings()
        {
            base.mapBindings();

            mediationBinder.Bind<MainMenuView>().To<MainMenuMediator>();
            mediationBinder.Bind<DifficaltyMenuView>().To<DifficaltyMenuMediator>();

            commandBinder.Bind(HomeCommands.START).To<HomeStartCommand>();
            commandBinder.Bind(HomeCommands.SET_DIFFICALTY)
                .To<AnaliticsSetDifficaltyCommand>()
                .To<SetDifficaltyCommand>()
                .To<StartGameCommand>()
                .InSequence();
        }

        protected override void addCoreComponents()
        {
            base.addCoreComponents();
            injectionBinder.Unbind<ICommandBinder>();
            injectionBinder.Bind<ICommandBinder>().To<EventCommandBinder>().ToSingleton();
        }
    }
}
