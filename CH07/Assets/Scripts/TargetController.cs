using UnityEngine;

public class TargetController : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Equals("bamsongi"))
        {
            Destroy(gameObject);
        }
    }
}
