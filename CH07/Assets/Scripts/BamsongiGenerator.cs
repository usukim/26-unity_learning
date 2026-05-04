using UnityEngine;

public class BamsongiGenerator : MonoBehaviour
{
    public GameObject bamsongiPrefab;
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject bamsongi = Instantiate(bamsongiPrefab);
            Vector3 dir = new Vector3(0, 200.0f, 1000.0f);
            bamsongi.GetComponent<BamsongiController>().Shoot(dir);
        }
    }
}
