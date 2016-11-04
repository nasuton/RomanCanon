using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class StatusGaugeController : MonoBehaviour
{
    private Vector3[] pos = new Vector3[2];
    private Vector2[] gaugeValue = new Vector2[2];

    [SerializeField]
    GameObject downPosBar = null;

    [SerializeField]
    GameObject upPosBar = null;

    private bool isAnimation = false;

    [SerializeField]
    private int maxValue = 0;

    public int MaxValue
    {
        get { return maxValue; }
        set { maxValue = value; }
    }

    [SerializeField]
    private int nowValue = 0;

    public int NowValue
    {
        get { return nowValue; }
        set { nowValue = value; }
    }

    [SerializeField]
    private int afterValue = 0;

    public int AfterValue
    {
        get { return afterValue; }
        set { afterValue = value; }
    }

    private RectTransform[] translate = new RectTransform[2];

    float animationValue = 0;

    public float animationSpeed = 0;

    void Start()
    {
        translate[0] = downPosBar.GetComponent<RectTransform>();
        translate[1] = upPosBar.GetComponent<RectTransform>();

        for (int i = 0; i < 2; ++i)
        {
            pos[i] = translate[i].localPosition;
            gaugeValue[i] = translate[i].localScale;
        }
    }

    public void Set()
    {
        isAnimation = true;

      //  if(nowValue != afterValue)
        //{
        //    if(afterValue > nowValue)
        //    {
        //        upPosBar.GetComponent<Image>().sprite =
        //            Resources.Load<Sprite>("Nomoto/TestUI/bar_1");
        //        downPosBar.GetComponent<Image>().sprite =
        //            Resources.Load<Sprite>("Nomoto/TestUI/bar_1");
        //    }

        //    else
        //    {
        //        upPosBar.GetComponent<Image>().sprite =
        //        Resources.Load<Sprite>("Nomoto/Test/bar_1");
        //        downPosBar.GetComponent<Image>().sprite =
        //            Resources.Load<Sprite>("Nomoto/Test/bar_1");
        //    }
        //}
    }

    private void SetType()
    {

    }

    void Update()
    {
        Animation();
    }

    void Animation()
    {
        if (isAnimation != true) return;

        if( afterValue >= nowValue)
        {
            animationValue += (afterValue - nowValue) * Time.deltaTime;
            translate[0].localScale = new Vector3(((float)(nowValue + animationValue) / (float)maxValue) * gaugeValue[0].x, gaugeValue[0].y, 1);
            translate[1].localScale = new Vector3(((float)nowValue/ (float)maxValue) * gaugeValue[1].x, gaugeValue[1].y, 1);
            translate[1].localPosition = new Vector3(pos[1].x, pos[1].y, pos[1].z);
            translate[0].localPosition = new Vector3(pos[0].x, pos[0].y, pos[0].z);

            if (afterValue <= animationValue + nowValue)
            {
                animationValue = 0;
            }
        }
        else if (afterValue < nowValue)
        {
            animationValue -= (nowValue - afterValue) * Time.deltaTime;
            translate[0].localScale = new Vector3(((float)(nowValue + animationValue) / (float)maxValue) * gaugeValue[0].x, gaugeValue[0].y, 1);
            translate[1].localScale = new Vector3(((float)afterValue / (float)maxValue) * gaugeValue[1].x, gaugeValue[1].y, 1);
            translate[1].localPosition = new Vector3(pos[1].x, pos[1].y, pos[1].z);
            translate[0].localPosition = new Vector3(pos[0].x, pos[0].y, pos[0].z);

            if (nowValue + animationValue < afterValue)
            {
                animationValue = 0;
            }
        }
    }

}
