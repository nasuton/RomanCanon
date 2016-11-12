using UnityEngine;
using System.Collections;

public class CoolingGauge : MonoBehaviour
{

    public bool isShoted = false;
    public bool canShot = true;
    public float rate = 0.0f;
    public float fire_count = 0.0f;
  

    //冷却
    private float type_cool;
    //反射可能時間
    private float type_fire_count;
    //反射可能時間
    private float type_rate;
    public int a;
    public void Default()
    {

        fire_count++;
        if (type_fire_count <= (int)fire_count)
        {
            canShot = false;
        }

    }

    public void Cooling()
    {
        if (isShoted == false && 0.0f < (int)fire_count)
        {
            fire_count -= type_cool * Time.deltaTime;
        }
    }
    void CoolTime()
    {
        if (canShot == false)
        {
            if ((int)fire_count == 0.0f)
            {
                canShot = true;
            }
        }
    }
    void Rate()
    {
        rate = 1 / (60 - type_rate);
    }
   
    void Init()
    {
        type_cool = GameObject.Find("WeaponStatus").GetComponent<WeaponStatusManager>().Status[4];
        type_fire_count = GameObject.Find("WeaponStatus").GetComponent<WeaponStatusManager>().Status[3];
        type_rate = GameObject.Find("WeaponStatus").GetComponent<WeaponStatusManager>().Status[1];

    }
    void Start()
    {

        Init();
        Rate();
    }
  

    void ChangeSize()
    {
        this.transform.localScale = new Vector3(fire_count / type_fire_count, 1, 1);
        this.transform.localPosition = new Vector3(-3.72f - (fire_count / type_fire_count) * -3.72f, 0, 0);
    }
    void Update()
    {
        CoolTime();
        ChangeSize();
    }
}
