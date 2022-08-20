using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SliceItAll.Scripts.Controllers
{
    public class DistanceController : MonoBehaviour
    {
        [SerializeField]LayerMask layerMask;
        public bool DistanceToBelow()
        {
            if (Physics.Raycast(transform.position, Vector3.down, 2f, layerMask))
            {
                 return true;   
            }
            return false;
        }
        private void OnDrawGizmos()
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawRay(transform.position, Vector3.down * 2f);
        }
    }
}
