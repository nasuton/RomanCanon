using UnityEngine;
using System.Collections;

public class BulletOfMiniGun : MonoBehaviour {

	void Awake () {
        this.GetComponent<BulletDamege>().Damege = GameObject.Find("WeaponStatus").GetComponent<WeaponStatusManager>().Status[0];
    }
}
