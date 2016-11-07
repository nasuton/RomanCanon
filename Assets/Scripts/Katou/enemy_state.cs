using UnityEngine;
using System.Collections;

public class enemy_state : MonoBehaviour
{
    public bool isDed;

    private int hp = 100;

    public GameObject effect;

    public int Hp
    {
        get { return hp; }
        set { hp = value; }
    }

    void Start()
    {
        isDed = false;
    }

    void Update()
    {
        if (hp > 0) return;
            //GameObject.Instantiate(effect, transform.position, Quaternion.Euler(0.0f, 0.0f, 0.0f));
            isDed = true;
            Destroy(this);
    }



}
