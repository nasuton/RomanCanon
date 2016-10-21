
using UnityEngine;

public class TestAsset : ScriptableObject
{
#if UNITY_EDITOR
    [UnityEditor.MenuItem("Custom Assets/Create TEST")]
    static void CreateAsset()
    {
        var asset = CreateInstance<TestAsset>();
        UnityEditor.ProjectWindowUtil.CreateAsset(asset, "hoge.asset");
    }
#endif

    [SerializeField]
    int _hoge = 0;

    public int hoge { get { return _hoge; } }

    [SerializeField]
    float _fuga = 0f;

    public float fuga { get { return _fuga; } }

    [SerializeField]
    string _piyo = string.Empty;

    public string piyo { get { return _piyo; } }

    [SerializeField]
    TESTCLASS _test = null;
}
