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

        private void Awake()
        {
            
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
        void MoveAction (InputAction.CallbackContext context)
        {
            Debug.Log("Tapped");
        }
    }
}
