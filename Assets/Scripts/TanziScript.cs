using UnityEngine;

public class TanziScript : MonoBehaviour
{
    public static TanziScript Instance { get; private set; }
    public Rigidbody2D rb;
    public float flapStrength;
    public bool tanziIsAlive = true;
    [SerializeField] private AudioClip tanziScream;
    void Start()
    {

    }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
        }
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && tanziIsAlive)
        {
            rb.linearVelocity = Vector2.up * flapStrength;
        }

        if (gameObject.transform.position.y is > 17.0f or < -17.0f)
        {
            Instance.OnGameOver();
        }
    }

    private void OnGameOver()
    {
        if (tanziIsAlive)
        {
            LogicScript.Instance.GameOver();
            tanziIsAlive = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        SoundFXManager.Instance.PlayGameSound(tanziScream, transform, 1.0f);
        OnGameOver();
    }
}
