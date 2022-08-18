using SliceItAll.Scripts.Controllers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SliceItAll.Scripts.FSM
{
    [CreateAssetMenu(menuName ="FSM/State")]
    public sealed class BaseStateAction : BaseState
    {
        public BaseAction action;
        public BaseTransition transition;
        public override void MainExecute(StateController stateController)
        {
            action.MainExecute(stateController);
            transition.MainExecute(stateController);
        }
    }
}
