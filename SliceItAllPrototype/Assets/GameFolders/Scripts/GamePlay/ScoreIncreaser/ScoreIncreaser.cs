using SliceItAll.Scripts.Managers;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace SliceItAll.Scripts.GamePlay.ScoreIncreaser
{
    public class ScoreIncreaser : MonoBehaviour
    {
        [SerializeField] ScoreManager scoreManager;
        TextMeshProUGUI scoreText;
        [SerializeField] int countFPS = 30;
        [SerializeField] float duration = 1f;
        [SerializeField] string numberFormat = "N0";
        private int _value = 0;
        public int Value
        {
            get
            {
                return _value;
            }
            set
            {
                UpdateText(value);
                _value = value;
            }
        }
        private Coroutine CountingCoroutine;

        private void Awake()
        {
            scoreText = GetComponent<TextMeshProUGUI>();
        }
        private void Start()
        {
            SetValue();
        }
        private void UpdateText(int newValue)
        {
            if (CountingCoroutine != null)
            {
                StopCoroutine(CountingCoroutine);
            }

            CountingCoroutine = StartCoroutine(CountText(newValue));
        }

        private IEnumerator CountText(int newValue)
        {
            WaitForSeconds Wait = new WaitForSeconds(1f / countFPS);
            int previousValue = _value;
            int stepAmount;

            if (newValue - previousValue < 0)
            {
                stepAmount = Mathf.FloorToInt((newValue - previousValue) / (countFPS * duration)); // newValue = -20, previousValue = 0. CountFPS = 30, and Duration = 1; (-20- 0) / (30*1) // -0.66667 (ceiltoint)-> 0
            }
            else
            {
                stepAmount = Mathf.CeilToInt((newValue - previousValue) / (countFPS * duration)); // newValue = 20, previousValue = 0. CountFPS = 30, and Duration = 1; (20- 0) / (30*1) // 0.66667 (floortoint)-> 0
            }

            if (previousValue < newValue)
            {
                while (previousValue < newValue)
                {
                    previousValue += stepAmount;
                    if (previousValue > newValue)
                    {
                        previousValue = newValue;
                    }

                    scoreText.SetText(previousValue.ToString(numberFormat));

                    yield return Wait;
                }
            }
            else
            {
                while (previousValue > newValue)
                {
                    previousValue += stepAmount; // (-20 - 0) / (30 * 1) = -0.66667 -> -1              0 + -1 = -1
                    if (previousValue < newValue)
                    {
                        previousValue = newValue;
                    }

                    scoreText.SetText(previousValue.ToString(numberFormat));

                    yield return Wait;
                }
            }
        }
        public void SetValue()
        {

            Value = scoreManager._endLevelScore;
        }
    }
}
