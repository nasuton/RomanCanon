using UnityEngine;
using System.Collections;

public class boss_cs : MonoBehaviour {

    private Vector3 player;

    public float speed = 3.5f;

    void Start()
    {
        player = new Vector3(0.0f, 0.0f, 0.0f);
    }

    void Update()
    {
        Quaternion targetRotation = Quaternion.LookRotation(player - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 1.0f);

        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        float e_p_dis = Vector3.SqrMagnitude(transform.position - player);

        if (e_p_dis < 10.0f)
        {
            Destroy(this.gameObject);
        }
    }
}
