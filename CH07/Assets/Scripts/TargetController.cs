using UnityEngine;

public class TargetController : MonoBehaviour
{
    GameObject player;
    TargetGenerator tg;

    private void Start()
    {
        player = GameObject.Find("Player");
        tg = FindFirstObjectByType<TargetGenerator>();
    }

    private void Update()
    {
        Vector3 targetPos = new(player.transform.position.x, transform.position.y, player.transform.position.z);
        transform.LookAt(targetPos);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Equals("bamsongi"))
        {
            tg.GenerateTarget(player.transform.position);
            Destroy(gameObject);
        }
    }
}
