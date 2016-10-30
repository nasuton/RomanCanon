using UnityEngine;
using System.Collections;
public class Gun : MonoBehaviour {
    [SerializeField]
    GameObject bullet_prefab;
    [SerializeField]
    GameObject aim_direction;
    private void Fire()
    {
        GameObject bullet = Instantiate(bullet_prefab);
        bullet.transform.position = this.transform.position;
        bullet.GetComponent<Rigidbody>().AddForce(aim_direction.GetComponent<DrawAim>().aim_direction * 100);
    }

    // Update is called once per frame
    void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            Fire();
        }
	}
}
