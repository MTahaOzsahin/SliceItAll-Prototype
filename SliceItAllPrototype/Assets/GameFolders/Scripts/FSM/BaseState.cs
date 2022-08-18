using SliceItAll.Scripts.Controllers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SliceItAll.Scripts.FSM
{
    public class BaseState : ScriptableObject
    {
        public virtual void MainExecute(StateController stateController) { }
    }
}
