using UnityEngine;
using System.Collections;

public class _TEST : MonoBehaviour {

    [SerializeField]
    TestAsset _test = null;

	// Use this for initialization
	void Start () {
        Debug.Log(_test.piyo);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
