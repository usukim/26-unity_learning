using UnityEngine;

public class RouletteController : MonoBehaviour
{
    float rotSpeed = 0.0f;
    void Start()
    {
        Application.targetFrameRate = 60;
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            this.rotSpeed += 0.1f;
        }

        transform.Rotate(0, 0, rotSpeed);
    }
}
