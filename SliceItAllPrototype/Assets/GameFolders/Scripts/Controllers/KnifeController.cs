using SliceItAll.Scripts.GamePlay;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace SliceItAll.Scripts.Controllers
{
    public class KnifeController : MonoBehaviour
    {
        Rigidbody rb;
        private void Awake()
        {
            rb = GetComponent<Rigidbody>();
        }
        private void OnCollisionEnter(Collision collision)
        {
            if (collision != null)
            {
                rb.constraints = RigidbodyConstraints.FreezePosition;
                rb.constraints = RigidbodyConstraints.FreezeRotation;
                rb.useGravity = false;
            }
        }
        private void OnCollisionExit(Collision collision)
        {
            rb.useGravity = true;
            rb.constraints = RigidbodyConstraints.None;

            rb.constraints = RigidbodyConstraints.FreezePositionX;
            rb.constraints = RigidbodyConstraints.FreezeRotationY;
            rb.constraints = RigidbodyConstraints.FreezeRotationZ;
        }

    }
}
