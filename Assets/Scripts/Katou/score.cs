using UnityEngine;
using UnityEngine.UI;

public class score : MonoBehaviour
{
    public int scoreCount;

    void Start()
    {
        scoreCount = 0;
        GetComponent<Text>().text = "Score " + scoreCount.ToString();
    }

    void Update()
    {
        GetComponent<Text>().text = "Score " + scoreCount.ToString();
    }

}
