using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SliceItAll.Scripts.Managers
{
    [CreateAssetMenu(menuName ="Managers/GameManmager")]
    public class GameManager : ScriptableObject
    {
        public void ExitApplication()
        {
            Application.Quit();
        }
        public void RestartLevel()
        {
            int currentLeve›ndex = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(currentLeve›ndex);
        }
    }
}
