using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraController : MonoBehaviour
{
    public static float HighestY = 0f;

    [Header("이동 설정")]
    [SerializeField] private float smoothSpeed = 3f;
    [SerializeField] private float offsetY = 2f;
    [SerializeField] private float minY = 0f;

    [Header("줌 설정")]
    [SerializeField] private float minZoom = 5f;
    [SerializeField] private float maxZoom = 15f;
    [SerializeField] private float zoomSpeed = 2f;

    private Camera _cam;

    private void Awake()
    {
        _cam = GetComponent<Camera>();
        HighestY = minY;
    }

    private void LateUpdate()
    {
        // 카메러 y좌표
        float targetY = Mathf.Max(minY, HighestY + offsetY) * 0.5f;
        Vector3 targetPos = new(transform.position.x, targetY, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, targetPos, smoothSpeed * Time.deltaTime);

        // 카메라 줌
        float targetZoom = minZoom + (HighestY * 0.5f) + 1f;
        targetZoom = Mathf.Clamp(targetZoom, minZoom, maxZoom);
        _cam.orthographicSize = Mathf.Lerp(_cam.orthographicSize, targetZoom, zoomSpeed * Time.deltaTime);
    }
}
