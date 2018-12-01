using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Dog : MonoBehaviour
{
    public float speed = 0.25f;
    public float roll = 3;
    private Rigidbody rb;
    public float rollTime = 0.75f;
    private float rollTimer;
    private Vector3 rollDir;
    public GameObject barkCone;
    
    // Use this for initialization
    void Start ()
    {
        rb = GetComponent<Rigidbody>();

    }
	
	// Update is called once per frame
	void Update ()
    {
        barkCone.SetActive(false);
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
        barkCone.SetActive(true);
        Debug.Log("Woof");
    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.collider.CompareTag("Owner"))
        {
            GameManager.instance.GameOver();
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Floor") && rollTimer > 0f)
        {
            GameManager.instance.IncreaseMud(other.GetComponent<Renderer>());

        }
    }


}
