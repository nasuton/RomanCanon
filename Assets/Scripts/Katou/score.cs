using UnityEngine;
using UnityEngine.UI;

public class score : MonoBehaviour
{
    private int scoreValue;

    public int ScoreValue
    {
        get { return scoreValue; }
        set { scoreValue = value; }
    }

    static GameObject _instance = null;

    void Awake()
    {
        if (_instance == null)
        {
            DontDestroyOnLoad(gameObject);
            _instance = gameObject;
        }

        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        scoreValue = 0;
    }

    public void addScore(int _score)
    {
        scoreValue += _score;
    }

    public int ReScore()
    {
        return scoreValue;
    }

}
