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
    GameObject StatusUI = null;

    void Start()
    {
        for(int i = 0; i < 6; ++i)
        {
            selectCustomPartsNum[i] = 0;
        }
    }

    public void SetWeaponType(int num)
    {
        selectWeaponType = num;
      foreach (var ui in  weaponButton)
            ui.SetActive(false);
        isShowCustomParts = true;

        customParts.SetActive(true);
        StatusUI.SetActive(true);
        titleText.SetActive(false);
    }

    public void SelectCustomPartsType(int num)
    {
        isSelectCustomParts = true;
        nowSelectCustomPartsNum = num;
        PartsType.SetActive(true);
    }

    public void SelectCustomParts(int num)
    {
        selectCustomPartsNum[nowSelectCustomPartsNum] = num;
        PartsType.SetActive(false);
    }

    public void BackSelectCustomParts()
    {
        isSelectCustomParts = false;
        PartsType.SetActive(false);

        var obj = GameObject.Find("WeaponType");
        //obj.GetComponent<WeaponTypeManager>().asset.WeaponNum = num;
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
        StatusUI.SetActive(false);
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
