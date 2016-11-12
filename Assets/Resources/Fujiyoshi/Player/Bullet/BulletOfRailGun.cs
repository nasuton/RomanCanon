using UnityEngine;
using System.Collections;

public class BulletOfRailGun : MonoBehaviour
{
    private Vector3 moveVec = new Vector3(0, 0, 0);

    public Vector3 MoveVec
    {
        get { return moveVec; }
        set { moveVec = value; }
    }

    void Start()
    {
    
    }

    void Awake()
    {
        this.GetComponent<BulletDamege>().Damege = GameObject.Find("WeaponStatus").GetComponent<WeaponStatusManager>().Status[0];
    }

    void Update()
    {
        Move();
    }

    private void Move()
    {
        transform.localPosition += new Vector3(0,0, moveVec.z * Time.deltaTime);
        transform.localScale += new Vector3(0, 0, moveVec.z * Time.deltaTime * 2.0f);
    }

    public void Reset()
    {
        transform.localPosition = new Vector3(0, 0, 0.7f);
        transform.localScale = new Vector3(1.5f,1.5f,0.5f);
    }


}
