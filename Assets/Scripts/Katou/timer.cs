using UnityEngine;
using UnityEngine.UI;

public class timer : MonoBehaviour
{
    [SerializeField]
    private float max_Count = 40.0f;

    public float countTimer;

    void Awake()
    {
        countTimer = max_Count;
    }

    void Update()
    {
        if (0.0f >= countTimer)
        {
            countTimer = 0;

            GetComponent<Text>().text = "Time " + countTimer.ToString("F2");
        }
        else
        {
            countTimer -= Time.deltaTime;

            GetComponent<Text>().text = "Time " + countTimer.ToString("F2");
        }

    }

}
