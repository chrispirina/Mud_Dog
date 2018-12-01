using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dog : MonoBehaviour
{
    public float speed = 0.25f;
    public float roll = 3;
    private Rigidbody rb;
    public float rollTime = 0.75f;
    private float rollTimer;
    private Vector3 rollDir;
    
    // Use this for initialization
    void Start ()
    {
        rb = GetComponent<Rigidbody>();

    }
	
	// Update is called once per frame
	void Update ()
    {
        if (rollTimer > 0f)
        {
            rb.velocity = rollDir * roll;
            rollTimer -= Time.deltaTime;
            return;
        }
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        rb.velocity = new Vector3(horizontal, 0F, vertical) * speed;

        if (Input.GetKeyDown(KeyCode.Space))
            BarrelRoll();
        if (Input.GetKeyDown(KeyCode.X))
            Bark();
    }

    public void BarrelRoll()
    {
        rollDir = rb.velocity.normalized;
        rollTimer = rollTime;
    }

    private void Bark()
    {
        Debug.Log("Woof");
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.CompareTag ("Floor") &&  rollTimer > 0f)
        {
            collision.collider.GetComponent<Renderer>().material.color = new Color(0.39F, 0.26F, 0.12F);

        }
    }
}
