using UnityEngine;

public class RandomInstance : MonoBehaviour
{
    [Header("Position")]
    public float minX;
    public float maxX;

    public float minY;
    public float maxY;

    public float minZ;
    public float maxZ;

    void Start()
    {
        RandomPosition();
    }
    
    void Update()
    {
        
    }

    public void RandomPosition()
    {
        float randomX = Random.Range(minX, maxX);
        float randomY = Random.Range(minY, maxY);
        float randomZ = Random.Range(minZ, maxZ);

        Vector3 randomPosition = new Vector3(randomX, randomY, randomZ);

        gameObject.transform.position = randomPosition;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            GameManager.Instance.points += 1;
            GameManager.Instance.textPoints.text = "Points: " + GameManager.Instance.points.ToString();
            Destroy(gameObject);
        }
    }
}
