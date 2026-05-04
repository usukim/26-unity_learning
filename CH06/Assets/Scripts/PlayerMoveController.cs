using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerMoveController : MonoBehaviour
{
    public float jumpForce = 300f;
    public float walkForce = 30f;
    public float maxWalkSpeed = 1f;

    public Sprite[] walkSprites;
    public Sprite jumpSprite;
    public float animationPeriod = 0.2f;

    float time = 0;
    int key = 0;
    SpriteRenderer sr;
    Rigidbody2D rb;
    Animator anim;

    void Start()
    {
        Application.targetFrameRate = 60;
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (
            Mouse.current.leftButton.wasPressedThisFrame
            && rb.linearVelocityY == 0
            )
        {
            rb.AddForce(transform.up * jumpForce);
        }

        if (rb.linearVelocityX < maxWalkSpeed)
        {
            rb.AddForce(transform.right * walkForce * key);
        }

        time += Time.deltaTime;

        if (rb.linearVelocityY != 0)
        {
            anim.SetBool("isJumped", true);
        }
        else //if (time > animationPeriod)
        {
            anim.SetBool("isJumped", false);
        }

        //if (rb.linearVelocityY != 0)
        //{
        //    sr.sprite = jumpSprite;
        //}
        //else if (time > animationPeriod)
        //{
        //    time = 0;
        //    sr.sprite = walkSprites[idx];
        //    idx++;
        //    if (idx > 1)
        //    {
        //        idx = 0;
        //    }
        //}

        anim.speed = Mathf.Abs(rb.linearVelocityX);

        if (transform.position.y < -8)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        SceneManager.LoadScene("ClearScene");
        Debug.Log("¼º°ø");
    }
}