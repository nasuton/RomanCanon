using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class score_notation : MonoBehaviour {
    
    //描画する用のクラスです
    [SerializeField]
    GameObject Text;
   

	void Start ()
    {
        GetComponent<TextMesh>().text = "Score : " + Text.GetComponent<score>().ScoreValue.ToString();
    }
	
	void Update ()
    {
        
	}

    //スコアを追加する際に、呼べば表示も変わる
    public void Add_Score()
    {
        GetComponent<TextMesh>().text = "Score : " + Text.GetComponent<score>().ScoreValue.ToString();
    }
}
