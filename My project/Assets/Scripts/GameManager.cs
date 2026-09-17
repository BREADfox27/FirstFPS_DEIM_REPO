using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public int health = 10;
    public TextMeshProUGUI textHealth;
    public int gunAmmo = 50;
    public TextMeshProUGUI textAmmo;

    public GameObject player;
    public GameObject respawnPoint;

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        textHealth.text = "Health: " + health.ToString();
        textAmmo.text = "Ammo: " + gunAmmo.ToString();
    }

    void Update()
    {
        
    }

    public void TakeDamage()
    {
        health -= 1;
        textHealth.text = "Health: " + health.ToString();

        if (health <= 0)
        {
            Respawn();
        }
    }

    public void Respawn()
    {
        player.GetComponentInChildren<CharacterController>().enabled = false;
        player.transform.position = respawnPoint.transform.position;
        player.transform.rotation = respawnPoint.transform.rotation;
        player.GetComponentInChildren<CharacterController>().enabled = true;
        health = 10;
        textHealth.text = "Health: " + health.ToString();
    }
}
