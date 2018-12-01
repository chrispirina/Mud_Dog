using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cat : MonoBehaviour {

    public float tileSize;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Bark"))
        {
            Vector3 heading = other.transform.position - transform.position;
            Vector3 direction = heading / heading.magnitude;
            direction.y = 0f;
            transform.position -= direction * tileSize;
        }
    }
}
