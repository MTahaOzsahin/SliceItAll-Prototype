using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SliceItAll.Scripts.Physic
{
    [RequireComponent(typeof(Rigidbody))]
    public class CenterOfMass : MonoBehaviour
    {
        Rigidbody objectsRigibody;
        [SerializeField,Tooltip("Set center of mass position")] Vector3 centerOfMass;
        private void Awake()
        {
            objectsRigibody = GetComponent<Rigidbody>();
        }
        private void Start()
        {
            objectsRigibody.centerOfMass = centerOfMass;
            Application.targetFrameRate = 60;
        }
        private void FixedUpdate()
        {
            objectsRigibody.centerOfMass = centerOfMass;
        }
        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawSphere(transform.position + transform.rotation * centerOfMass, 0.3f);
        }
    }
}
