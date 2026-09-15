using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public int health = 10;
    public TextMeshProUGUI textHealth;
    public int gunAmmo = 50;
    public TextMeshProUGUI textAmmo;

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        textHealth.text = health.ToString();
        textAmmo.text = gunAmmo.ToString();
    }

    void Update()
    {
        
    }
}
