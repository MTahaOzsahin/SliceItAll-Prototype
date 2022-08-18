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

        public BasePhysicVariables moverPhysicVariables;
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
                rb.AddTorque(transform.right * moverPhysicVariables.rotateForce * 1000f * Time.fixedDeltaTime);

                rb.AddForce(Vector3.up * moverPhysicVariables.elevationForce * 100f * Time.fixedDeltaTime);
                rb.AddForce(Vector3.forward * moverPhysicVariables.movementForce * 100f * Time.fixedDeltaTime);
            }
            yield return null;
        }
    }
}
