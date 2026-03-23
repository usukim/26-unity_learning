using UnityEngine;

public class RouletteController : MonoBehaviour
{
    float startSpeed = 30f;
    float decreaseRatio = 0.99f;

    float rotSpeed = 0f;
    void Start()
    {
        Application.targetFrameRate = 60;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            this.rotSpeed = startSpeed;
        }

        transform.Rotate(0, 0, rotSpeed);

        this.rotSpeed *= decreaseRatio;
    }
}
