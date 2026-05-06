using UnityEngine;

public class BamsongiController : MonoBehaviour
{
    public new Renderer renderer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Application.targetFrameRate = 60;
        // Shoot(new Vector3(10.0f, 200.0f, 2000.0f));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Shoot(Vector3 dir)
    {
        GetComponent<Rigidbody>().AddForce(dir);
    }

    private void OnCollisionEnter(Collision collision)
    {
        renderer.enabled = false;
        GetComponent<Rigidbody>().isKinematic = true;
        GetComponent<SphereCollider>().enabled = false;
        GetComponent<ParticleSystem>().Play();
        Destroy(gameObject, 1f);
    }
}
