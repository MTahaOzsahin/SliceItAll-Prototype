using Cinemachine;
using SliceItAll.Scripts.Controllers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SliceItAll.Scripts.Managers
{
    public class KnifeChanger : MonoBehaviour
    {
        [SerializeField] KnifeManager knifeManager;

        GameObject activeKnife;

        GameObject targetKnife;

        private void Start()
        {
            activeKnife = FindObjectOfType<KnifeController>().gameObject;
        }
        public void ChangeActiveknife(int i)
        {
            Time.timeScale = 1;
            activeKnife = FindObjectOfType<KnifeController>().gameObject;
            Vector3 originPosition = activeKnife.transform.position;
            targetKnife = knifeManager.SelectKnife(i);
            targetKnife = Instantiate(targetKnife, originPosition,Quaternion.identity);
            Destroy(activeKnife);
            activeKnife = targetKnife;
            var cameraFollow = FindObjectOfType<CinemachineVirtualCamera>();
            cameraFollow.Follow = activeKnife.transform;

        }
    }
}
