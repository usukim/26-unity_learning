using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float speed = 10f;
    void Start()
    {
        Application.targetFrameRate = 60;
    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.leftArrowKey.IsPressed())
        {
            transform.Translate(-speed * Time.deltaTime, 0, 0);
        }
        if (Keyboard.current.rightArrowKey.IsPressed())
        {
            transform.Translate(speed * Time.deltaTime, 0, 0);
        }
    }
    public void LButtonDown()
    {
        transform.Translate(-speed * Time.deltaTime * 2f, 0, 0);
    }
    public void RButtonDown()
    {
        transform.Translate(speed * Time.deltaTime * 2f, 0, 0);
    }
}
