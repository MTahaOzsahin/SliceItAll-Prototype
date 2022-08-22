using SliceItAll.Scripts.Managers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SliceItAll.Scripts.Controllers.EndLevelController
{
    public class EndLevelController : MonoBehaviour
    {
        [SerializeField] GameManager gameManager;
        [SerializeField] ScoreManager scoreManager;

        [SerializeField] int scoreMultiplier;
        public int ScoreMultiplier => scoreMultiplier;
        private void OnTriggerEnter(Collider collider)
        {
            if (collider.gameObject.GetComponent<KnifeController>() != null)
            {
                StartCoroutine(EndLevelCoroutine());
            }
        }

        IEnumerator EndLevelCoroutine()
        {
            scoreManager.GetTotalScore();
            yield return new WaitForEndOfFrame();
            gameManager.EndLevelScene();
            yield return null;
        }
    }
}
