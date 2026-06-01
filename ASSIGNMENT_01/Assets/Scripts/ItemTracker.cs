using UnityEngine;

public class ItemTracker : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameDirector.instance.UpdateScore();
        // 최고 높이 감지
        if (transform.position.y > CameraController.HighestY)
        {
            CameraController.HighestY = transform.position.y;
        }
    }

    private void Update()
    {
        // 물건 떨어짐 감지
        if (transform.position.y < -6f)
        {
            GameDirector.instance.ItemFallOut();
            GameDirector.instance.UpdateScore();
            Destroy(gameObject);
        }
    }
}
