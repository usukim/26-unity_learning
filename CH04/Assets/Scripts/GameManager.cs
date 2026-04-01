using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public GameObject car;
    public GameObject flag;
    // public GameObject text;
    public TextMeshProUGUI distance;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float length = flag.transform.position.x - car.transform.position.x;
        distance.text = "°Å¸®: " + length.ToString("F2") + "m";
    }
}
