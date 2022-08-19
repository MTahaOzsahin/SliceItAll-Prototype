using SliceItAll.Scripts.Controllers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SliceItAll.Scripts.FSM.Actions
{
    [CreateAssetMenu(menuName ="FSM/Actions/UpStateAction")]
    public class UpStateAction : BaseAction
    {
        public override void MainExecute(StateController stateController)
        {
            Debug.Log("up");
            var rb = stateController.GetComponent<Rigidbody>();
            Physics.gravity = new Vector3(0f, -basePhysicVariables.fakeGravity, 0f);
            rb.maxAngularVelocity = basePhysicVariables.maxAngularVelocity;
            rb.angularDrag = basePhysicVariables.angularDrag;
            rb.AddTorque(Vector3.right * basePhysicVariables.rotateForce  * Time.fixedDeltaTime);
        }
    }
}
