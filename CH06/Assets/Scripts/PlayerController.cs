using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float jumpForce = 300f;
    public float walkForce = 30f;
    public float maxWalkSpeed = 1f;

    public Sprite[] walkSprites;
    public float animationPeriod = 0.1f;

    float time = 0;
    int idx = 0;
    SpriteRenderer sr;

    Rigidbody2D rb;

    void Start()
    {
        Application.targetFrameRate = 60;
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            rb.AddForce(transform.up * jumpForce);
        }

        if (rb.linearVelocityX < maxWalkSpeed)
        {
            rb.AddForce(transform.right * walkForce);
        }

        time += Time.deltaTime;
        if(time > animationPeriod)
        {
            time = 0;
            sr.sprite = walkSprites[idx];
            idx += 1;
            if (idx > 8)
            {
                idx = 0;
            }
        }
    }
}
