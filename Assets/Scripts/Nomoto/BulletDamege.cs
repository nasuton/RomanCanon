using UnityEngine;
using System.Collections;

public class BulletDamege : MonoBehaviour
{
    [SerializeField]
    private float damege;

    public float Damege
    {
        get { return damege; }
        set { damege = value; }
    }
}
