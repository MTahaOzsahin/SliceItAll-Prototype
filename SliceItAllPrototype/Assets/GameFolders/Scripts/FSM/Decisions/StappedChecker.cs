using SliceItAll.Scripts.Controllers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SliceItAll.Scripts.FSM.Decisions
{
    [CreateAssetMenu(menuName = "FSM/Decision/Stappedchecker")]
    public class StappedChecker : BaseDecision
    {
        public override int AreaDecide(StateController stateController)
        {
            return 5;
        }

        public override bool StappedCheck(StateController stateController)
        {
            var colliderController = stateController.GetComponent<ColliderController>();
            return colliderController.IsCollideWithFloor;
        }
    }
}
