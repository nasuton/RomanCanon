using UnityEngine;
using System.Collections;

public class RomanCanonStatus : MonoBehaviour
{
    [SerializeField,Tooltip("弾の種類")]
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
    private float romanModeTime = 0.0f;

    public float RomanModeTime
    {
        get { return romanModeTime; }
        set { romanModeTime = value; }
    }

    [SerializeField, Tooltip("RomanMode後のデバフ時間")]
    private float debuffTime = 0.0f;

    public float DebuffTime
    {
        get { return debuffTime; }
        set { debuffTime = value; }
    }

}
