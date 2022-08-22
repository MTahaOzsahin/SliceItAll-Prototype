using SliceItAll.Scripts.Controllers.EndLevelController;
using SliceItAll.Scripts.Managers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SliceItAll.Scripts.GamePlay.Slices
{
    /// <summary>
    /// Thanks and credits to: https://github.com/Tvtig/UnityLightsaber
    /// </summary>
    public class BaseSlicer : MonoBehaviour
    {
        [SerializeField] ScoreManager scoreManager;
        [SerializeField] SoundManager soundManager;
        int endLevelSliceScore;

        [SerializeField, Tooltip("The empty game object located at the tip of the blade")]
        GameObject tip = null;

        [SerializeField, Tooltip("The empty game object located at the base of the blade")]
        GameObject _base = null;

        [SerializeField, Tooltip("The amount of force applied to each side of a slice")]
        float forceAppliedToCut = 3f;

       
        Vector3 previousTipPosition;
        Vector3 previousBasePosition;
        Vector3 triggerEnterTipPosition;
        Vector3 triggerEnterBasePosition;
        Vector3 triggerExitTipPosition;

        private void Start()
        {
            endLevelSliceScore = 0;
            //Set starting position for tip and base
            previousTipPosition = tip.transform.position;
            previousBasePosition = _base.transform.position;
        }
        private void LateUpdate()
        {
            //Track the previous base and tip positions for the next frame
            previousTipPosition = tip.transform.position;
            previousBasePosition = _base.transform.position;
        }
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.GetComponent<BaseSliceable>() != null) 
            {
                triggerEnterTipPosition = tip.transform.position;
                triggerEnterBasePosition = _base.transform.position;
                soundManager.SlicingSound(this.gameObject.GetComponent<AudioSource>());
            }
            if (other.gameObject.GetComponent<EndLevelController>() != null)
            {
                int scoreMultiplier = other.gameObject.GetComponent<EndLevelController>().ScoreMultiplier;
                scoreManager.EndLevelScore(endLevelSliceScore, scoreMultiplier);
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.GetComponent<BaseSliceable>() == null) return;
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

            Rigidbody rigidbodyPositive = slices[0].GetComponent<Rigidbody>(); //Positive object that craeted at left side of knife.
            Rigidbody rigidbodyNegative = slices[1].GetComponent<Rigidbody>(); //Negative object that created at right side of knife.

            rigidbodyPositive.velocity = new Vector3(-1f * forceAppliedToCut, 0f * forceAppliedToCut, 0f);
            rigidbodyNegative.velocity = new Vector3(1f * forceAppliedToCut, 0f * forceAppliedToCut, 0f);
            endLevelSliceScore += other.gameObject.GetComponent<BaseSliceable>().score;
            scoreManager.EndLevelScore(endLevelSliceScore,1);
            scoreManager.HandleScore(other.gameObject.GetComponent<BaseSliceable>().score,other.gameObject.transform.position);
        }
    }
}
