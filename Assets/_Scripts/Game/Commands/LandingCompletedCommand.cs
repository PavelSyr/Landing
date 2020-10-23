using Assets._Scripts.Models.Data;
using Models.Data;
using strange.extensions.command.impl;
using System;

namespace Game.Commands
{
    class LandingCompletedCommand : EventCommand
    {
        public const int RESULT = 1;

        [Inject(Repositories.KeyResult)]
        public IRepository<int> Result { get; set; }

        public override void Execute()
        {
            Result.SetData(RESULT);
            Common.SceneNavigation.GoToResult();
        }
    }
}
