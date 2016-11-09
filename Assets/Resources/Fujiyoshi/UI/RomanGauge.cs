using UnityEngine;
using System.Collections;

public class RomanGauge : MonoBehaviour {
    public float roman_value = 0.0f;

    [SerializeField]
    private float roman_max = 100.0f;

    public bool roman_mode = false;

	// Use this for initialization
	void Start () {
	
	}
    public void chargeRomenGaouge(float value)
    {
        if (roman_mode == false)
        {
            if (roman_value <= roman_max)
            {
                roman_value += value;
            }
            if (roman_value > roman_max)
            {
                roman_value = roman_max;
            }
        }
    }
    void changeRomanMode()
    {
        if ((int)roman_value == (int)roman_max)
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                roman_mode = true;
                var obj = GameObject.CreatePrimitive(PrimitiveType.Cube);
                obj.transform.position = new Vector3(0, 0, 10);
            }
        }
    }
    void gaugeChange()
    {
        //this.transform.localScale = new Vector3(roman_value/roman_max,0,0);
        //this.transform.localScale = new Vector3(3.83f-(roman_value / roman_max)*3.83f, 0, 0);
    }
	
	void Update () {
        changeRomanMode();
        //gaugeChange();
    }
}
