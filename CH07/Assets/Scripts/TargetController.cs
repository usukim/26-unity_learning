using UnityEngine;

public class TargetController : MonoBehaviour
{
    GameObject player;

    private void Start()
    {
        player = GameObject.Find("Player");
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
            Destroy(gameObject);
        }
    }
}
