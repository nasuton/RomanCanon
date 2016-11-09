using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class score_notation : MonoBehaviour {
    
    //描画する用のクラスです

    Text text;

    score _score;

	void Start ()
    {
        _score = GetComponent<score>();
        text = GetComponent<Text>();
        
        text.text = "Score : " + _score.ScoreValue;
	}
	
	void Update ()
    {
        
	}

    //スコアを追加する際に、呼べば表示も変わる
    public void Add_Score()
    {
        text.text = "Score : " + _score.ScoreValue;
    }
}
