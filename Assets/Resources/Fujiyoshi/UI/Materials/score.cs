using UnityEngine;
using UnityEngine.UI;

//ここではあくまでScoreを記録するだけ
//Scoreの描画は新しいクラスを作ること

public class score : MonoBehaviour
{
    private int scoreValue;
    [SerializeField]
    GameObject obj;
    public int ScoreValue
    {
        get { return scoreValue; }
        set { scoreValue = value;
            obj.GetComponent<score_notation>().Add_Score();
        }
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
}
