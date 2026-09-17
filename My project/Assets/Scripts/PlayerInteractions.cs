using UnityEngine;

public class PlayerInteractions : MonoBehaviour
{
    public int newBullets = 10;

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
            Destroy(other.gameObject);
        }
    }
}
