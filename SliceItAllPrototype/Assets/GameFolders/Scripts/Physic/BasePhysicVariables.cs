using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SliceItAll.Scripts.Physic
{
    public  class BasePhysicVariables : ScriptableObject
    {
        [Header("Physics Variables")]
        [Tooltip("How much rotation force will use when tap. Default = 10")]
        public float rotateForce;

        [Tooltip("How much knife will evelate when tap. Default = 40")]
        public float elevationForce;

        [Tooltip("How much movement force will use when tap. Default = 4")]
        public float movementForce;

        [Tooltip("How sharp rotation will stop when in stopping area. Default = 0,18"),Range(0.01f,1f)]
        public float lerpValue;

        [Tooltip("Allowed max angular velocity. Defuat = 7, Recommended = 25")]
        public float maxAngularVelocity;

        [Tooltip("How much angular drag will use when out of stopping area. Default = 4")]
        public float angularDrag;

        [Tooltip("Fake gravity force. Enter positive value. Default = 20")]
        public float fakeGravity;

        [Header("Movement variables")]
        [Tooltip("This variable will use to escape from stapped state. Notice that with that variable will not use physic.We translate trnasform as variable")]
        public float stappedMovement;
    }
}
