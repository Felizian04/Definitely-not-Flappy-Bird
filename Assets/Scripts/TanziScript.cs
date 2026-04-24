using UnityEngine;

public class TanziScript : MonoBehaviour
{
    public Rigidbody2D rb;
    public float flapStrength;
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.linearVelocity = Vector2.up * flapStrength;
        }
    }
}
