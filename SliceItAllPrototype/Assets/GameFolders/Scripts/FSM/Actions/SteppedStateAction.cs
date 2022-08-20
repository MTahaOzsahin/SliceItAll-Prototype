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
            Physics.gravity = new Vector3(0f, -9.8f, 0f);
            rb.maxAngularVelocity = basePhysicVariables.maxAngularVelocity;
        }
    }
}
