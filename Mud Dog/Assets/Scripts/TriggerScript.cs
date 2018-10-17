using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerScript : MonoBehaviour {

    public float chaseSpeed = 5f;
    private Owner owner;


    private void Awake()
    {
        owner = GetComponentInParent<Owner>();
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            owner.Chase(chaseSpeed);
            Debug.Log("Seen");
            
        }
    }
}
