using SliceItAll.Scripts.Interfaces;
using SliceItAll.Scripts.Physic;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SliceItAll.Scripts.GamePlay
{
    public class Mover : IMover
    {
        ///<Summary>
        ///This is where we move our gameobjects.
        /// </Summary>
        /// 
        IEntity entity;
        BasePhysicVariables moverPhysicVariables;
        Rigidbody rb;


        public Mover(IEntity _entity,BasePhysicVariables _moverPhysicVariables, Rigidbody _rb)
        {
            entity = _entity;
            moverPhysicVariables = _moverPhysicVariables;
            rb = _rb;
        }

        public IEnumerator MovementCoroutine()
        {
            rb.velocity = Vector3.zero;
            float timeElapsed = 0f;
            while (timeElapsed < 0.9f)
            {
                timeElapsed += Time.fixedDeltaTime;
                rb.AddTorque(entity.transform.right * moverPhysicVariables.rotateForce * 1000f * Time.fixedDeltaTime);

                rb.AddForce(Vector3.up * moverPhysicVariables.elevationForce  * Time.fixedDeltaTime);
                rb.AddForce(Vector3.forward * moverPhysicVariables.movementForce * Time.fixedDeltaTime);
            }
            yield return null;
        }

        public IEnumerator StappedCoroutine()
        {
            rb.velocity = Vector3.zero;
            rb.AddForce(Vector3.up * moverPhysicVariables.stappedMovement* 1200f * Time.fixedDeltaTime);
            rb.AddForce(Vector3.back * moverPhysicVariables.stappedMovement* 50f * Time.fixedDeltaTime);

            yield return null;
        }
    }
}
