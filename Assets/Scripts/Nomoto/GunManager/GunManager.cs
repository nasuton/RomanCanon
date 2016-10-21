using UnityEngine;
using UnityEngine.UI;
using System.Collections;

//! 銃の操作を管理するクラスです
//! 右手と左手のPosを入れてください 
//!
//! 2016-10-13

public class GunManager : MonoBehaviour
{
    //Weapon設定
    [SerializeField]
    public GameObject[] weapon = null;

    [SerializeField,Tooltip("回転速度設定用数値")]
    public float lookSpeed = 3.0f;

    public enum WeaponType
    {
        NONE = -1,
        MINI_GUN,
        ROCKET_LAUNCHER,
        RAIL_GUN
    }

    public int weaponType = 0;

    //左手の座標
    private Vector3 leftPos;

    public Vector3 LeftPos
    {
        get { return leftPos; }
        set { leftPos = value; }
    }

    //右手の座標
    private Vector3 rightPos;

    public Vector3 RightPos
    {
        get { return rightPos; }
        set { rightPos = value; }
    }
    [SerializeField]
    GameObject friezeBar = null;

    [SerializeField]
    GameObject ChargeBar = null;

    [SerializeField]
    GameObject RomanGaugeBar = null;

    void Start()
    {
        var type = GameObject.Find("WeaponType");
        weaponType = type.GetComponent<WeaponTypeManager>().asset.WeaponNum;

        MakeWeapon();
        MakeUI();
        rightPos = new Vector3(0, 0, 0);
        leftPos = new Vector3(0, 0, 0);
        StartCoroutine(ChangeRotation());
    }

    void MakeUI()
    {
        if(weaponType == (int)WeaponType.MINI_GUN)
        {
            friezeBar.SetActive(true);
        }

        else if(weaponType == (int)WeaponType.RAIL_GUN)
        {
            friezeBar.SetActive(true);
        }
    }

    void MakeWeapon()
    {
        var type = GameObject.Find("WeaponType");


        GameObject obj =  (GameObject)Instantiate(weapon[weaponType],
                           new Vector3(0,0,0), Quaternion.identity);
        obj.transform.parent = GameObject.Find("GunManager").transform;
    }

    void Update()
    {

    }

    private void TestMoveOfRightPos()
    {
        if (Input.GetKey(KeyCode.UpArrow))
            rightPos.y += lookSpeed * Time.deltaTime;
        if (Input.GetKey(KeyCode.DownArrow))
            rightPos.y -= lookSpeed * Time.deltaTime;
        if (Input.GetKey(KeyCode.LeftArrow))
            rightPos.x -= lookSpeed * Time.deltaTime;
        if (Input.GetKey(KeyCode.RightArrow))
            rightPos.x += lookSpeed * Time.deltaTime;
    }

    //Rotationを変える処理
    private IEnumerator ChangeRotation()
    {
        while(true)
        {
            TestMoveOfRightPos();
            var right = rightPos + new Vector3(0, 0, 1);
            var left = leftPos + new Vector3(0, 0, -1);
            transform.LookAt(right - left);

            yield return 0;
        }
    }

}
