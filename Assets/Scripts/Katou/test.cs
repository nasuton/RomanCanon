using UnityEngine;
using System.Collections;

public class test : MonoBehaviour {

    public float speed = 0.1f;

    private Vector3 player;

    public GameObject enemy;

    public int count = 1;
    public float interval = 5.0f;

    private float timer;

    void Start()
    {
        player = Vector3.zero;
        //Spawn();
    }

    void Update()
    {
        Quaternion targetRotation = Quaternion.LookRotation(player - this.transform.position);
        this.transform.rotation = Quaternion.Slerp(this.transform.rotation, targetRotation, Time.deltaTime * 1.0f);

        this.transform.Translate(Vector3.forward * speed * Time.deltaTime);

        float e_p_dis = Vector3.SqrMagnitude(this.transform.position - player);

        if (e_p_dis < 10.0f)
        {
            //Destroy(this.gameObject);
        }
        if (count <= 3)
        {
            timer += Time.deltaTime;
            if (timer >= interval)
            {
                Spawn();
                timer = 0;
            }
        }
    }

    void Spawn()
    {
        float x = Random.Range(0.0f, 25.0f);
        float z = Random.Range(0.0f, 25.0f);

        Vector3 pos = new Vector3(x, 0.0f, z);

        GameObject.Instantiate(enemy, pos, Quaternion.identity);

        count += 1;
    }

}
