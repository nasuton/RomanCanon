using UnityEngine;
using System.Collections;

public class GaugeController : MonoBehaviour
{
    private Vector3 pos;
    private Vector2 gaugeValue;

    private int nowValue;

    public int NowValue
    {
        get { return nowValue; }
        set { nowValue = value; }
    }

    private int maxValue;

    public int MaxValue
    {
        get { return maxValue; }
        set { maxValue = value; }
    }

    private Transform rect = null;

    void Start()
    {
        rect = GetComponent<Transform>();
        pos = rect.localPosition;
        gaugeValue = rect.localScale;
    }

    void Update()
    {
        rect.localScale = new Vector3(((float)nowValue / (float)maxValue) * gaugeValue.x,gaugeValue.y,1);
        rect.localPosition = new Vector3(pos.x + rect.localScale.x, pos.y, pos.z);
    }
}
