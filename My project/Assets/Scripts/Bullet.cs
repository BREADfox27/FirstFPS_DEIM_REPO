using UnityEngine;

public class Bullet : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        if (gameObject.transform.position.x < -10 || gameObject.transform.position.x > 23)
        {
            Destroy(gameObject);
            GameManager.Instance.CalculateAccuracy();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("AimShpere"))
        {
            GameManager.Instance.points++;
            GameManager.Instance.shotsAccurate++;
            GameManager.Instance.textPoints.text = "Points: " + GameManager.Instance.points.ToString();
            GameManager.Instance.SaveScore();
            GameManager.Instance.CalculateAccuracy();

            Destroy(gameObject);
            Destroy(other.gameObject);

            AudioManager.Instance.PlaySFX(3);
        }

        if (other.gameObject.CompareTag("Enemy") && GameManager.Instance.playerInRange == true)
        {
            GameManager.Instance.points++;
            GameManager.Instance.shotsAccurate++;
            GameManager.Instance.textPoints.text = "Points: " + GameManager.Instance.points.ToString();
            GameManager.Instance.SaveScore();
            GameManager.Instance.CalculateAccuracy();

            Destroy(gameObject);
            Destroy(other.gameObject);

            AudioManager.Instance.PlaySFX(3);
        }
    }
}
