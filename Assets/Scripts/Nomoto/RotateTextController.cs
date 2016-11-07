using UnityEngine;
using System.Collections;

public class RotateTextController : MonoBehaviour
{
    private string text;

    public string Text
    {
        get { return text; }
        set { text = value; }
    }

    //半径
    public float radius = 100;
    //回転させるための角度
    public float offsetAngle;

    void Start()
    {
        Make("ほめてほめてほめてほめてほめてほめてほめて");
    }

    void Update()
    {
        Arrange();
        offsetAngle -= 100.0f * Time.deltaTime;
    }

    [SerializeField]
    GameObject textObject = null;

    private void Make(string str)
    {
        for (int i = 0; i < str.Length; i++)
        {
            GameObject obj = GameObject.Instantiate(textObject,transform) as GameObject;
            obj.GetComponent<TextMesh>().text = str[i].ToString();
        }
    }

    void Arrange()
    {
        float splitAngle = 360 / transform.childCount;
        var rect = transform;

        for (int elementId = 0; elementId < transform.childCount; elementId++)
        {
            var child = transform.GetChild(elementId);
            float currentAngle = splitAngle * elementId + offsetAngle;
            child.position = new Vector3(
                Mathf.Cos(currentAngle * Mathf.Deg2Rad), 0,
                Mathf.Sin(currentAngle * Mathf.Deg2Rad)) * radius;
            child.LookAt(transform);
        }
    }
}
