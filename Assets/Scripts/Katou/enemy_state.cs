using UnityEngine;
using System.Collections;


//Enemyが共通でもっているもの
//Score Hp 無敵時間

public class enemy_state : MonoBehaviour
{
    public bool isDed;

    private int hp = 10;

    public GameObject effect;

    bool isInvincible = false;

    float invincibleTime = 0.0f;

    [SerializeField]
    float maxInvincibleTime = 1.0f;

    public int Hp
    {
        get { return hp; }
        set { hp = value; }
    }

    [SerializeField]
    private int scorePoint = 10;

    public int ScorePoint
    {
        get { return scorePoint; }
        set { scorePoint = value; }
    }

    void Start()
    {
        isDed = false;
    }

    void Update()
    {
        if (isInvincible == true)
        {
            invincibleTime += Time.deltaTime;

            if (invincibleTime > maxInvincibleTime)
            {
                isInvincible = false;
                invincibleTime = 0.0f;
            }
        }

        if (hp > 0) return;
        //GameObject.Instantiate(effect, transform.position, Quaternion.Euler(0.0f, 0.0f, 0.0f));
        isDed = true;
        Destroy(this.gameObject);
        GameObject.Find("ScoreManager").GetComponent<score>().ScoreValue += scorePoint;
        GameObject.Find("score_notation").GetComponent<score_notation>().Add_Score();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<BulletDamege>() == null) return;
        if (isInvincible == true) return;

        isInvincible = true;
        hp -= (int)other.gameObject.GetComponent<BulletDamege>().Damege;
    }

}
