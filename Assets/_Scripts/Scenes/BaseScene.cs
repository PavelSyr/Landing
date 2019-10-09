using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scenes
{
    public class BaseScene : MonoBehaviour
    {
        protected virtual void Awake()
        {
            Initialisation();
        }

        protected virtual void Initialisation()
        {

        }

        protected virtual void GoToNextScene()
        {

        }

        protected virtual void GoToPrevScene()
        {

        }
    }
}
