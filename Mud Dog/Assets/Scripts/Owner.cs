﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Owner : MonoBehaviour
{

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void Chase(float chaseSpeed)
    {
        Debug.Log("Chasing " + chaseSpeed);
    }
}
