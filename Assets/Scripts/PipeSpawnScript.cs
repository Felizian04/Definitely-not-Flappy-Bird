using UnityEngine;

public class PipeSpawnScript : MonoBehaviour
{
    [SerializeField] private GameObject pipe;
    [SerializeField] private double spawnRate;
    [SerializeField] private float heightOffset = 10.0f;

    private double timer = 0.0;
    void Start()
    {
        SpawnPipes();
    }

    void Update()
    {
        if (timer > spawnRate)
        {
            SpawnPipes();
            timer = 0.0;
        }
        else
        {
            timer += Time.deltaTime;
        }

    }

    private void SpawnPipes()
    {
        float lowestPoint = transform.position.y - heightOffset;
        float highestPoint = transform.position.y + heightOffset;
        Instantiate(pipe, new Vector3(transform.position.x, Random.Range(lowestPoint, highestPoint), 0.0f), transform.rotation);
    }
}
