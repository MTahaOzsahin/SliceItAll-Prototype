using DG.Tweening;
using SliceItAll.Scripts.Controllers.EndLevelController;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace SliceItAll.Scripts.Managers
{
    public class UiEndCanvasManager : MonoBehaviour
    {
        [SerializeField] ScoreManager scoreManager;
        [SerializeField] TextMeshProUGUI endScoreText;

        EndLevelController endLevelController;

        //[SerializeField] GameObject imageToMove;
        //[SerializeField] GameObject targetPosition;

        private void Start()
        {
            endScoreText.text = "+" + scoreManager._endLevelScore.ToString();
            //StartCoroutine(MoveStartCoroutine());
            
        }
        //IEnumerator MoveStartCoroutine()
        //{
        //    yield return new WaitForSeconds(1f);
        //    imageToMove.transform.DOLocalMove(targetPosition.transform.position, 1f, true);
        //    yield return new WaitForSeconds(2f);
        //    imageToMove.SetActive(false);
        //    yield return null;
        //}
    }
}
