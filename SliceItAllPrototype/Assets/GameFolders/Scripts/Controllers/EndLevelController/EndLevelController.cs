using SliceItAll.Scripts.Managers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SliceItAll.Scripts.Controllers.EndLevelController
{
    public class EndLevelController : MonoBehaviour
    {
        [SerializeField] GameManager gameManager;
        private void OnTriggerEnter(Collider collider)
        {
            if (collider.gameObject.GetComponent<KnifeController>() != null)
            {
                StartCoroutine(EndLevelCoroutine());
            }
        }

        IEnumerator EndLevelCoroutine()
        {
            Time.timeScale = 0f;
            yield return new WaitForEndOfFrame();
            gameManager.EndLevelScene();
            yield return null;
        }
    }
}
