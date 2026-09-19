using UnityEngine;

public class PlayerInteractions : MonoBehaviour
{
    public int newBullets = 10;
    public int newHealth = 1;

    public Animator doorAnimator;
    public float animTime = 0.15f;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            GameManager.Instance.TakeDamage();
            Destroy(other.gameObject);
        }

        if (other.gameObject.CompareTag("AmmoBox"))
        {
            GameManager.Instance.gunAmmo += newBullets;
            GameManager.Instance.textAmmo.text = "Ammo: " + GameManager.Instance.gunAmmo.ToString();
            AudioManager.Instance.PlaySFX(2);
            Destroy(other.gameObject);
        }

        if (other.gameObject.CompareTag("HealBox"))
        {
            GameManager.Instance.health += newHealth;
            GameManager.Instance.textHealth.text = "Health: " + GameManager.Instance.health.ToString();
            AudioManager.Instance.PlaySFX(4);
            Destroy(other.gameObject);
        }

        if (other.gameObject.CompareTag("EnemyRange"))
        {
            GameManager.Instance.playerInRange = true;
        }

        if (other.gameObject.CompareTag("Door"))
        {
            doorAnimator = other.gameObject.GetComponentInChildren<Animator>();
            
            if (doorAnimator != null)
            {
                doorAnimator.SetTrigger("StartOpen");
                AudioManager.Instance.PlaySFX(1);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("EnemyRange"))
        {
            GameManager.Instance.playerInRange = false;
        }

        if (other.gameObject.CompareTag("Door"))
        {
            doorAnimator = other.gameObject.GetComponentInChildren<Animator>();

            if (doorAnimator != null)
            {
                doorAnimator.SetTrigger("StartClose");
                AudioManager.Instance.PlaySFX(1);
            }
        }
    }
}
