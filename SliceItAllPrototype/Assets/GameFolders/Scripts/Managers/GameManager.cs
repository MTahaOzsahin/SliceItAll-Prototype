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
            Time.timeScale = 1f;
            int currentLeveIndex = SceneManager.GetActiveScene().buildIndex;
            int x = SceneManager.sceneCount;
            for (int i = 0; i < x; i++)
            {
                Scene scene = SceneManager.GetSceneAt(i);
                SceneManager.UnloadSceneAsync(scene);
            }
            SceneManager.LoadScene(currentLeveIndex,LoadSceneMode.Single);
        }
        public void NextLevel()
        {
            Time.timeScale = 1f;
            int currentLevelIndex = SceneManager.GetActiveScene().buildIndex;
            currentLevelIndex++;
            int x = SceneManager.sceneCount;
            for (int i = 0; i < x; i++)
            {
                Scene scene = SceneManager.GetSceneAt(i);
                SceneManager.UnloadSceneAsync(scene);
            }
            if (currentLevelIndex == SceneManager.sceneCountInBuildSettings) return;
            SceneManager.LoadScene(currentLevelIndex, LoadSceneMode.Single);
        }
        public void EndLevelScene()
        {
            Time.timeScale = 0f;
            SceneManager.LoadSceneAsync("EndLevel", LoadSceneMode.Additive);
        }
    }
}
