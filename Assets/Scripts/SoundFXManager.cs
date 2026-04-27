using UnityEngine;

public class SoundFXManager : MonoBehaviour
{
    public static SoundFXManager Instance;
    [SerializeField] private AudioSource audioSource;


    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    public void PlayGameSound(AudioClip audioClip, Transform targetTransform, float volume)
    {
        AudioSource spawnedAudioSource = Instantiate(this.audioSource, targetTransform.position, Quaternion.identity);

        spawnedAudioSource.clip = audioClip;

        spawnedAudioSource.volume = volume;

        spawnedAudioSource.Play();

        float clipLength = spawnedAudioSource.clip.length;

        Destroy(spawnedAudioSource.gameObject, clipLength);

    }
}
