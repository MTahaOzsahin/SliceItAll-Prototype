using SliceItAll.Scripts.Controllers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SliceItAll.Scripts.FSM
{
    [CreateAssetMenu(menuName ="FSM/Transition")]
    public sealed class BaseTransition : ScriptableObject
    {
        public BaseDecision Decision;
        public BaseState UpState;
        public BaseState RightState;
        public BaseState DownState;
        public BaseState LeftState;
        public BaseState StappedState;

        public void MainExecute(StateController stateController)
        {
            if (Decision.StappedCheck(stateController))
            {
                stateController.CurrentState = StappedState;
            }
            else
            {
                if (Decision.AreaDecide(stateController) == 0)
                {
                    stateController.CurrentState = UpState;
                }
                else if (Decision.AreaDecide(stateController) == 1)
                {
                    stateController.CurrentState = RightState;
                }
                else if (Decision.AreaDecide(stateController) == 2)
                {
                    stateController.CurrentState = DownState;
                }
                else if (Decision.AreaDecide(stateController) == 3)
                {
                    stateController.CurrentState = LeftState;
                }
            }
           
        }
    }
}
