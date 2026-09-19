using UnityEngine;

public class Bullet : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("AimShpere"))
        {
            GameManager.Instance.points++;
            GameManager.Instance.textPoints.text = "Points: " + GameManager.Instance.points.ToString();
            Destroy(gameObject);
            Destroy(other.gameObject);
            AudioManager.Instance.PlaySFX(3);
        }
    }
}
