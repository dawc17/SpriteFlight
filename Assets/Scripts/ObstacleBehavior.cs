using UnityEngine;

public class ObstacleBehavior : MonoBehaviour
{
    public float minSize = 0.5f;
    public float maxSize = 1.2f;

    public float minSpeed = 750f;
    public float maxSpeed = 900f;

    public float maxSpinSpeed = 10f;

    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        float randomSize = Random.Range(minSize, maxSize);
        float randomSpeed = Random.Range(minSpeed, maxSpeed) / randomSize;
        Vector2 randomDirection = Random.insideUnitCircle;

        transform.localScale = new Vector3(randomSize, randomSize, 1);
        rb.AddForce(randomDirection * randomSpeed);

        float randomTorque = Random.Range(-maxSpinSpeed, maxSpinSpeed);
        rb.AddTorque(randomTorque);
    }

    void Update()
    {

    }
}
