using UnityEngine;

public class Line : MonoBehaviour {

    public float degree = 0.0f;
    public float radius = 0.0f; 

	void Start ()
    {
        LineRenderer renderer = gameObject.GetComponent<LineRenderer>();

        degree = Mathf.Clamp(degree, 0.0f, 360.0f);

        float radian = degree * Mathf.PI / 180.0f;

        float x1 = Mathf.Cos(radian) * radius;
        float z1 = Mathf.Sin(radian) * radius;

        // 線の幅
        renderer.SetWidth(0.1f, 0.1f);
        // 頂点の数
        renderer.SetVertexCount(2);
        // 頂点を設定
        renderer.SetPosition(0, Vector3.zero);
        renderer.SetPosition(1, new Vector3(x1, 0.0f, z1));
    }
}
