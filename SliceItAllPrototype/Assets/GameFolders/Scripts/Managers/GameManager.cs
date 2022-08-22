using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SliceItAll.Scripts.Managers
{
    [CreateAssetMenu(menuName ="Managers/GameManager")]
    public class GameManager : ScriptableObject
    {
        [SerializeField] ScoreManager scoreManager;
        [SerializeField] SoundManager soundManager;
        [SerializeField] SceneManager sceneManager;
    }
}
