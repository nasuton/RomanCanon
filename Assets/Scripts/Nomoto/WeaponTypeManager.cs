using UnityEngine;
using System.Collections;

public class WeaponTypeManager : MonoBehaviour
{
    [SerializeField]
    public WeaponTypeAssets asset = null;

    static GameObject _instance = null;

    void Awake()
    {
        if (_instance == null)
        {
            DontDestroyOnLoad(gameObject);
            _instance = gameObject;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
