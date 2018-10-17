using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(Input.GetKeyDown(KeyCode.G))
        {
            GameManager.instance.GameOver();
        }
		
        if(Input.GetKeyDown(KeyCode.M))
        {
            GameManager.instance.IncreaseMud(10);
        }
	}
}
