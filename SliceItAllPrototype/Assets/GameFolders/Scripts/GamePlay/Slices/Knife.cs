using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SliceItAll.Scripts.GamePlay.Slices
{
    /// <summary>
    /// Thanks and credits to: https://github.com/Tvtig/UnityLightsaber
    /// </summary>
    public class Knife : MonoBehaviour
    {
        //The number of vertices to create per frame
        private const int NUM_VERTICES = 12;

        [SerializeField, Tooltip("The blade object")]
        private GameObject knife = null;

        [SerializeField, Tooltip("The empty game object located at the tip of the blade")]
        private GameObject tip = null;

        [SerializeField, Tooltip("The empty game object located at the base of the blade")]
        private GameObject _base = null;

        [SerializeField, Tooltip("The mesh object with the mesh filter and mesh renderer")]
        private GameObject meshParent = null;

        [SerializeField, Tooltip("The number of frame that the trail should be rendered for")]
        private int trailFrameLength = 3;

        [ColorUsage(true, true)]
        [SerializeField, Tooltip("The colour of the blade and trail")]
        private Color colour = Color.red;

        [SerializeField, Tooltip("The amount of force applied to each side of a slice")]
        private float forceAppliedToCut = 3f;

        Mesh mesh;
        Vector3[] vertices;
        int[] triangles;
        int frameCount;
        Vector3 previousTipPosition;
        Vector3 previousBasePosition;
        Vector3 triggerEnterTipPosition;
        Vector3 triggerEnterBasePosition;
        Vector3 triggerExitTipPosition;

        private void Start()
        {
            //initialize mesh and triangles
            meshParent.transform.position = Vector3.zero;
            mesh = new Mesh();
            meshParent.GetComponent<MeshFilter>().mesh = mesh;

            Material trailMaterial = Instantiate(meshParent.GetComponent<MeshRenderer>().sharedMaterial);
            trailMaterial.SetColor("Color_8F0C0815", colour);
            meshParent.GetComponent<MeshRenderer>().sharedMaterial = trailMaterial;

            Material bladeMaterial = Instantiate(knife.GetComponent<MeshRenderer>().sharedMaterial);
            bladeMaterial.SetColor("Color_AF2E1BB", colour);
            knife.GetComponent<MeshRenderer>().sharedMaterial = bladeMaterial;

            vertices = new Vector3[trailFrameLength * NUM_VERTICES];
            triangles = new int[vertices.Length];

            //Set starting position for tip and base
            previousTipPosition = tip.transform.position;
            previousBasePosition = _base.transform.position;
        }
        private void LateUpdate()
        {
            //Reset the frame count one we reach the frame length
            if (frameCount == (trailFrameLength * NUM_VERTICES))
            {
                frameCount = 0;
            }

            //Draw first triangle vertices for back and front
            vertices[frameCount] = _base.transform.position;
            vertices[frameCount + 1] = tip.transform.position;
            vertices[frameCount + 2] = previousTipPosition;
            vertices[frameCount + 3] = _base.transform.position;
            vertices[frameCount + 4] = previousTipPosition;
            vertices[frameCount + 5] = tip.transform.position;

            //Draw fill in triangle vertices
            vertices[frameCount + 6] = previousTipPosition;
            vertices[frameCount + 7] = _base.transform.position;
            vertices[frameCount + 8] = previousBasePosition;
            vertices[frameCount + 9] = previousTipPosition;
            vertices[frameCount + 10] = previousBasePosition;
            vertices[frameCount + 11] = _base.transform.position;

            //Set triangles
            triangles[frameCount] = frameCount;
            triangles[frameCount + 1] = frameCount + 1;
            triangles[frameCount + 2] = frameCount + 2;
            triangles[frameCount + 3] = frameCount + 3;
            triangles[frameCount + 4] = frameCount + 4;
            triangles[frameCount + 5] = frameCount + 5;
            triangles[frameCount + 6] = frameCount + 6;
            triangles[frameCount + 7] = frameCount + 7;
            triangles[frameCount + 8] = frameCount + 8;
            triangles[frameCount + 9] = frameCount + 9;
            triangles[frameCount + 10] = frameCount + 10;
            triangles[frameCount + 11] = frameCount + 11;

            mesh.vertices = vertices;
            mesh.triangles = triangles;

            //Track the previous base and tip positions for the next frame
            previousTipPosition = tip.transform.position;
            previousBasePosition = _base.transform.position;
            frameCount += NUM_VERTICES;
        }
        private void OnTriggerEnter(Collider other)
        {
            triggerEnterTipPosition = tip.transform.position;
            triggerEnterBasePosition = _base.transform.position;
        }

        private void OnTriggerExit(Collider other)
        {
            triggerExitTipPosition = tip.transform.position;

            //Create a triangle between the tip and base so that we can get the normal
            Vector3 side1 = triggerExitTipPosition - triggerEnterTipPosition;
            Vector3 side2 = triggerExitTipPosition - triggerEnterBasePosition;

            //Get the point perpendicular to the triangle above which is the normal
            //https://docs.unity3d.com/Manual/ComputingNormalPerpendicularVector.html
            Vector3 normal = Vector3.Cross(side1, side2).normalized;

            //Transform the normal so that it is aligned with the object we are slicing's transform.
            Vector3 transformedNormal = ((Vector3)(other.gameObject.transform.localToWorldMatrix.transpose * normal)).normalized;

            //Get the enter position relative to the object we're cutting's local transform
            Vector3 transformedStartingPoint = other.gameObject.transform.InverseTransformPoint(triggerEnterTipPosition);

            Plane plane = new Plane();

            plane.SetNormalAndPosition(
                    transformedNormal,
                    transformedStartingPoint);

            var direction = Vector3.Dot(Vector3.up, transformedNormal);

            //Flip the plane so that we always know which side the positive mesh is on
            if (direction < 0)
            {
                plane = plane.flipped;
            }

            GameObject[] slices = Slicer.Slice(plane, other.gameObject);
            Destroy(other.gameObject);

            Rigidbody rigidbody = slices[1].GetComponent<Rigidbody>();
            Vector3 newNormal = transformedNormal + Vector3.up * forceAppliedToCut;
            rigidbody.AddForce(newNormal, ForceMode.Impulse);
        }
    }
}
