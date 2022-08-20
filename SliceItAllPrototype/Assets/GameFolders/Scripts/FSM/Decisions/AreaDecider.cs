using SliceItAll.Scripts.Controllers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SliceItAll.Scripts.FSM.Decisions
{
    [CreateAssetMenu(menuName ="FSM/Decision/AreaDecider")]
    public class AreaDecider : BaseDecision
    {
        public override int AreaDecide(StateController stateController)
        {
            var areaController = stateController.GetComponent<AreaController>();
            return areaController.AreaDecider();

        }

        public override bool StappedCheck(StateController stateController)
        {
            var colliderController = stateController.GetComponent<ColliderController>();
            return colliderController.IsCollideWithFloor;
        }
    }
}
