using SliceItAll.Scripts.GamePlay;
using SliceItAll.Scripts.Interfaces;
using SliceItAll.Scripts.Physic;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace SliceItAll.Scripts.Controllers
{
    public class KnifeController : MonoBehaviour, IEntity
    {
        IMover mover;
        ColliderController colliderController;
        DistanceController distanceController;

        [Tooltip("Physics variables that will use to move")]
        public BasePhysicVariables moverPhysicVariables;
        Rigidbody rb;
        [SerializeField] InputAction inputAction;

        private void Awake()
        {
            rb = GetComponent<Rigidbody>();
            colliderController = GetComponent<ColliderController>();
            distanceController = GetComponent<DistanceController>();
            mover = new Mover(this,moverPhysicVariables, rb);
        }
        private void OnEnable()
        {
            inputAction.Enable();
            inputAction.started += MoveAction;
            colliderController.CollideWithSliceable += StepBack;
        }
        private void OnDisable()
        {
            inputAction.started -= MoveAction;
            colliderController.CollideWithSliceable -= StepBack;
            inputAction.Disable();
        }

        void MoveAction(InputAction.CallbackContext context)
        {
            if (colliderController.IsCollideWithFloor || distanceController.DistanceToBelow())
            {
                StartCoroutine(mover.StappedCoroutine());
            }
            else
            {
                StartCoroutine(mover.MovementCoroutine());
            }
        }
        void StepBack()
        {
            StartCoroutine(mover.StappedCoroutine());
        }
    }
}
