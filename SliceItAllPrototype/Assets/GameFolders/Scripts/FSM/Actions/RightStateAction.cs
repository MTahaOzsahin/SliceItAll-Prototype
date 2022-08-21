using SliceItAll.Scripts.Controllers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SliceItAll.Scripts.FSM.Actions
{
    [CreateAssetMenu(menuName = "FSM/Actions/RightStateAction")]
    public class RightStateAction : BaseAction
    {
        public override void MainExecute(StateController stateController)
        {
            var rb = stateController.GetComponent<Rigidbody>();
            Physics.gravity = new Vector3(0f, -basePhysicVariables.fakeGravity, 0f);
            rb.maxAngularVelocity = basePhysicVariables.maxAngularVelocity;
            rb.angularDrag = basePhysicVariables.angularDrag;
            rb.angularVelocity = Vector3.Lerp(rb.angularVelocity, Vector3.zero, basePhysicVariables.lerpValue);
            rb.angularVelocity = new Vector3(rb.angularVelocity.x, 0f, 0f);
            if (rb.velocity.y > 8f) rb.velocity = new Vector3(0f,8f,rb.velocity.z); 
        }
    }
}
