﻿using UnityEngine;
using System.Collections;

public enum EnemyState
{
    Move,
    Attack,
}


public class enemy_cs : MonoBehaviour
{

    private Vector3 player;

    [SerializeField]
    private float speed = 1.0f;

    [SerializeField]
    private int add_score = 10;

    enemy_state state;

    void Start()
    {
        player = GameObject.Find("Spawner").GetComponent<spawner_cs>().playerPos;

        state = GetComponent<enemy_state>();
    }

    void Update()
    {
        if (state.isDed) return;
        
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
