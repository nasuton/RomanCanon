using UnityEngine;
using System.Collections;

public class Rotater : MonoBehaviour
{
    //左手の座標
    private Vector3 leftPos;

    public Vector3 LeftPos
    {
        get { return leftPos; }
        set { leftPos = value; }
    }

    //右手の座標
    private Vector3 rightPos;

    public Vector3 RightPos
    {
        get { return rightPos; }
        set { rightPos = value; }
    }

    [SerializeField, Tooltip("回転速度設定用数値")]
    public float lookSpeed = 3.0f;

    void Start()
    {
        StartCoroutine(ChangeRotation());
    }

    void MoveLookPos()
    {
        if (Input.GetKey(KeyCode.UpArrow))
            rightPos.y += lookSpeed * Time.deltaTime;
        if (Input.GetKey(KeyCode.DownArrow))
            rightPos.y -= lookSpeed * Time.deltaTime;
        if (Input.GetKey(KeyCode.LeftArrow))
            rightPos.x -= lookSpeed * Time.deltaTime;
        if (Input.GetKey(KeyCode.RightArrow))
            rightPos.x += lookSpeed * Time.deltaTime;
    }

    private IEnumerator ChangeRotation()
    {
        while (true)
        {
            MoveLookPos();
            var right = rightPos + new Vector3(0, 0, 1);
            var left = leftPos + new Vector3(0, 0, -1);
            transform.LookAt(right - left);

            yield return 0;
        }
    }
}
