using System.Collections;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    
    [Header("Game Data")]
    public int health = 10;
    public TextMeshProUGUI textHealth;
    public int gunAmmo = 50;
    public TextMeshProUGUI textAmmo;
    public float points = 0;
    public TextMeshProUGUI textPoints;
    public bool playerInRange = false;
    public bool isGamePaused = false;

    [Header("Player")]
    public GameObject player;
    public GameObject respawnPoint;
    public Animator damagePanelAnim;
    public float damageAnimTime = 0.20f;

    [Header("Shoot")]
    public GameObject gun;
    public GameObject bullet;
    public Transform bulletSpawn;

    public float shotForce = 1500f;
    public float shotRate = 0.25f;
    public float recoilForce = 2f;

    private float shotRateTime = 0;

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        textHealth.text = "Health: " + health.ToString();
        textAmmo.text = "Ammo: " + gunAmmo.ToString();
        textPoints.text = "Points: " + points.ToString();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && gunAmmo > 0)
        {
            Shoot();
        }

        gun.transform.localPosition = Vector3.Lerp(gun.transform.localPosition, Vector3.zero, Time.deltaTime * 5f);
        gun.transform.localRotation = Quaternion.Lerp(gun.transform.localRotation, Quaternion.Euler(0f, 0f, 0f), Time.deltaTime * 5f);
    }

    public void TakeDamage()
    {
        health--;
        textHealth.text = "Health: " + health.ToString();
        StartCoroutine(PanelFade());
        AudioManager.Instance.PlaySFX(6);

        if (health <= 0)
        {
            Respawn();
        }
    }

    public void Respawn()
    {
        player.GetComponent<CharacterController>().enabled = false;
        player.transform.position = respawnPoint.transform.position;
        player.transform.rotation = respawnPoint.transform.rotation;
        player.GetComponent<CharacterController>().enabled = true;
        AudioManager.Instance.PlaySFX(5);
        playerInRange = false;

        health = 10;
        textHealth.text = "Health: " + health.ToString();
    }

    public void Shoot()
    {
        if (isGamePaused == false)
        {
            if (Time.time > shotRateTime)
            {
                GameObject newBullet = Instantiate(bullet, bulletSpawn.position, bulletSpawn.rotation);
                newBullet.GetComponent<Rigidbody>().AddForce(bulletSpawn.forward * shotForce);
                AddRecoil();
                AudioManager.Instance.PlaySFX(0);

                gunAmmo--;
                textAmmo.text = "Ammo: " + gunAmmo.ToString();

                shotRateTime = Time.time + shotRate;

                Destroy(newBullet, 3);
            }
        }
    }

    private void AddRecoil()
    {
        gun.transform.Rotate(-recoilForce, 0f, 0f);
        gun.transform.position -= gun.transform.forward * (recoilForce / 50f);
    }

    public IEnumerator PanelFade()
    {
        damagePanelAnim.SetTrigger("StartFade");
        yield return new WaitForSeconds(damageAnimTime);
        damagePanelAnim.SetTrigger("EndFade");
    }
}
