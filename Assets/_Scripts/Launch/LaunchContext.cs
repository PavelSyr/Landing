using strange.extensions.command.api;
using strange.extensions.command.impl;
using strange.extensions.context.api;
using strange.extensions.context.impl;

namespace Launch
{
    class LaunchContext : MVCSContext
    {
        public LaunchContext(ContextView view) : base(view) { }
        public LaunchContext(ContextView view, ContextStartupFlags flag) : base(view, flag) { }

        protected override void mapBindings()
        {
            base.mapBindings();
            commandBinder.Bind(ContextEvent.START)
                .To<AnaliticsStartComand>()
                .To<StartCommand>()
                .Once()
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
