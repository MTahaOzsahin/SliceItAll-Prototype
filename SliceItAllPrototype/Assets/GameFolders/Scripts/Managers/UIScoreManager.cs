using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

namespace SliceItAll.Scripts.Managers
{
    public class UIScoreManager : MonoBehaviour
    {
        [SerializeField] ScoreManager scoreManager;

         TextMeshProUGUI scoreText;
        private void Awake()
        {
            scoreText = GetComponent<TextMeshProUGUI>();
        }
        private void OnEnable()
        {
            scoreManager.scoreChangeEvent.AddListener(ChangeScore);
        }
        private void OnDisable()
        {
            scoreManager.scoreChangeEvent.RemoveListener(ChangeScore);
        }
        public void ChangeScore(int amount)
        {
            scoreText.text = "$" + amount.ToString();
        }

    }
}
