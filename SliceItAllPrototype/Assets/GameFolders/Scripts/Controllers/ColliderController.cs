using SliceItAll.Scripts.GamePlay.Slices;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SliceItAll.Scripts.Controllers
{
    public class ColliderController : MonoBehaviour
    {
        Rigidbody rb;
        public bool IsCollideWithFloor { get; set ; }

        public  event System.Action CollideWithSliceable;
        private void Awake()
        {
            rb = GetComponent<Rigidbody>();
        }
        private void OnCollisionEnter(Collision collision)
        {
            if (collision.collider != null && collision.collider.CompareTag("Floor"))
            {
                IsCollideWithFloor = true;
            }
            if (collision.collider != null && collision.gameObject.GetComponent<BaseSliceable>() != null)
            {
                CollideWithSliceable?.Invoke();
            }
        }
        private void OnCollisionExit(Collision collision)
        {
            IsCollideWithFloor = false;
        }
        private void OnTriggerEnter(Collider other)
        {
            if (other != null && other.CompareTag("Floor"))
            {
                rb.angularVelocity = Vector3.zero;
                rb.velocity = Vector3.zero;
                rb.angularDrag = 25f;
                rb.useGravity = false;
            }
        }
        private void OnTriggerExit(Collider other)
        {
            if (other != null && other.CompareTag("Floor"))
            {
                rb.useGravity = true;
            }
        }
    }
}
