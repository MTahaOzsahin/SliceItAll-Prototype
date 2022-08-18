using SliceItAll.Scripts.Controllers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SliceItAll.Scripts.FSM.Actions
{
    [CreateAssetMenu(menuName ="FSM/Actions/StappedStateAction")]
    public class SteppedStateAction : BaseAction
    {
        public override void MainExecute(StateController stateController)
        {
            Debug.Log("Stepped");
            var rb = stateController.GetComponent<Rigidbody>();
            Physics.gravity = new Vector3(0f, -basePhysicVariables.fakeGravity, 0f);
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }
    }
}
