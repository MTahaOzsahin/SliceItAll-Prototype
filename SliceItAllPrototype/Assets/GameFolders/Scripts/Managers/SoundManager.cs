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
        [SerializeField,Range(0f,1f)] float tappingSoundVolume;

        [Tooltip("The sound for when slicing.")]
        [SerializeField] AudioClip sliceSound;
        [SerializeField, Range(0f, 1f)] float sliceSoundVolume;

        [Tooltip("The sound for when knife touch floor or sliceable objects with base.")]
        [SerializeField] AudioClip hitSound;
        [SerializeField, Range(0f, 1f)] float hitSoundVolume;

        [Tooltip("The sound for end level")]
        [SerializeField] AudioClip endLevelSound;
        [SerializeField, Range(0f, 1f)] float endLevelSoundVolume;

        [Tooltip("The sound for when player failed.")]
        [SerializeField] AudioClip deadLevelSound;
        [SerializeField, Range(0f, 1f)] float deadLevelSoundVolume;

        public void TappingSound(AudioSource audioSource)
        {
            audioSource.PlayOneShot(tappingSound,tappingSoundVolume);
        }
        public void SlicingSound(AudioSource audioSource)
        {
            audioSource.PlayOneShot(sliceSound,sliceSoundVolume);
        }
        public void StuckSound(AudioSource audioSource)
        {
            audioSource.PlayOneShot(hitSound, hitSoundVolume);
        }
        public void EndLevelSound(AudioSource audioSource)
        {
            audioSource.PlayOneShot(endLevelSound, endLevelSoundVolume);
        }
        public void DeadLevelSound(AudioSource audioSource)
        {
            audioSource.PlayOneShot(deadLevelSound, deadLevelSoundVolume);
        }
    }
}
