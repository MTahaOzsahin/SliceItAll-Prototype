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

        private void Start()
        {
            endScoreText.text = "+" + scoreManager._endLevelScore.ToString();
        }
    }
}
