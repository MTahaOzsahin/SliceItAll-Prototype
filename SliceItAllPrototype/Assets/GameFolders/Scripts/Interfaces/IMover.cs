using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace SliceItAll.Scripts.Interfaces
{

    public interface IMover
    {
        public IEnumerator MovementCoroutine();
        public IEnumerator StappedCoroutine();
    }
}
