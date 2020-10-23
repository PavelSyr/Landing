using strange.extensions.command.impl;

namespace Launch
{
    class StartCommand : EventCommand
    {
        public override void Execute()
        {
            Common.SceneNavigation.GoToHome();
        }
    }
}
