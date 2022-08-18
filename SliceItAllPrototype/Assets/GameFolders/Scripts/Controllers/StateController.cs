using SliceItAll.Scripts.FSM;
using SliceItAll.Scripts.GamePlay;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace SliceItAll.Scripts.Controllers
{
    public class StateController : MonoBehaviour
    {
        public BaseState CurrentState { get;  set; }
        [SerializeField] BaseState initialState;
        private void Start()
        {
            CurrentState = initialState;
        }
        private void FixedUpdate()
        {
            CurrentState.MainExecute(this);
        }

    }
}
