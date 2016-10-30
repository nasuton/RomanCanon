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

    [SerializeField]
    GameObject PartsType = null;

    [SerializeField]
    GameObject WeaponType = null;

    public LayerMask mask;

    void Start()
    {
        for (int i = 0; i < 6; ++i)
        {
            selectCustomPartsNum[i] = 0;
        }

        SetWeaponStatus();
    }

    public void SetWeaponType(int num)
    {
        selectWeaponType = num;
        foreach (var ui in weaponButton)
            ui.SetActive(false);
        isShowCustomParts = true;

        customParts.SetActive(true);
        titleText.SetActive(false);
    }

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
                status[num] += state[num];
        }
    }

    public void SelectCustomPartsType(int num)
    {
        if (isSelectCustomParts != false) return;
        isSelectCustomParts = true;
        nowSelectCustomPartsNum = num;
        PartsType.SetActive(true);
    }

    public void SelectCustomParts(int num)
    {
        isSelectCustomParts = false;
        selectCustomPartsNum[nowSelectCustomPartsNum] = num;
        PartsType.SetActive(false);
        SetWeaponStatus();
    }

    public void BackSelectCustomParts()
    {
        isSelectCustomParts = false;
        PartsType.SetActive(false);

        var obj = GameObject.Find("WeaponType");
        if (isEnd == false)
        {
            isEnd = true;
            SceneChanger.Instance.LoadLevel("GameMain", 1.0f);
        }
    }

    public void BackSelectWeaponType()
    {
        foreach (var ui in weaponButton)
            ui.SetActive(true);
        isShowCustomParts = false;
        customParts.SetActive(false);
        titleText.SetActive(true);
    }

    public void startButtonOfPushed()
    {
        if (isEnd == true) return;

        var obj = GameObject.Find("WeaponType");
        obj.GetComponent<WeaponTypeManager>().asset.WeaponNum = selectWeaponType;
        isEnd = true;
        SceneChanger.Instance.LoadLevel("GameMain", 1.0f);
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isShowCustomParts == false)
                ChoiseWeapon();

            else if (isSelectCustomParts == false)
                ChoiseCustomParts();

            else if (isSelectCustomParts == true)
                ChoiseParts();
        }
    }

    private void ChoiseWeapon()
    {
        if (HitRay("MiniGun"))
            SetWeaponType(0);
        else if (HitRay("RocketRauncher"))
            SetWeaponType(1);
        else if (HitRay("RailGun"))
            SetWeaponType(2);
    }

    private void ChoiseCustomParts()
    {
        for (int i = 0; i < 6; ++i)
        {
            if (HitRay("PartsBase" + i.ToString()))
                SelectCustomPartsType(i);
        }
    }

    private void ChoiseParts()
    {
        for (int i = 0; i < 4; ++i)
        {
            if (HitRay("Parts" + i.ToString()))
            {
                SelectCustomParts(i);
            }
        }
    }

    public bool HitRay(string hitName)
    {
        Ray ray = new Ray(transform.position, transform.forward);

        RaycastHit hit;
        if (Physics.Raycast(ray, out hit) == false) return false;
        if (hit.collider.gameObject.name != hitName) return false;

        Debug.Log(hit.collider.gameObject.name);

        return true;
    }

}
