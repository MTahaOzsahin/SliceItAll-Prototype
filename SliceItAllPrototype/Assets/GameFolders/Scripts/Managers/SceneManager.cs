using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SliceItAll.Scripts.Managers
{
    [CreateAssetMenu(menuName ="Managers/SceneManager")]
    public class SceneManager : ScriptableObject
    {
        public void ExitApplication()
        {
            Application.Quit();
        }
        public void RestartLevel()
        {
            Time.timeScale = 1f;
            int currentLeveIndex = UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex;
            int x = UnityEngine.SceneManagement.SceneManager.sceneCount;
            for (int i = 0; i < x; i++)
            {
                Scene scene = UnityEngine.SceneManagement.SceneManager.GetSceneAt(i);
                UnityEngine.SceneManagement.SceneManager.UnloadSceneAsync(scene);
            }
            UnityEngine.SceneManagement.SceneManager.LoadScene(currentLeveIndex, LoadSceneMode.Single);
        }
        public void NextLevel()
        {
            Time.timeScale = 1f;
            int currentLevelIndex = UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex;
            currentLevelIndex++;
            int x = UnityEngine.SceneManagement.SceneManager.sceneCount;
            for (int i = 0; i < x; i++)
            {
                Scene scene = UnityEngine.SceneManagement.SceneManager.GetSceneAt(i);
                UnityEngine.SceneManagement.SceneManager.UnloadSceneAsync(scene);
            }
            if (currentLevelIndex == UnityEngine.SceneManagement.SceneManager.sceneCountInBuildSettings) return;
            UnityEngine.SceneManagement.SceneManager.LoadScene(currentLevelIndex, LoadSceneMode.Single);
        }
        public void EndLevelScene()
        {
            UnityEngine.SceneManagement.SceneManager.LoadSceneAsync("EndLevel", LoadSceneMode.Additive);
        }
        public void DeadLevelScene()
        {
            Time.timeScale = 0;
            UnityEngine.SceneManagement.SceneManager.LoadSceneAsync("DeadLevel", LoadSceneMode.Additive);
        }
    }
}
