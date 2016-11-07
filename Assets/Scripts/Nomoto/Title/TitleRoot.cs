using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class TitleRoot : MonoBehaviour
{
    private bool isEnd = false;

    [SerializeField]
    GameObject titleText = null;

    [SerializeField]
    GameObject[] weaponButton = null;

    //選択されている武器Type
    private int selectWeaponType = 0;

    private bool isShowCustomParts = false;

    //武器ごとに設定されているCustomParts
    [SerializeField]
    GameObject customParts = null;

    private bool isSelectCustomParts = false;

    private int[] selectCustomPartsNum = new int[6];

    private int nowSelectCustomPartsNum = 0;

    //部品
    [SerializeField]
    GameObject PartsType = null;

    [SerializeField]
    GameObject WeaponType = null;

    public LayerMask mask;

    [SerializeField]
    ChangeStatusBar changeStatusBar = null;

    [SerializeField]
    GameObject AnserBar = null;

    private bool canAnser = false;

    [SerializeField]
    GameObject SelectedCustomPartFlame = null;

    [SerializeField]
    GameObject SelectedPartsFlame = null;

    [SerializeField]
    GameObject NowSelectPartsFlame = null;


    bool isHitRayParts = false;
    void Start()
    {
        for (int i = 0; i < 6; ++i)
        {
            selectCustomPartsNum[i] = 0;
        }

        SetWeaponStatus();
    }

    //銃のタイプを設定
    public void SetWeaponType(int num)
    {
        selectWeaponType = num;
        foreach (var ui in weaponButton)
            ui.SetActive(false);
        isShowCustomParts = true;

        customParts.SetActive(true);
        titleText.SetActive(false);
        SetWeaponStatus();
    }
    //銃のステータスをもらいます
    void SetWeaponStatus()
    {
        float[] state = new float[5];
        var status = WeaponType.GetComponent<NormalPartsStatus>().Status;

        for (int i = 0; i < 5; ++i)
            status[i] = 0;

        for (int i = 0; i < 5; ++i)
        {
            var obj = Resources.Load("GunPartsStatus/Weapon" + selectWeaponType.ToString() + "/Custom" + i.ToString()
                                      + "/Parts" + selectCustomPartsNum[i].ToString()) as GameObject;
            for (int k = 0; k < 5; ++k)
                state[k] = obj.GetComponent<NormalPartsStatus>().status[k];

            for (int num = 0; num < 5; ++num)
            {
                status[num] += state[num];
                changeStatusBar.NowStatus[num] = (int)status[num];
                changeStatusBar.AfterStatus[num] = (int)status[num];
            }
            changeStatusBar.IsChange = true;
            changeStatusBar.IsChangeAfter = true;
        }
    }

    //変更後の銃のステータスを入れます
    void SetAfterStatus(int nowCustomNum, int nowPartsNum)
    {
        float[] state = new float[5];
        var status = changeStatusBar.AfterStatus;

        for (int i = 0; i < 5; ++i)
            status[i] = 0;

        for (int i = 0; i < 5; ++i)
        {
            if (i != nowCustomNum)
            {
                var obj = Resources.Load("GunPartsStatus/Weapon" + selectWeaponType.ToString() + "/Custom" + i.ToString()
                                          + "/Parts" + selectCustomPartsNum[i].ToString()) as GameObject;
                for (int k = 0; k < 5; ++k)
                    state[k] = obj.GetComponent<NormalPartsStatus>().status[k];
            }

            else
            {
                var obj = Resources.Load("GunPartsStatus/Weapon" + selectWeaponType.ToString() + "/Custom" + nowCustomNum.ToString()
                                       + "/Parts" + nowPartsNum.ToString()) as GameObject;
                for (int k = 0; k < 5; ++k)
                    state[k] = obj.GetComponent<NormalPartsStatus>().status[k];
            }

            for (int num = 0; num < 5; ++num)
            {
                status[num] += (int)state[num];
                changeStatusBar.AfterStatus[num] = status[num];
                changeStatusBar.IsChangeAfter = true;
            }

        }

    }

    //0~5で数値化されたcustomするパーツのどこを変更するか決めます
    public void SelectCustomPartsType(int num)
    {
        if (isSelectCustomParts != false) return;
        isSelectCustomParts = true;
        nowSelectCustomPartsNum = num;
        PartsType.SetActive(true);
    }

    //customパーツを選択後0~3の部品の中で部品を選びます
    public void SelectCustomParts(int num)
    {
        selectCustomPartsNum[nowSelectCustomPartsNum] = num;
        SetWeaponStatus();
    }

    //Parts選択画面からCustomPartsを選択する画面に戻ります
    public void BackSelectCustomParts()
    {
        if (isSelectCustomParts != true) return;
        isSelectCustomParts = false;
        PartsType.SetActive(false);
    }

    //武器選択に戻ります
    public void BackSelectWeaponType()
    {
        foreach (var ui in weaponButton)
            ui.SetActive(true);
        isShowCustomParts = false;
        customParts.SetActive(false);
        titleText.SetActive(true);

        for (int i = 0; i < 6; ++i)
        {
            selectCustomPartsNum[i] = 0;
        }
    }

    //武器選択からGameMainに移行します
    public void StartButtonOfPushed()
    {
        if (isEnd == true) return;

        var obj = GameObject.Find("WeaponType");
        obj.GetComponent<WeaponTypeManager>().asset.WeaponNum = selectWeaponType;
        isEnd = true;
        SceneChanger.Instance.LoadLevel("Result", 1.0f);
    }


    void Update()
    {
        if (isShowCustomParts == false)
            ChoiseWeapon();

        else if (isSelectCustomParts == false)
            ChoiseCustomParts();

        else if (isSelectCustomParts == true)
            ChoiseParts();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (HitRay("GunBase"))
                StartButtonOfPushed();
        }
    }
    //武器選択を行います
    private void ChoiseWeapon()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (HitRay("MiniGun"))
                SetWeaponType(0);
            else if (HitRay("RocketRauncher"))
                SetWeaponType(1);
            else if (HitRay("RailGun"))
                SetWeaponType(2);
        }
    }

    //CustomParts選択を行います
    private void ChoiseCustomParts()
    {
        for (int i = 0; i < 6; ++i)
        {
            if (HitRay("PartsBase" + i.ToString()))
            {
                SelectedCustomPartFlame.transform.parent = GameObject.Find("PartsBase" + i.ToString()).transform;
                SelectedCustomPartFlame.transform.localPosition = new Vector3(0, 0, 0);
            }
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {

            if (HitRay("BackGameSelect"))
                BackSelectWeaponType();

            for (int i = 0; i < 6; ++i)
            {
                if (HitRay("PartsBase" + i.ToString()))
                {
                    SelectCustomPartsType(i);
                    SelectedPartsFlame.transform.parent = GameObject.Find("Parts" + selectCustomPartsNum[i].ToString()).transform;
                    SelectedPartsFlame.transform.localPosition = new Vector3(0, 0, 0);
                }
            }
        }
    }

    //Statusを変更する際一回だけ変更することで、
    //見栄えが良くなると思ったので一回しかAnimationしないようにします
    //Parts選択を行います
    private void ChoiseParts()
    {
        Ray ray = new Ray(transform.position, transform.forward);

        RaycastHit hit;
        if (Physics.Raycast(ray, out hit) == false) return;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (hit.collider.gameObject.name == "BackGameSelect")
            {
                BackSelectCustomParts();
                SetWeaponStatus();
            }
        }
        for (int i = 0; i < 4; ++i)
        {
            if (hit.collider.gameObject.name == "Parts" + i.ToString())
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    SelectedPartsFlame.transform.parent = GameObject.Find("Parts" + i.ToString()).transform;
                    SelectedPartsFlame.transform.localPosition = new Vector3(0, 0, 0);
                    selectCustomPartsNum[nowSelectCustomPartsNum] = i;
                    SetWeaponStatus();
                }
                else if (isHitRayParts == false)
                {
                    NowSelectPartsFlame.transform.parent = GameObject.Find("Parts" + i.ToString()).transform;
                    NowSelectPartsFlame.transform.localPosition = new Vector3(0, 0, 0);
                    isHitRayParts = true;
                    SetAfterStatus(nowSelectCustomPartsNum, i);
                }
                return;
            }
        }

        if (isHitRayParts == true)
            isHitRayParts = false;
    }
    //Rayを飛ばして当たり判定を行います
    public bool HitRay(string hitName)
    {
        Ray ray = new Ray(transform.position, transform.forward);

        RaycastHit hit;
        if (Physics.Raycast(ray, out hit) == false) return false;
        if (hit.collider.gameObject.name != hitName) return false;

        return true;
    }

}
