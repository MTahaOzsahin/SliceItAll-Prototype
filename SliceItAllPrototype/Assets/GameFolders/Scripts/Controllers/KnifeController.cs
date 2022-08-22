using SliceItAll.Scripts.GamePlay;
using SliceItAll.Scripts.Interfaces;
using SliceItAll.Scripts.Managers;
using SliceItAll.Scripts.Physic;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace SliceItAll.Scripts.Controllers
{
    public class KnifeController : MonoBehaviour, IEntity
    {
        [SerializeField] SoundManager soundsManager;
        AudioSource audioSource;
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
            audioSource = GetComponent<AudioSource>();
        }
        private void OnEnable()
        {
            inputAction.Enable();
            inputAction.started += MoveAction;
            inputAction.started += PLayTappingSound;
            colliderController.CollideWithSliceable += StepBack;
            colliderController.CollideWithSliceable += PlayStuckSound;
        }
        private void OnDisable()
        {
            inputAction.started -= MoveAction;
            inputAction.started -= PLayTappingSound;
            colliderController.CollideWithSliceable -= StepBack;
            colliderController.CollideWithSliceable -= PlayStuckSound;
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
        void PLayTappingSound(InputAction.CallbackContext context)
        {
            soundsManager.TappingSound(audioSource);
        }
        void PlayStuckSound()
        {
            soundsManager.StuckSound(audioSource);
        }
    }
}
