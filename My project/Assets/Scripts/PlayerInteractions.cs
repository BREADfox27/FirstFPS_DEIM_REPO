using UnityEngine;

public class PlayerInteractions : MonoBehaviour
{
    
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
    }
}
