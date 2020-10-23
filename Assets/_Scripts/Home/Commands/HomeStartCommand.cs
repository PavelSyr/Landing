using strange.extensions.command.impl;

namespace Home.Commands
{
    class HomeStartCommand : EventCommand
    {
        public override void Execute()
        {
            UnityEngine.Debug.Log("HomeStartCommand");
        }
    }
}
