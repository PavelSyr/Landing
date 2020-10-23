using Assets._Scripts.Models.Data;
using Models.Data;
using strange.extensions.command.impl;
using System;

namespace Game.Commands
{
    class GameOverCommand : EventCommand
    {
        public const int RESULT = 0;

        [Inject(Repositories.KeyResult)]
        public IRepository<int> Result { get; set; }

        public override void Execute()
        {
            Result.SetData(RESULT);
            Common.SceneNavigation.GoToResult();
        }
    }
}
