using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class plam_pos : MonoBehaviour {
    [SerializeField]
    GameObject plam;
    // Use this for initialization
    void Start () {
	   
	}
	
	// Update is called once per frame
	void Update () {
        this.transform.position = plam.transform.position;
	}
}
