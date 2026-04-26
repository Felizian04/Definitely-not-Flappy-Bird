using System;
using UnityEngine;

public class TanziScript : MonoBehaviour
{
    public static TanziScript Instance { get; private set; }
    public Rigidbody2D rb;
    public float flapStrength;
    [SerializeField] private LogicScript logic;
    public bool tanziIsAlive = true;
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
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
        LogicScript.Instance.GameOver();
        tanziIsAlive = false;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        OnGameOver();
    }
}
