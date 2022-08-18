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

        [Tooltip("Physics variables that will use to move")]
        public BasePhysicVariables basePhysicVariables;
        Rigidbody rb;
        [SerializeField] InputAction inputAction;

        private void Awake()
        {
            rb = GetComponent<Rigidbody>();
            colliderController = GetComponent<ColliderController>();
            mover = new Mover(this,basePhysicVariables, rb);
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

        void MoveAction(InputAction.CallbackContext context)
        {
            if (colliderController.IsCollide)
            {
                StartCoroutine(mover.StappedCoroutine());
            }
            else
            {
                StartCoroutine(mover.MovementCoroutine());
            }
        }
    }
}
