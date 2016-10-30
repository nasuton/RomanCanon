using UnityEngine;
using System.Collections;

public class test : MonoBehaviour {

    //エネミーの種類
    public GameObject[] enemy = new GameObject[5];

    //敵を生成する時間
    public float interval = 1.0f;

    //playerからリスポーンする場所までの距離
    public float radius = 100.0f;

    //リスポーンする位置
    private Vector3[] spawn_pos = new Vector3[6];

    //リスポーンする際の角度
    private float[] angle = new float[6];

    void Start()
    {
        for(int  i = 0; i < spawn_pos.Length; i ++)
        {
            float degree = 40.0f * i;

            float radian = degree * Mathf.PI / 180.0f;

            float x1 = Mathf.Cos(radian) * radius;
            float z1 = Mathf.Sin(radian) * radius;

            spawn_pos[i] = new Vector3(x1, 0.0f, z1);

            float rotary_axis = (i * -40) - 90;

            angle[i] = rotary_axis;
        }

        StartCoroutine("Spawn", interval);
    }

    IEnumerator Spawn(float time)
    {
        while (true)
        {
            int count = Random.Range(0, spawn_pos.Length);

            GameObject.Instantiate(enemy[Random.Range(0, enemy.Length)], spawn_pos[count], Quaternion.Euler(0.0f, angle[count], 0.0f));

            yield return new WaitForSeconds(time);
        }
    }

}
