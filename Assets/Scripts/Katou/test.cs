using UnityEngine;
using System.Collections;

public class test : MonoBehaviour {

    public GameObject enemy;

    public int count = 1;
    public float interval = 5.0f;

    public int now_count;
    private float timer;

    void Start()
    {
        now_count = 0;
        Spawn();
    }

    void Update()
    {
        if (now_count < count)
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

        now_count += 1;
    }

}
