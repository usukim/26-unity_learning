using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(SpriteRenderer))]
public class FloorController : MonoBehaviour
{
    private BoxCollider2D col;
    private SpriteRenderer sr;

    private void Awake()
    {
        col = GetComponent<BoxCollider2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    private void LateUpdate()
    {
        // 현재 최고 높이에 따라 바닥 넓이를 조정 
        Vector2 targetColliderSize = col.size;
        Vector2 targetSpriteSize = sr.size;
        targetColliderSize.x = CameraController.HighestY / 1.8f + 8f;
        targetSpriteSize.x = CameraController.HighestY / 1.8f + 8f;
        col.size = Vector2.Lerp(col.size, targetColliderSize, Time.deltaTime * 3);
        sr.size = Vector2.Lerp(sr.size, targetSpriteSize, Time.deltaTime * 3);
    }
}
