using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SliceItAll.Scripts.Managers
{
    [CreateAssetMenu(menuName ="Managers/KnifeManager")]
    public class KnifeManager : ScriptableObject
    {
        [SerializeField] GameObject[] knifes; 
        public GameObject SelectKnife(int index)
        {
            return knifes[index];
        }
    }
}
