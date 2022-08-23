using SliceItAll.Scripts.Managers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SliceItAll.Scripts.Controllers.DeadBoxController
{
    public class DeadBoxCollider : MonoBehaviour
    {
        [SerializeField] SceneManager sceneManager;
        [SerializeField] SoundManager soundManager;
        private void OnTriggerEnter(Collider collider)
        {
            if (collider.gameObject.GetComponent<KnifeController>() != null)
            {
                StartCoroutine(DeadLevelCoroutine());
            }
        }
        IEnumerator DeadLevelCoroutine()
        {
            soundManager.DeadLevelSound(this.gameObject.AddComponent<AudioSource>());
            yield return new WaitForEndOfFrame();
            sceneManager.DeadLevelScene();
            yield return null;
        }
    }
}
