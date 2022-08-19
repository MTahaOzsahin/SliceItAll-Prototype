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
            while (timeElapsed < 0.3f)
            {
                timeElapsed += Time.deltaTime;
                rb.AddTorque(entity.transform.right * moverPhysicVariables.rotateForce * 1000f * Time.fixedDeltaTime);

                rb.AddForce(Vector3.up * moverPhysicVariables.elevationForce  * Time.fixedDeltaTime);
                rb.AddForce(Vector3.forward * moverPhysicVariables.movementForce * Time.fixedDeltaTime);
            }
            yield return null;
        }

        public IEnumerator StappedCoroutine()
        {
            float timeElapsed = 0f;
            while (timeElapsed < 0.5f)
            {
                timeElapsed += Time.deltaTime;
                //rb.AddTorque(entity.transform.right * moverPhysicVariables.rotateForce * 1000f * Time.fixedDeltaTime);
                rb.AddForce(Vector3.up * moverPhysicVariables.stappedMovement * Time.fixedDeltaTime);
                rb.angularVelocity = (Vector3.forward * moverPhysicVariables.stappedMovement * Time.fixedDeltaTime);
            }
            yield return null;
           
        }
    }
}
