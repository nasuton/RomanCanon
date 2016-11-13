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


    bool isAnimation = false;

    private enum TitleAnimationType
    {
        NONE,
        OPEN_SELECT_CUSTOM,
        CLOSE_SELECT_CUSTOM,
        OPEN_PARTS_CUSTOM,
        CLOSE_PARTS_CUSTOM
    }

    TitleAnimationType animationType;

    Vector3 customBarSize;

    Vector3 partsBarSize;


    void Start()
    {
        for (int i = 0; i < 6; ++i)
        {
            selectCustomPartsNum[i] = 0;
        }

        SetWeaponStatus();

        animationType = TitleAnimationType.NONE;
        customBarSize = customParts.transform.localScale;
        customParts.transform.localScale = new Vector3(customBarSize.x, 0, customBarSize.z);
        partsBarSize = PartsType.transform.localScale;
        PartsType.transform.localScale = new Vector3(partsBarSize.x, 0, partsBarSize.z);
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

        isAnimation = true;
        animationType = TitleAnimationType.OPEN_SELECT_CUSTOM;

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

        {
            var obj = Resources.Load("GunPartsStatus/Weapon" + selectWeaponType.ToString() + "/Custom5/Parts"
                                     + selectCustomPartsNum[5].ToString()) as GameObject;

            RomanCanonStatus stateObj = obj.GetComponent<RomanCanonStatus>();
            RomanCanonStatus weaponRomanState = WeaponType.GetComponent<RomanCanonStatus>();
            weaponRomanState = stateObj;

            DownPartsStatus downState = obj.GetComponent<DownPartsStatus>();
            DownPartsStatus weaponDownState = WeaponType.GetComponent<DownPartsStatus>();
            weaponDownState = downState;

            RomanPartsStauts romanState = obj.GetComponent<RomanPartsStauts>();
            RomanPartsStauts weaponRomanPartsState = WeaponType.GetComponent<RomanPartsStauts>();
            weaponRomanPartsState = romanState;
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

        isAnimation = true;
        animationType = TitleAnimationType.OPEN_PARTS_CUSTOM;
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

        isAnimation = true;
        animationType = TitleAnimationType.CLOSE_PARTS_CUSTOM;
    }

    //武器選択に戻ります
    public void BackSelectWeaponType()
    {
        isShowCustomParts = false;
        isAnimation = true;
        animationType = TitleAnimationType.CLOSE_SELECT_CUSTOM;
        for (int i = 0; i < 6; ++i)
        {
            selectCustomPartsNum[i] = 0;
        }

        isAnimation = true;
        animationType = TitleAnimationType.CLOSE_SELECT_CUSTOM;
        titleText.SetActive(true);
        foreach (var ui in weaponButton)
            ui.SetActive(true);
    }

    //武器選択からGameMainに移行します
    public void StartButtonOfPushed()
    {
        if (isEnd == true) return;

        var obj = GameObject.Find("WeaponType");
        obj.GetComponent<WeaponTypeManager>().asset.WeaponNum = selectWeaponType;
        isEnd = true;
        SceneChanger.Instance.LoadLevel("Fujiyoshi", 1.0f);
    }


    void Update()
    {
        if (isEnd == true) return;

        UpdateAnimation();

        if (isAnimation == true) return;

        if (isShowCustomParts == false)
            ChoiseWeapon();

        else if (isSelectCustomParts == false)
            ChoiseCustomParts();

        else if (isSelectCustomParts == true)
            ChoiseParts();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (HitRay("GunImage"))
                StartButtonOfPushed();
        }
    }

    void UpdateAnimation()
    {
        if (isAnimation == false) return;

        if (animationType == TitleAnimationType.OPEN_SELECT_CUSTOM)
        {
            customParts.transform.localScale = new Vector3(customBarSize.x,
                                                           customParts.transform.localScale.y + customBarSize.y * Time.deltaTime * 1.5f,
                                                           customBarSize.z);

            if (customParts.transform.localScale.y <= customBarSize.y) return;
            isAnimation = false;
            customParts.transform.localScale = customBarSize;
        }
        else if (animationType == TitleAnimationType.CLOSE_SELECT_CUSTOM)
        {
            customParts.transform.localScale = new Vector3(customBarSize.x,
                                                           customParts.transform.localScale.y - customBarSize.y * Time.deltaTime * 1.5f, 
                                                           customBarSize.z);

            if (customParts.transform.localScale.y >= 0) return;

            isAnimation = false;
            customParts.transform.localScale = new Vector3(customBarSize.x, 0, customBarSize.z);
            customParts.SetActive(false);
        }

        else if (animationType == TitleAnimationType.OPEN_PARTS_CUSTOM)
        {
            PartsType.transform.localScale
                = new Vector3(partsBarSize.x,
                              PartsType.transform.localScale.y + partsBarSize.y * Time.deltaTime * 1.5f,
                              partsBarSize.z);

            if (PartsType.transform.localScale.y <= partsBarSize.y) return;
                isAnimation = false;
            PartsType.transform.localScale = new Vector3(partsBarSize.x, partsBarSize.y, partsBarSize.z);
        }

        else if (animationType == TitleAnimationType.CLOSE_PARTS_CUSTOM)
        {
            PartsType.transform.localScale
                = new Vector3(partsBarSize.x,
                              PartsType.transform.localScale.y - partsBarSize.y * Time.deltaTime * 1.5f,
                              partsBarSize.z);

            if (PartsType.transform.localScale.y >= 0) return;
            isAnimation = false;
            PartsType.transform.localScale = new Vector3(partsBarSize.x, partsBarSize.y, partsBarSize.z);
            PartsType.SetActive(false);
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
                SelectedCustomPartFlame.transform.SetParent(GameObject.Find("PartsBase" + i.ToString()).transform);
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
                    SelectedPartsFlame.transform.SetParent(GameObject.Find("Parts" + selectCustomPartsNum[i].ToString()).transform);
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
                    SelectedPartsFlame.transform.SetParent(GameObject.Find("Parts" + i.ToString()).transform);
                    SelectedPartsFlame.transform.localPosition = new Vector3(0, 0, 0);
                    selectCustomPartsNum[nowSelectCustomPartsNum] = i;
                    SetWeaponStatus();
                }
                else if (isHitRayParts == false)
                {
                    NowSelectPartsFlame.transform.SetParent(GameObject.Find("Parts" + i.ToString()).transform);
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
