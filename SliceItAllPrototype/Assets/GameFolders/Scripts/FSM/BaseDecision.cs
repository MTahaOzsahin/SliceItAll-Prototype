using SliceItAll.Scripts.Controllers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SliceItAll.Scripts.FSM
{
    public abstract class BaseDecision : ScriptableObject
    {
        public abstract int AreaDecide(StateController stateController);
        public abstract bool StappedCheck(StateController stateController);
    }
}
