using strange.extensions.command.impl;

namespace Home.Commands
{
    class AnaliticsSetDifficaltyCommand : EventCommand
    {
        public override void Execute()
        {
            Firebase.Analytics.FirebaseAnalytics.LogEvent("SetDifficulty", "value", evt.data.ToString());
        }
    }
}
