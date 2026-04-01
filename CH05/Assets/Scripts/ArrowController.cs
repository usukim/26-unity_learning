using UnityEngine;

public class ArrowController : MonoBehaviour
{
    public float dropSpeed = 0.1f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // 프레임마다 등속으로 낙하시킨다
        transform.Translate(0, -0.1f, 0);

        // 화면 밖으로 나가면 오브젝트를 소멸시킨다
        if (transform.position.y < -5.0f)
        {
            Destroy(gameObject);
        }
    }
}
