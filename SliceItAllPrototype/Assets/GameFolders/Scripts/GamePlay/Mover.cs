using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace SliceItAll.Scripts.GamePlay
{
    public class Mover : MonoBehaviour
    {
        ///<Summary>
        ///This is where we move our gameobjects.
        /// </Summary>
        /// 
        [SerializeField] InputAction inputAction;

        [SerializeField] float rotateForce;
        [SerializeField] float elevationForce;
        [SerializeField] float lerpVariable = 0.2f;

        Rigidbody rb;

        private void Awake()
        {
            rb = GetComponent<Rigidbody>();
        }
        private void OnEnable()
        {
            inputAction.Enable();
            inputAction.started += MoveAction;
        }
        private void OnDisable()
        {
            inputAction.started -= MoveAction;
            inputAction.Disable();
        }
        private void Start()
        {
            rb.maxAngularVelocity = 25f;
        }
        private void FixedUpdate()
        {
            RotationCheck();
        }
        void MoveAction(InputAction.CallbackContext context)
        {

            StartCoroutine(Rotation());
            Debug.Log("Tapped");
        }
        IEnumerator Rotation()
        {
            float vectorDot = Vector3.Dot(Vector3.forward, transform.position.normalized);
            float timeElapsed = 0f;
            while (timeElapsed < 0.3f)
            {
                timeElapsed += Time.deltaTime;
                rb.velocity = Vector3.zero;
                rb.AddTorque((new Vector3(1f, 0, 0) * rotateForce * 1000f * Time.fixedDeltaTime));
                //rb.AddForce(Vector3.up * elevationForce * 100f * Time.fixedDeltaTime);
                rb.velocity = Vector3.up * elevationForce * 100f * Time.fixedDeltaTime;
            }
            yield return null;
        }
        
        void RotationCheck() 
        {
           
            float vectorDot = Vector3.Dot(Vector3.forward, transform.position.normalized);
            if (vectorDot < 0.45f)
            {
                Debug.Log("a");
                rb.angularDrag = 1.3f;
                rb.angularVelocity = Vector3.Lerp(rb.angularVelocity, Vector3.zero, lerpVariable);
                rb.angularVelocity = new Vector3(rb.angularVelocity.x, 0f, 0f);
            }
            else
            {
                rb.angularDrag = 0f;
            }
        }
        
    }
}
