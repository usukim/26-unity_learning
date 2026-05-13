using System;
using UnityEngine;

public class TargetGenerator : MonoBehaviour
{
    public GameObject targetPrefab;
    public float minDist = 100f;

    Transform[] targetPositions;

    private void Start()
    {
        targetPositions = GetComponentsInChildren<Transform>();
    }

    public void GenerateTarget(Vector3 playerPos)
    {
        int index;
        do
        {
            index = UnityEngine.Random.Range(1, targetPositions.Length);
            Debug.Log(Vector3.Distance(playerPos, targetPositions[index].position));
        } while (Vector3.Distance(playerPos, targetPositions[index].position) > minDist);

        Vector3 position = targetPositions[index].position;

        GameObject target = Instantiate(
            targetPrefab, position, Quaternion.identity
            );
        target.transform.SetParent(transform);
    }
}
