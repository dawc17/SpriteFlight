using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float thrustForce = 1.7f;
    public float maxSpeed = 5f;
    public GameObject booster;
    Rigidbody2D rb;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    void Update()
    {
        if (Mouse.current.leftButton.isPressed)
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Mouse.current.position.value);
            Vector2 direction = (mousePos - transform.position).normalized;
            transform.up = direction;
            rb.AddForce(direction * thrustForce);
            if (rb.linearVelocity.magnitude > maxSpeed)
            {
                rb.linearVelocity = rb.linearVelocity.normalized * maxSpeed;
            }
        }

        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            booster.SetActive(true);
        } 
        else if (Mouse.current.leftButton.wasReleasedThisFrame)
        {
            booster.SetActive(false); 
        }
    }
}
