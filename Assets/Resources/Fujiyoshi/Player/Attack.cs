using UnityEngine;
using System.Collections;


public class Attack : MonoBehaviour {
    public enum WeaponType
    {
        NONE = -1,
        MINI_GUN,
        ROCKET_LAUNCHER,
        RAIL_GUN
    }
    private int weapon_type;
    private float damage_count;
    void Start()
    {
        var type = GameObject.Find("WeaponType");
         weapon_type = type.GetComponent<WeaponTypeManager>().asset.WeaponNum;
    }
    void OnTriggerEnter(Collider other)
    {
       
        if (weapon_type == (int)WeaponType.MINI_GUN)
        {
            other.GetComponent<enemy_state>().Hp -= (int)GameObject.Find("WeaponType").GetComponent<NormalPartsStatus>().Status[0];
            Destroy(this);
        }
        if (weapon_type == (int)WeaponType.ROCKET_LAUNCHER)
        {
            other.GetComponent<enemy_state>().Hp -= (int)GameObject.Find("WeaponType").GetComponent<NormalPartsStatus>().Status[0];
            Destroy(this);
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (weapon_type == (int)WeaponType.RAIL_GUN)
        {
            if(0 > damage_count)
            {
                other.GetComponent<enemy_state>().Hp -= (int)GameObject.Find("WeaponType").GetComponent<NormalPartsStatus>().Status[0];
                damage_count = 1 - GameObject.Find("WeaponType").GetComponent<NormalPartsStatus>().Status[3];
            }
            damage_count -= Time.deltaTime;
           
        }
    }
}
