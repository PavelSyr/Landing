using Assets._Scripts.Models.Data;
using Models.Data;
using strange.extensions.command.impl;

namespace Home.Commands
{
    class SetDifficaltyCommand : EventCommand
    {
        [Inject(Repositories.KeyDifficalty)]
        public IRepository<int> Repository { get; set; }

        public override void Execute()
        {
            UnityEngine.Debug.Log($"SetDifficaltyCommand {evt.data}");
            Repository.SetData((int)evt.data);
        }
    }
}
