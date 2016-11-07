using UnityEngine;
using System.Collections;

public class enemy_state : MonoBehaviour {

    private bool isDed;

    private bool isDamage;

   	// Use this for initialization
	void Start ()
    {
        isDed = false;
        isDamage = false;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(isDed)
        {
            return;
        }
	}



}
