using Common;
using strange.extensions.mediation.impl;
using UnityEngine;

namespace Game
{
    public class InputView : EventView
    {
		public const string CLICK = "CLICK";

		[Inject]
		public IInput Input { get; set; }

		[Inject(GameContext.MAIN_CAMERA)]
		public Camera Camera { get; set; }

		[SerializeField]
		private BoxCollider2D Collider;

		public void Init()
        {
			Vector2 camSize;
			camSize.y = Camera.orthographicSize * 2f;
			camSize.x = Camera.aspect * camSize.y;

			Collider.size = camSize;
		}

		private void OnMouseDown()
		{
			if (enabled)
            {
				dispatcher.Dispatch(CLICK, Input.MousePosition);
            }
		}
	}
}
