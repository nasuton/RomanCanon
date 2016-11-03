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
        
    }

    public void addScore(int _score)
    {
        scoreCount += _score;
        GetComponent<Text>().text = "Score " + scoreCount.ToString();
    }

    public int ReScore()
    {
        return scoreCount;
    }

}
