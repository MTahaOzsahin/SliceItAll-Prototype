using UnityEngine;

namespace SliceItAll.Scripts.Managers
{
    public class TimeChanger : MonoBehaviour
    {
        public void StopTime()
        {
            Time.timeScale = 0;
        }
        public void StartTime()
        {
            Time.timeScale = 1;
        }
    }
}
