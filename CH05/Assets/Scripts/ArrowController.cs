using UnityEngine;

public class ArrowController : MonoBehaviour
{
    GameObject player;
    GameObject director;
    float dropSpeed;
    float minDistance = 1.1f;
    void Start()
    {
        director = GameObject.Find("GameDirector");
        player = GameObject.Find("player");
        dropSpeed = Random.Range(4f, 7f);
    }

    // Update is called once per frame
    void Update()
    {
        // 프레임마다 등속으로 낙하시킨다
        transform.Translate(0, -dropSpeed * Time.deltaTime, 0);

        // 화면 밖으로 나가면 오브젝트를 소멸시킨다
        if (transform.position.y < -5.0f)
        {
            Destroy(gameObject);
        }

        Vector2 p1 = transform.position;
        Vector2 p2 = player.transform.position;
        float distance = (p1 - p2).magnitude;
        if(distance < minDistance)
        {
            director.GetComponent<GameDirector>().DecreaseHP();
            Destroy(gameObject);
        }
    }
}
