using UnityEngine;
using System.Collections;

public class status : MonoBehaviour
{
    public bool isDed;

    private bool isDamage;

    [SerializeField]
    private float maxhp;

    public float now_hp;

    void Start()
    {
        isDamage = false;
        isDed = false;
        now_hp = maxhp;
    }

    void Update()
    {

    }
	
}
