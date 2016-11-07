using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SimpleCircleLayoutGroup : UIBehaviour, ILayoutGroup
{
    //半径
    public float radius = 100;
    //回転させるための角度
    public float offsetAngle;

    protected override void OnValidate()
    {
        base.OnValidate();
        Arrange();
    }

    // 要素数が変わると自動的に呼ばれるコールバック
    #region ILayoutController implementation
    public void SetLayoutHorizontal() { }
    public void SetLayoutVertical()
    {
        Arrange();
    }
    #endregion

    //角度計算して代入
    void Arrange()
    {
        float splitAngle = 360 / transform.childCount;
        var rect = transform as RectTransform;

        for (int elementId = 0; elementId < transform.childCount; elementId++)
        {
            var child = transform.GetChild(elementId) as RectTransform;
            float currentAngle = splitAngle * elementId + offsetAngle;
            child.anchoredPosition = new Vector2(
                Mathf.Cos(currentAngle * Mathf.Deg2Rad),
                Mathf.Sin(currentAngle * Mathf.Deg2Rad)) * radius;
        }
    }
}
