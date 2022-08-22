using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SliceItAll.Scripts.Managers
{
    [CreateAssetMenu(menuName ="Managers/SoundManager")]
    public class SoundManager : ScriptableObject
    {
        [Tooltip("The sound for when player tap.")]
        [SerializeField] AudioClip tappingSound;

        [Tooltip("The sound for when slicing.")]
        [SerializeField] AudioClip sliceSound;

        [Tooltip("The sound for when knife touch floor or sliceable objects with base.")]
        [SerializeField] AudioClip stuckSound;

        [Tooltip("The sound for end level")]
        [SerializeField] AudioClip endLevelSound;
        
        public void TappingSound(AudioSource audioSource)
        {
            audioSource.PlayOneShot(tappingSound);
        }
        public void SlicingSound(AudioSource audioSource)
        {
            audioSource.PlayOneShot(sliceSound);
        }
        public void StuckSound(AudioSource audioSource)
        {
            audioSource.PlayOneShot(stuckSound);
        }
        public void EndLevelSound(AudioSource audioSource)
        {
            audioSource.PlayOneShot(endLevelSound);
        }
    }
}
