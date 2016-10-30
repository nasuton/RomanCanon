using UnityEngine;
using UnityEngine.UI;

public class timer : MonoBehaviour
{
    public float max_Count = 40.0f;

    private float countTimer;

     void Start()
    {
        countTimer = max_Count;
    }

    void Update()
    {
        countTimer -= Time.deltaTime;
        if(30.0f > countTimer)
        {
            GetComponent<Text>().text = "Time " + countTimer.ToString("F2");
        }
        else
        {
            GetComponent<Text>().text = "Time " + ((int)countTimer).ToString();
        }
        

    }

}
