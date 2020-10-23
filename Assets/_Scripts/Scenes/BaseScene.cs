using strange.extensions.context.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scenes
{
    public class BaseScene : ContextView
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
