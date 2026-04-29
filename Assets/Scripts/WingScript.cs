using UnityEngine;

public class WingScript : MonoBehaviour
{
    [SerializeField] private TanziScript tanziScript;
    public Rigidbody2D rb;

    private float flapStrength;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        flapStrength = tanziScript.flapStrength;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && TanziScript.Instance.tanziIsAlive)
        {
            rb.linearVelocity = Vector2.up * flapStrength;
        }

        if (gameObject.transform.position.y is > 17.0f or < -17.0f)
        {
            TanziScript.Instance.OnGameOver();
        }

    }
}
