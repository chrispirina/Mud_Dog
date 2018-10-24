using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dog : MonoBehaviour
{
    public float speed = 0.25f;
    public float roll = 3;
    public Rigidbody rB;
	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKey(KeyCode.UpArrow))
            transform.Translate(0, speed, 0);
        if (Input.GetKey(KeyCode.DownArrow))
            transform.Translate(0, -speed, 0);
        if (Input.GetKey(KeyCode.RightArrow))
            transform.Translate(speed, 0, 0);
        if (Input.GetKey(KeyCode.LeftArrow))
            transform.Translate(-speed, 0, 0);
        if (Input.GetKeyDown(KeyCode.Z))
            BarrelRoll();
        if (Input.GetKeyDown(KeyCode.X))
            Bark();
    }

    public void BarrelRoll()
    {
       GetComponent<Rigidbody>().AddForce(GetComponent<Rigidbody>().velocity.normalized * Time.deltaTime * roll);
        Debug.Log("Barrel Roll");
    }

    private void Bark()
    {
        Debug.Log("Woof");
    }
}
