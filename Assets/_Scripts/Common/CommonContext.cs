using Assets._Scripts.Models.Data;
using Models.Data;
using strange.extensions.context.api;
using strange.extensions.context.impl;
using UnityEngine;

namespace Common
{
    class CommonContext : MVCSContext
    {
        public CommonContext(MonoBehaviour view) : base(view) {}

        public CommonContext(MonoBehaviour view, ContextStartupFlags flags) : base(view, flags) { }

        protected override void mapBindings()
        {
            base.mapBindings();

            var difficaltyRepository = new PlayerPrefsRepository(Repositories.KeyDifficalty);
            var resultRepositories = new PlayerPrefsRepository(Repositories.KeyResult);

            injectionBinder
                .Bind<IRepository<int>>()
                .ToValue(new IntRepository(difficaltyRepository))
                .ToName(Repositories.KeyDifficalty);

            injectionBinder
                .Bind<IRepository<int>>()
                .ToValue(new IntRepository(resultRepositories))
                .ToName(Repositories.KeyResult);
        }
    }
}
