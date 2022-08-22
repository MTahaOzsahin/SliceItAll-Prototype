using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace SliceItAll.Scripts.Managers
{
    public class UiPopScoreManager : MonoBehaviour
    {
        [SerializeField] ScoreManager scoreManager;
        [SerializeField] GameObject popScoreGameobject;


        private void OnEnable()
        {
            scoreManager.popScoreEvent.AddListener(InstantiatePopScore);
        }
        private void OnDisable()
        {
            scoreManager.popScoreEvent.RemoveListener(InstantiatePopScore);
        }
        public void InstantiatePopScore(int amount,Vector3 position)
        {
            StartCoroutine(PopScoreCoroutine(amount,position));
        }
        IEnumerator PopScoreCoroutine(int amount,Vector3 position)
        {
            if (amount == 0) yield break;
            GameObject _popScoreGameobject = Instantiate(popScoreGameobject, position, Quaternion.identity, this.gameObject.transform);
            _popScoreGameobject.SetActive(true);
            RectTransform rectTransform = _popScoreGameobject.GetComponent<RectTransform>();
            Vector2 screenPoint = RectTransformUtility.WorldToScreenPoint(Camera.main, position);
            Canvas canvas = _popScoreGameobject.GetComponentInParent<Canvas>();
            RectTransform canvasRectTransform = canvas.GetComponent<RectTransform>();
            rectTransform.anchoredPosition3D = screenPoint - canvasRectTransform.sizeDelta / 2;

            yield return new WaitForEndOfFrame();
            TextMeshProUGUI _scoreText = _popScoreGameobject.GetComponentInChildren<TextMeshProUGUI>();
            _scoreText.text = "+" + amount.ToString();
            yield return new WaitForSeconds(1f);
            Destroy(_popScoreGameobject);
        }
    }
}
