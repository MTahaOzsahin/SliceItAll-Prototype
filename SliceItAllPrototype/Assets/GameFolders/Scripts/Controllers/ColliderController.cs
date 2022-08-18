using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SliceItAll.Scripts.Controllers
{
    public class ColliderController : MonoBehaviour
    {
        public bool IsCollide { get; set ; }
        
        private void OnCollisionEnter(Collision collision)
        {
            if (collision.collider != null)
            {
                IsCollide = true;
            }
        }
        private void OnCollisionExit(Collision collision)
        {
            IsCollide = false;
        }
    }
}
