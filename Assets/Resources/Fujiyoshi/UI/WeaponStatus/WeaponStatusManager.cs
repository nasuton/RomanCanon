using UnityEngine;
using System.Collections;

public class WeaponStatusManager : MonoBehaviour {
    [SerializeField]
    GameObject romanGauge;

    public float[] status = new float[5];

    public float[] Status
    {
        get { return status; }
        set { status = value; }
    }

    public struct RomanType
    {
        public enum BurstType
        {
            rocket = 0,
            normal = 1,
            burst = 2,
            tactical = 3
        }
        public BurstType brust;
        public int num;
        public float active_time;
        public float debuf_time;
    }
    public RomanType roman_type;

    
    void romanInit()
    {
        roman_type.brust = (RomanType.BurstType)GameObject.Find("WeaponType").GetComponent<RomanCanonStatus>().BulletNum;
        roman_type.num = GameObject.Find("WeaponType").GetComponent<RomanCanonStatus>().CanRomanModeCount;
        roman_type.active_time = GameObject.Find("WeaponType").GetComponent<RomanCanonStatus>().RomanModeTime;
        roman_type.debuf_time = GameObject.Find("WeaponType").GetComponent<RomanCanonStatus>().DebuffTime;
    }

    void statusInit()
    {
        status = GameObject.Find("WeaponType").GetComponent<NormalPartsStatus>().Status;
    }

    void Awake()
    {
        romanInit();
        statusInit();
    }


    void statusChange()
    {
        //通常時
        if(romanGauge.GetComponent<RomanGauge>().roman_mode == false &&
            romanGauge.GetComponent<RomanGauge>().cool_time_mode == false)
        {
            status = GameObject.Find("WeaponType").GetComponent<NormalPartsStatus>().Status;
        }

        //ロマンモード時
        if(romanGauge.GetComponent<RomanGauge>().roman_mode == true &&
            romanGauge.GetComponent<RomanGauge>().cool_time_mode == false)
        {
            var roman_status = GameObject.Find("WeaponType").GetComponent<RomanPartsStauts>().Status;
            var normal_status = GameObject.Find("WeaponType").GetComponent<NormalPartsStatus>().Status;
            for (int i = 0; i < status.Length; i++)
            {
                status[i] = normal_status[i] * roman_status[i];
            }
            
        }


        //クールタイム時
        if (romanGauge.GetComponent<RomanGauge>().roman_mode == false &&
            romanGauge.GetComponent<RomanGauge>().cool_time_mode == true)
        {
            var down_status = GameObject.Find("WeaponType").GetComponent<DownPartsStatus>().Status;
            var normal_status = GameObject.Find("WeaponType").GetComponent<NormalPartsStatus>().Status;
            for (int i = 0; i < status.Length; i++)
            {
                status[i] = normal_status[i] * down_status[i];
            }
        }
    }

    void Update()
    {
        statusChange();
    }
}
