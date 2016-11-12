using UnityEngine;
using System.Collections;

public class spawner_cs : MonoBehaviour {
    //エネミーの種類
    [SerializeField, Tooltip("エネミーの種類")]
    private GameObject[] enemy = new GameObject[5];

    //敵を生成する時間
    [SerializeField, Tooltip("敵を生成する時間")]
    private float interval = 1.0f;

    //playerからリスポーンする場所までの距離
    [SerializeField, Tooltip("playerからリスポーンする場所までの距離")]
    private float radius = 100.0f;

    //最大でスポーンする位置数
    [SerializeField, Tooltip("リスポーンする位置の最大数です")]
    private int max_spawn = 200;

    //リスポーンする位置
    private Vector3[] spawn_pos;

    //リスポーンする際の角度
    private float[] angle;

    //ボスリスポーンするフラグ
    private bool boss_spawn;

    //プレイヤーする位置
    public Vector3 playerPos;

    void Awake()
    {
        boss_spawn = false;
        spawn_pos = new Vector3[max_spawn];
        angle = new float[max_spawn];
    }
    
    void Start()
    { 
        for (int i = 0; i < spawn_pos.Length; i++)
        {
            float radian = i * Mathf.PI / 180.0f;

            float x1 = Mathf.Cos(radian) * radius + playerPos.x;
            float z1 = Mathf.Sin(radian) * radius + playerPos.z;

            spawn_pos[i] = new Vector3(x1, 0.0f, z1);

            float rotary_axis = 180 + i;

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
