using UnityEngine;

public class InstantiateObj : MonoBehaviour
{
    public GameObject[] objects;
    public GameObject currentObj = null;
    public Transform spawnObj;

    public float objRate = 5f;
    private float objRateTime = 0;


    void Start()
    {
        currentObj = null;
    }
    
    void Update()
    {
        if (currentObj == null)
        {
            objRateTime += Time.deltaTime;
            
            if (objRateTime >= objRate)
            {
                GameObject newObj = Instantiate(objects[0], spawnObj.position, spawnObj.rotation);
                currentObj = newObj;

                objRateTime = 0;
            }
        }
    }
}
