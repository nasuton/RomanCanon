using UnityEngine;
using System.Collections;

public class enemy3_cs : MonoBehaviour {

    private Vector3 player;

    [SerializeField]
    private float speed = 2.0f;

    [SerializeField]
    private float enemy_maxhp = 30.0f;

    private float enemy_hp;

    [SerializeField]
    private int add_score = 30;

    [SerializeField]
    private GameObject effect;

    void Start()
    {
        player = new Vector3(0.0f, 0.0f, 0.0f);
        enemy_hp = enemy_maxhp;
    }

    void Update()
    {
        Quaternion targetRotation = Quaternion.LookRotation(player - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 1.0f);

        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        float e_p_dis = Vector3.SqrMagnitude(transform.position - player);

        if (e_p_dis < 10.0f)
        {
            GameObject.Find("Score").GetComponent<score>().addScore(add_score);
            GameObject.Instantiate(effect, transform.position, Quaternion.Euler(0.0f, 0.0f, 0.0f));
            Destroy(this.gameObject);
        }
    }
}
