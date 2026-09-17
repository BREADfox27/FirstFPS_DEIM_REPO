using UnityEngine;

public class AmmoBox : MonoBehaviour
{
    [Header("Rotation")]
    public float speedX;
    public float speedY;
    public float speedZ;

    [Header("Levitation")]
    public float amplitude;
    public float speed;

    private Vector3 initialPosition;

    void Start()
    {
        initialPosition = transform.position;
    }

    void Update()
    {
        RotateObject();
        LevitateObj();
    }

    void RotateObject()
    {
        transform.Rotate(Vector3.right * speedX * Time.deltaTime);
        transform.Rotate(Vector3.up * speedY * Time.deltaTime);
        transform.Rotate(Vector3.forward * speedZ * Time.deltaTime);
    }

    void LevitateObj()
    {
        float newY = initialPosition.y + Mathf.Sin(Time.time * speed) * amplitude;
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }
}
