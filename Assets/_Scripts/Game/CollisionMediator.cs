using strange.extensions.dispatcher.eventdispatcher.api;
using strange.extensions.mediation.impl;

namespace Game
{
    class CollisionMediator : EventMediator
    {
        public static string BAD_COLLISION = "BAD_COLLISION";
        public static string GOOD_COLLISION = "GOOD_COLLISION";

        [Inject]
        public CollisionController CollisionController { get; set; }

        public override void OnRegister()
        {
            base.OnRegister();
            CollisionController.dispatcher.AddListener(CollisionController.BAD_COLLISION, OnBadCollision);
            CollisionController.dispatcher.AddListener(CollisionController.GOOD_COLLISION, OnGoodCollision);
        }

        public override void OnRemove()
        {
            base.OnRemove();
            CollisionController.dispatcher.RemoveListener(CollisionController.BAD_COLLISION, OnBadCollision);
            CollisionController.dispatcher.RemoveListener(CollisionController.GOOD_COLLISION, OnGoodCollision);
        }

        private void OnGoodCollision(IEvent payload)
        {
            dispatcher.Dispatch(GOOD_COLLISION, payload);
        }

        private void OnBadCollision(IEvent payload)
        {
            dispatcher.Dispatch(BAD_COLLISION, payload);
        }
    }
}
