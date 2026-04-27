using System;
using UnityEngine;

public class SoundFXManager : MonoBehaviour
{
    public static SoundFXManager Instance;
    [SerializeField] private AudioSource audioSource;


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }

    }

    public void playGameSound(AudioClip audioClip, Transform transform, float volume)
    {
        AudioSource audioSource = Instantiate(this.audioSource, transform.position, Quaternion.identity);

        audioSource.clip = audioClip;

        audioSource.volume = volume;

        audioSource.Play();

        float clipLength = audioSource.clip.length;

        Destroy(audioSource.gameObject, clipLength);

    }
}
