using UnityEngine;
using System.Collections;

public class CoolingGauge : MonoBehaviour {

    public bool isShoted = false;
    public bool canShot = true;
    public float rate = 0.0f;
    private float fire_count = 0.0f;
    private bool cool_time = false; 
    void Default()
    {
        if(false == cool_time && true == canShot)
        {
            fire_count += GameObject.Find("WeaponType").GetComponent<NormalPartsStatus>().Status[1] /
                GameObject.Find("WeaponType").GetComponent<NormalPartsStatus>().Status[3] + Time.deltaTime;

            if(GameObject.Find("WeaponType").GetComponent<NormalPartsStatus>().Status[3] <= fire_count){
                cool_time = true;
                canShot = false;
            }
        }
    }

    void CoolTime()
    {
        if (true == cool_time || false == isShoted ||  0.0f <= fire_count)
        {
            fire_count -= Time.deltaTime * (70 + GameObject.Find("WeaponType").GetComponent<NormalPartsStatus>().Status[4]);
        }
    }
    void Rate()
    {

    }
    void ChangeSize()
    {

    }
	void Start () {
        rate = 1 / (60 - GameObject.Find("WeaponType").GetComponent<NormalPartsStatus>().Status[2]);
    }
	
	// Update is called once per frame
	void Update () {
        Default();
        CoolTime();
        ChangeSize();
    }
}
