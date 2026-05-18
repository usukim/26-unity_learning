using UnityEngine;

public class ItemGenerator : MonoBehaviour
{
    public GameObject applePrefab;
    public GameObject bombPrefab;

    public float span = 1f;
    float delta = 0f;

    void Update()
    {
        delta += Time.deltaTime;
        Debug.Log(Time.deltaTime);
        if (delta > span)
        {
            GameObject item = Instantiate(applePrefab);
            float x = Random.Range(-1, 2);
            float z = Random.Range(-1, 2);
            item.transform.SetParent(transform);
            item.transform.position = new Vector3(x, 5, z);
            
            delta = 0;
        }
    }
}
