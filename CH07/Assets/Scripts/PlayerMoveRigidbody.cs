using UnityEngine;

public class PlayerMoveRigidbody : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float rotationSpeed = 10f;

    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float xInput = Input.GetAxis("Horizontal");
        float zInput = Input.GetAxis("Vertical");

        float xSpeed = xInput * rotationSpeed * Time.deltaTime;
        float zSpeed = zInput * moveSpeed * Time.deltaTime;

        // transform.Translate(0, 0, zSpeed);
        rb.linearVelocity = zSpeed * transform.forward;
        transform.Rotate(0, xSpeed, 0);
    }
}
