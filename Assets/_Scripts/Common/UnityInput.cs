using UnityEngine;

namespace Common
{
    class UnityInput : IInput
    {
        public Vector3 MousePosition => Input.mousePosition;
    }
}
