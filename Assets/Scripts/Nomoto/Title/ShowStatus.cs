using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ShowStatus : MonoBehaviour
{
    [SerializeField]
    NormalPartsStatus Param = null;

    public void SetText()
    {
        var obj = gameObject.GetComponent<Text>().text =
            "威力 : " + Param.Status[0].ToString() +
            "\n連射速度 : " + Param.Status[1].ToString() +
            "\n射程 : " + Param.Status[2].ToString() +
            "\n許容冷却量 : " + Param.Status[3].ToString() +
            "\n冷却速度 : " + Param.Status[4].ToString();
    }

    void Update()
    {
        SetText();
    }
}
