using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform player;
    public Transform shotParent;
    public Transform bulletSpawn;
    public GameObject enemyBullet;

    public float shotRate = 2f;
    private float shotRateTime;

    void Start()
    {
        if (player == null)
        {
            GameObject playerFound = GameObject.Find("PlayerFollowCamera");
            player = playerFound.transform;
        }
    }

    void Update()
    {
        if (GameManager.Instance.playerInRange == true)
        {
            shotParent.GetComponent<Transform>().transform.LookAt(player);
            Shoot();
        }
    }

    public void Shoot()
    {
        if (Time.time > shotRateTime)
        {
            GameObject newBullet = Instantiate(enemyBullet, bulletSpawn.position, bulletSpawn.rotation);
            newBullet.GetComponent<Rigidbody>().AddForce(bulletSpawn.forward * GameManager.Instance.shotForce);
            AudioManager.Instance.PlaySFX(0);

            shotRateTime = Time.time + shotRate;

            Destroy(newBullet, 3);
        }
    }
}
