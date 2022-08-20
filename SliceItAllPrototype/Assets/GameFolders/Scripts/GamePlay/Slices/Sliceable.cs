using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SliceItAll.Scripts.GamePlay.Slices
{
    /// <summary>
    /// Thanks and credits to: https://github.com/Tvtig/UnityLightsaber
    /// </summary>

    public class Sliceable : MonoBehaviour
    {
        [Tooltip("How much score will gain when slice this object")]
        public int score;

        [SerializeField]
        private bool isSolid = true;

        [SerializeField]
        private bool reverseWindTriangles = false;

        [SerializeField]
        private bool useGravity = false;

        [SerializeField]
        private bool shareVertices = false;

        [SerializeField]
        private bool smoothVertices = false;

        public bool IsSolid
        {
            get
            {
                return isSolid;
            }
            set
            {
                isSolid = value;
            }
        }

        public bool ReverseWireTriangles
        {
            get
            {
                return reverseWindTriangles;
            }
            set
            {
                reverseWindTriangles = value;
            }
        }

        public bool UseGravity
        {
            get
            {
                return useGravity;
            }
            set
            {
                useGravity = value;
            }
        }

        public bool ShareVertices
        {
            get
            {
                return shareVertices;
            }
            set
            {
                shareVertices = value;
            }
        }

        public bool SmoothVertices
        {
            get
            {
                return smoothVertices;
            }
            set
            {
                smoothVertices = value;
            }
        }
        private void Update()
        {
            if (transform.position.y < -30f)
            {
                Destroy(this.gameObject);
            }
        }
    }
}
