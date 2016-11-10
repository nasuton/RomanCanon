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

    [SerializeField, Tooltip("弾の種類")]
    public int bulletNum = 0;

    public int BulletNum
    {
        get { return bulletNum; }
        set { bulletNum = value; }
    }

    [SerializeField, Tooltip("RomanModeになれる回数")]
    private int canRomanModeCount = 1;

    public int CanRomanModeCount
    {
        get { return canRomanModeCount; }
        set { canRomanModeCount = value; }
    }

    [SerializeField, Tooltip("RomanModeになれる時間")]
    private float romanModeTime = 0;

    public float RomanModeTime
    {
        get { return romanModeTime; }
        set { romanModeTime = value; }
    }

    [SerializeField, Tooltip("RomanMode後のデバフ時間")]
    private float debuffTime = 0;

    public float DebuffTime
    {
        get { return debuffTime; }
        set { debuffTime = value; }
    }

}
