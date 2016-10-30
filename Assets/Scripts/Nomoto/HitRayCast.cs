using UnityEngine;
using System.Collections;

public class HitRayCast : MonoBehaviour
{
    public LayerMask mask;


    public LineRenderer line = null;

    void Start()
    {
        //line = GetComponent<LineRenderer>();
        //line.SetVertexCount(2);

        //line.SetPosition(0, transform.position);
        //line.SetPosition(1, transform.forward * 100);
    }


    //void Update()
    //{
    //    Ray ray = new Ray(transform.position, transform.forward);

    //    if (Input.GetKey(KeyCode.Space))
    //        HitRay("MiniGunButton");

    //    Debug.DrawRay(ray.origin, ray.direction * 10000, Color.green, 5, false);
    //}

    //public bool HitRay(string hitName)
    //{
    //    Ray ray = new Ray(transform.position, transform.forward);

    //    RaycastHit hit;
    //    if (Physics.Raycast(ray, out hit) == false) return false;
    //    // if (hit.collider.gameObject.name != hitName) return false;

    //    Debug.Log(hit.collider.gameObject.name);

    //    return true;
    //}
}
