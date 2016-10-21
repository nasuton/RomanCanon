using UnityEngine;
using System.Collections;

public class NormalPartsStatus : MonoBehaviour
{
    [SerializeField]
    public float[] status = new float[5];

    public float[] Status
    {
        get { return status; }
        set { status = value; }
    }
}
