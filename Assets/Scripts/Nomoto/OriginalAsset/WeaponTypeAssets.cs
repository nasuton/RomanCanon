using UnityEngine;

public class WeaponTypeAssets : ScriptableObject
{
#if UNITY_EDITOR
    [UnityEditor.MenuItem("Custom Assets/Create WeaponTypeAsstes")]
    static void CreateAsset()
    {
        var asset = CreateInstance<WeaponTypeAssets>();
        UnityEditor.ProjectWindowUtil.CreateAsset(asset, "WeaponType.asset");
    }
#endif

    [SerializeField]
    int weaponNum = 0;

    public int WeaponNum
    {
        get { return weaponNum; }
        set { weaponNum = value; }
    }

    [SerializeField]
    float[] normalStatus = null;

    public float[] NormalStatus
    {
        get { return normalStatus; }
        set { normalStatus = value; }
    }

    [SerializeField]
    float[] romanStatus = null;

    public float[] RomanStatus
    {
        get { return romanStatus; }
        set { romanStatus = value; }
    }

    [SerializeField]
    float[] downStatus = null;

    public float[] DownStatus
    {
        get { return downStatus; }
        set { downStatus = value; }
    }
}
