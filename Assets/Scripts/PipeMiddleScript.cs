using UnityEngine;

public class PipeMiddleScript : MonoBehaviour
{
    [SerializeField] private AudioClip audioClip;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == 3 && TanziScript.Instance.tanziIsAlive)
        {
            LogicScript.Instance.AddScore();
            SoundFXManager.Instance.playGameSound(audioClip, transform, 1.0f);
        }
    }
}
