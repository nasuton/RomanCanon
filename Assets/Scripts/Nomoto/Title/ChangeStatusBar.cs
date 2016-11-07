using UnityEngine;
using System.Collections;

public class ChangeStatusBar : MonoBehaviour
{
    [SerializeField, Tooltip("GaugeStatus")]
    StatusGaugeController[] state = null;

    //現在のStatus
    private int[] nowStatus = new int[5];

    public int[] NowStatus
    {
        get { return nowStatus; }
        set { nowStatus = value; }
    }

    //選択後のStatus
    private int[] afterStatus = new int[5];

    public int[] AfterStatus
    {
        get { return afterStatus; }
        set { afterStatus = value; }
    }

    private bool isChange = false;

    public bool IsChange
    {
        get { return isChange; }
        set { isChange = value; }
    }

    private bool isChangeAfter = false;

    public bool IsChangeAfter
    {
        get { return isChangeAfter; }
        set { isChangeAfter = value; }
    }

    private bool isAnimation = false;

    public bool IsAnimation
    {
        get { return isAnimation; }
        set { isAnimation = value; }
    }

    [SerializeField, Tooltip("各ステータスの最大値をいれてください")]
    int[] MaxStatus = new int[5];

    void Start()
    {
        for (int i = 0; i < 5; ++i)
        {
            state[i].MaxValue = MaxStatus[i];
        }
    }

    void Update()
    {
        Change();
        ChangeAfter();
        AnimationChangeAfter();
    }

    void Change()
    {
        if (isChange == false) return;
        for (int i = 0; i < 5; ++i)
        {
            state[i].NowValue = nowStatus[i];
        }
        isChange = false;

    }

    void ChangeAfter()
    {
        if (isChangeAfter == false) return;
        for (int i = 0; i < 5; ++i)
        {
            state[i].AfterValue = afterStatus[i];
            state[i].Set();
            state[i].IsAnimaiton = true;
        }
        isChangeAfter = false;
    }

    void AnimationChangeAfter()
    {
        if (isAnimation == false) return;
        for (int i = 0; i < 5; ++i)
        {
            state[i].IsAnimaiton = true;
        }
        isAnimation = false;
    }

}
