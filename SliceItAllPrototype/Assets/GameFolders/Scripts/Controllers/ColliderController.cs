using SliceItAll.Scripts.GamePlay.Slices;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SliceItAll.Scripts.Controllers
{
    public class ColliderController : MonoBehaviour
    {
        public bool IsCollideWithFloor { get; set ; }

        public  event System.Action CollideWithSliceable;

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.collider != null && collision.collider.CompareTag("Floor"))
            {
                IsCollideWithFloor = true;
            }
            if (collision.collider != null && collision.gameObject.GetComponent<Sliceable>() != null)
            {
                CollideWithSliceable?.Invoke();
            }
        }
        private void OnCollisionExit(Collision collision)
        {
            IsCollideWithFloor = false;
        }
    }
}
