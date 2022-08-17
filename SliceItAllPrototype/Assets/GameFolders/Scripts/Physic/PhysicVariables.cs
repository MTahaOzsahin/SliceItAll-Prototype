using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SliceItAll.Scripts.Physic
{
    [CreateAssetMenu]
    public class PhysicVariables : ScriptableObject
    {
        [Tooltip("How much rotation force will use when tap. Default = 10")]
        public float rotateForce;

        [Tooltip("How much knife will evelate when tap. Default = 40")]
        public float elevationForce;

        [Tooltip("How much movement force will use when tap. Default = 4")]
        public float movementForce;

        [Tooltip("How sharp rotation will stop when in stopping area. Default = 0,18"),Range(0.01f,1f)]
        public float lerpValue;

        [Tooltip("How much angular drag will use when out of stopping area. Default = 4")]
        public float angularDrag;

        [Tooltip("Fake gravity force. Enter positive value. Default = 20")]
        public float fakeGravity;
    }
}
