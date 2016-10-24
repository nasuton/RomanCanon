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

        for(int i = 0; i < 5;++i)
            status[i] = 0;

        for (int i = 0; i < 5; ++i)
        {
            var obj = Resources.Load("GunPartsStatus/Weapon" + selectWeaponType.ToString() + "/Custom" + i.ToString() 
                                      + "/Parts" + selectCustomPartsNum[i].ToString()) as GameObject;
            for (int k = 0; k < 5; ++k)
                state[k] = obj.GetComponent<NormalPartsStatus>().status[k];

            for(int num = 0; num < 5; ++num)
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
        if (isEnd == false)
        {
            isEnd = true;
            SceneChanger.Instance.LoadLevel("GameMain", 1.0f);
        }
    }

    //var obj = GameObject.Find("WeaponType");
    //obj.GetComponent<WeaponTypeManager>().asset.WeaponNum = num;
    //if (isEnd == false)
    //{
    //    isEnd = true;
    //    SceneChanger.Instance.LoadLevel("GameMain", 1.0f);
    //}
}
