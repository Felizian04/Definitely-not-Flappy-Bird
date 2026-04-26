using UnityEngine;

public class PipeMoveScript : MonoBehaviour
{

    [SerializeField] private float moveSpeed = 5;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (TanziScript.Instance.tanziIsAlive)
        {
            transform.position += Vector3.left * (moveSpeed * Time.deltaTime);

        }

        if (transform.position.x < -25)
        {
                Destroy(gameObject);
                Debug.Log("Pipe destroyed");
        }
    }
}
