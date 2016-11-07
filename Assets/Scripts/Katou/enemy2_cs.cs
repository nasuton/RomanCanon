using UnityEngine;
using System.Collections;

public class enemy2_cs : MonoBehaviour {

    private Vector3 player;

    [SerializeField]
    private float speed = 1.5f;

    [SerializeField]
    private int add_score = 20;

    void Start()
    {
        player = GameObject.Find("Spawner").GetComponent<spawner_cs>().playerPos;
    }

    void Update()
    {
        float e_p_dis = Vector3.SqrMagnitude(transform.position - player);

        if (e_p_dis < 10.0f)
        {
            Attack();
        }
        else
        {
            Move();
        }
    }

    void Move()
    {
        Quaternion targetRotation = Quaternion.LookRotation(player - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 1.0f);

        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    void Attack()
    {

    }

}
