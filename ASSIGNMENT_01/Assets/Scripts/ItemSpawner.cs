using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(SpriteRenderer))]
public class ItemSpawner : MonoBehaviour
{
    [Header("이동 설정")]
    [SerializeField] private float speed = 5f;
    [SerializeField] private float rotateSpeed = 5f;
    [SerializeField] private float xLimit = 8f;
    [SerializeField] private float spawnerHeightOffset = 6f;

    [Header("스폰 설정")]
    [SerializeField] private GameObject[] itemPrefabs;
    [SerializeField] private float dropCooldown = 0.5f;

    [Header("디버그")]
    [SerializeField] private bool fridgeMode = false; // 냉장고모드

    private SpriteRenderer sr;

    private float _moveDirection;
    private float _rotateDirection;
    private float _lastDropTime;
    private int _currentItemIdx;

    private void SelectItem()
    {
        if (itemPrefabs.Length > 0)
        {
            // 랜덤 아이템 인덱스 뽑기
            if (fridgeMode)
                _currentItemIdx = 5;
            else
                _currentItemIdx = Random.Range(0, itemPrefabs.Length);
            GameObject item = itemPrefabs[_currentItemIdx];
            Sprite itemSprite = item.GetComponent<SpriteRenderer>().sprite;

            // 스프라이트 설정
            sr.sprite = itemSprite;
            transform.localScale = item.transform.localScale;
        }
    }

    private void OnMove(InputValue value)
    {
        // 좌우 입력값 저장
        _moveDirection = value.Get<float>();
    }

    private void OnDrop()
    {
        if (Time.time - _lastDropTime < dropCooldown)
        {
            Debug.Log("쿨타임 안 지남");
            return;
        }
        if (itemPrefabs.Length == 0)
        {
            Debug.Log("배열 비어있음");
            return;
        }
        if (GameDirector.isGameOver)
        {
            Debug.Log("게임오버 상태");
            return;
        }

        // 물건 드롭, 다음 물건 고르기
        Instantiate(itemPrefabs[_currentItemIdx], transform.position, transform.rotation);
        SelectItem();

        _lastDropTime = Time.time;
    }

    private void OnRotate(InputValue value)
    {
        // 회전 입력값 저장
        _rotateDirection = value.Get<float>();
    }

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();

        SelectItem();
    }

    private void FixedUpdate()
    {
        // 다음 X 좌표 계산
        float newX = transform.position.x + (_moveDirection * speed * Time.deltaTime);
        newX = Mathf.Clamp(newX, -xLimit, xLimit);

        // X 좌표 반영
        transform.position = new Vector3(newX, CameraController.HighestY + spawnerHeightOffset, transform.position.z);

        // 회전 반영
        transform.Rotate(0, 0, _rotateDirection * rotateSpeed * Time.deltaTime);
    }
}
