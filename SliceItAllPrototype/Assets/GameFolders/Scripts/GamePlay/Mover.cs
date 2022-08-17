using SliceItAll.Scripts.Physic;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace SliceItAll.Scripts.GamePlay
{
    [RequireComponent(typeof(Rigidbody))]
    public class Mover : MonoBehaviour
    {
        ///<Summary>
        ///This is where we move our gameobjects.
        /// </Summary>
        /// 

        public PhysicVariables physicVariables;
        [SerializeField] InputAction inputAction;

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

        Rigidbody rb;

        private void Awake()
        {
            rb = GetComponent<Rigidbody>();
        }
        
        private void Start()
        {
            Application.targetFrameRate = 30;
            rb.maxAngularVelocity = 25f;
        }
        private void FixedUpdate()
        {
            MovementAdjustment();
        }
        public void MoveAction(InputAction.CallbackContext context)
        {
            StartCoroutine(Movement());
        }
        IEnumerator Movement()
        {
            rb.velocity = Vector3.zero;
            float timeElapsed = 0f;
            while (timeElapsed < 0.3f)
            {
                timeElapsed += Time.deltaTime;
                rb.AddTorque(transform.right * physicVariables.rotateForce * 1000f * Time.fixedDeltaTime);

                rb.AddForce(Vector3.up * physicVariables.elevationForce * 100f * Time.fixedDeltaTime);
                rb.AddForce(Vector3.forward * physicVariables.movementForce * 100f * Time.fixedDeltaTime);
            }
            yield return null;
        }
        
        void MovementAdjustment() 
        {
            Physics.gravity = new Vector3(0f, -physicVariables.fakeGravity, 0f);

            float vectorDot = Vector3.Dot(Vector3.forward, transform.forward);
            if (vectorDot > 0.45f )
            {
                rb.angularDrag = physicVariables.angularDrag;
                rb.angularVelocity = Vector3.Lerp(rb.angularVelocity, Vector3.zero, physicVariables.lerpValue);
                rb.angularVelocity = new Vector3(rb.angularVelocity.x, 0f, 0f);
            }
            else
            {
                rb.angularDrag = 0;
            }
        }
        
    }
}
