using UnityEngine;

public class ArrowGenerator : MonoBehaviour
{
    public GameObject arrowPrefab;
    public float span = 0.3f;
    float delta = 0f;

    void Update()
    {
        delta += Time.deltaTime;
        if (delta > span)
        {
            GameObject go = Instantiate(arrowPrefab);
            float px = Random.Range(-8f, 8f);
            go.transform.position = new Vector3(px, 6f, 0);

            delta = 0;
        }
    }
}
