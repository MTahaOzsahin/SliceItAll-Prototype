using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace SliceItAll.Scripts.Managers
{
    [CreateAssetMenu(menuName ="Managers/ScoreManager")]
    public class ScoreManager : ScriptableObject
    {
        public int currentScore;
        public int _endLevelScore;

        [System.NonSerialized]
        public UnityEvent<int> scoreChangeEvent;
        public UnityEvent<int,Vector3> popScoreEvent;

        private void OnEnable()
        {
            if (scoreChangeEvent == null)
            {
                scoreChangeEvent = new UnityEvent<int>();
            }
        }
        public void HandleScore(int amount,Vector3 position) 
        {
            currentScore += amount;
            scoreChangeEvent?.Invoke(currentScore);
            popScoreEvent?.Invoke(amount,position);
        }
        public void EndLevelScore(int endLevelScore)
        {
            _endLevelScore = endLevelScore;
        }
    }
}
