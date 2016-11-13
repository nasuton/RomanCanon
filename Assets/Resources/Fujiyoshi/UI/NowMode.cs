using UnityEngine;
using System.Collections;

public class NowMode : MonoBehaviour {

   
	void Start () {
	
	}
	
	void Update () {
        if (GameObject.Find("RomanBar").GetComponent<RomanGauge>().roman_mode)
        {
            this.GetComponent<TextMesh>().color = new Color(1, 0, 0);
            this.GetComponent<TextMesh>().text = "RomanMode";
        }
        else if (GameObject.Find("RomanBar").GetComponent<RomanGauge>().cool_time_mode)
        {
            this.GetComponent<TextMesh>().color = new Color(0,0,1);
            this.GetComponent<TextMesh>().text = "DeBuffMode";
        }
        else
        {
            this.GetComponent<TextMesh>().text = "";
        }
	}
}
