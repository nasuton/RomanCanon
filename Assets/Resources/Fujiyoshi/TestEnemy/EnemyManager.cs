using UnityEngine;
using System.Collections;

public class EnemyManager : MonoBehaviour {
    public float hp;

   void OnTriggerEnter(Collider other) {  
        if (other.gameObject.name == "Bullet(Clone)"){
            Destroy(other.gameObject);
            hp -= GameObject.Find("WeaponType").GetComponent<NormalPartsStatus>().Status[0];
        }
  else{
            //それ以外の処理
        }
       
    }
    // Use this for initialization
    void Start () {
        hp = 100;
	}
	
	// Update is called once per frame
	void Update () {
	    if( 0 > hp)
        {
            Destroy(this.gameObject);
        }
	}
}
