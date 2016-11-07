using UnityEngine;
using System.Collections;

public class spawner_cs : MonoBehaviour {
    //エネミーの種類
    [SerializeField]
    private GameObject[] enemy = new GameObject[5];

    //敵を生成する時間
    [SerializeField]
    private float interval = 1.0f;

    //playerからリスポーンする場所までの距離
    [SerializeField]
    private float radius = 100.0f;

    //リスポーンする位置
    [SerializeField]
    private Vector3[] spawn_pos = new Vector3[6];

    //リスポーンする際の角度
    private float[] angle = new float[6];

    //ボスリスポーンするフラグ
    private bool boss_spawn;

    //プレイヤーする位置
    public Vector3 playerPos;

    void Awake()
    {
        boss_spawn = false;
    }
    
    void Start()
    { 
        for (int i = 0; i < spawn_pos.Length; i++)
        {
            float degree = 40.0f * i;

            float radian = degree * Mathf.PI / 180.0f;

            float x1 = Mathf.Cos(radian) * radius + playerPos.x;
            float z1 = Mathf.Sin(radian) * radius + playerPos.z;

            spawn_pos[i] = new Vector3(x1, 0.0f, z1);

            float rotary_axis = (i * -40) - 90;

            angle[i] = rotary_axis;
        }

        StartCoroutine("Spawn", interval);
    }

    IEnumerator Spawn(float time)
    {
        while (0.0f < GameObject.Find("Timer").GetComponent<timer>().countTimer)
        {
            int count = Random.Range(0, spawn_pos.Length - 1);

            if (GameObject.Find("Timer").GetComponent<timer>().countTimer <= 30.0f && !boss_spawn)
            {

                GameObject.Instantiate(enemy[4], spawn_pos[count], Quaternion.Euler(0.0f, angle[count], 0.0f));
                boss_spawn = true;

            }
            else
            {
                GameObject.Instantiate(enemy[Random.Range(0, enemy.Length - 1)], spawn_pos[count], Quaternion.Euler(0.0f, angle[count], 0.0f));
            }

            yield return new WaitForSeconds(time);
        }
    }
}
