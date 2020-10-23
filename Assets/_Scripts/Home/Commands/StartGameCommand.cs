using strange.extensions.command.impl;

namespace Home.Commands
{
    class StartGameCommand : EventCommand
    {
        public override void Execute()
        {
            Common.SceneNavigation.GoToGame();
        }
    }
}
