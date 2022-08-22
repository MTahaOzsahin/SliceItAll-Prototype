using SliceItAll.Scripts.Managers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SliceItAll.Scripts.Controllers.EndLevelController
{
    public class EndLevelController : MonoBehaviour
    {
        [SerializeField] SceneManager gameManager;
        [SerializeField] ScoreManager scoreManager;
        [SerializeField] SoundManager soundManager;

        [SerializeField] int scoreMultiplier;
        public int ScoreMultiplier => scoreMultiplier;
        private void OnTriggerEnter(Collider collider)
        {
            if (collider.gameObject.GetComponent<KnifeController>() != null)
            {
                StartCoroutine(EndLevelCoroutine(collider));
            }
        }

        IEnumerator EndLevelCoroutine(Collider collider )
        {
            collider.gameObject.GetComponent<Rigidbody>().isKinematic = true;
            soundManager.EndLevelSound(this.gameObject.GetComponent<AudioSource>());
            scoreManager.GetTotalScore();
            yield return new WaitForEndOfFrame();
            gameManager.EndLevelScene();
            yield return null;
        }
    }
}
