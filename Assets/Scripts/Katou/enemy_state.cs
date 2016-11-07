using UnityEngine;
using System.Collections;

public class enemy_state : MonoBehaviour
{
    private bool isDed;

    private bool isDamage;

    private int hp = 100;

    public int Hp
    {
        get { return hp; }
        set { hp = value; }
    }

    void Start()
    {
        isDed = false;
        isDamage = false;
    }

    void Update()
    {
        if (hp > 0) return;
            Destroy(this);
    }



}
