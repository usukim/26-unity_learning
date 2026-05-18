using UnityEngine;

public class BasketController : MonoBehaviour
{
    public AudioClip appleSE;
    public AudioClip bombSE;

    AudioSource aud;

    void Start()
    {
        Application.targetFrameRate = 60;
        aud = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity))
            {
                float x = Mathf.RoundToInt(hit.point.x);
                float z = Mathf.RoundToInt(hit.point.z);
                transform.position = new Vector3(x, 0, z);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Apple")
        {
            aud.PlayOneShot(appleSE);
            Debug.Log("사과를 잡았다");
        }
        else if (other.gameObject.tag == "Bomb")
        {
            aud.PlayOneShot(bombSE);
            Debug.Log("폭탄을 잡았다");
        }
        
        Destroy(other.gameObject);
    }
}
