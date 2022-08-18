using SliceItAll.Scripts.Controllers;
using SliceItAll.Scripts.Physic;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SliceItAll.Scripts.FSM
{
    public abstract class BaseAction : ScriptableObject
    {
        public  BasePhysicVariables basePhysicVariables;
        public abstract void MainExecute(StateController stateController);
    }
}
