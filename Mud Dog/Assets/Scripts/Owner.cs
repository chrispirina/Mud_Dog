using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

//Wander Code from : https://gist.github.com/Templar2020/8e4f5296de96d8ccf03263bf1a9f277f

public class Owner : MonoBehaviour

{
    public float wanderRadius;
    public float wanderTimer;

    private Transform target;
    private NavMeshAgent agent;
    private float timer;
    private float defaultSpeed;

    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        defaultSpeed = agent.speed;
        timer = wanderTimer;
    }

    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (!target)
        {
            Wandering();
        }
        else
        {
            agent.SetDestination(target.position);
        }
    }

    public void Chase(float chaseSpeed, Transform player)
    {
        target = player;
        agent.speed = chaseSpeed;

        Debug.Log("Chasing " + chaseSpeed);
    }

    public void StopChasing()
    {
        target = null;
        agent.speed = defaultSpeed;
    }

    public void Wandering ()
    {
        timer += Time.deltaTime;

        if (timer >= wanderTimer)
        {
            Vector3 newPos = RandomNavSphere(transform.position, wanderRadius, -1);
            agent.SetDestination(newPos);
            timer = 0;
        }


    }

    public static Vector3 RandomNavSphere(Vector3 origin, float dist, int layermask)
    {
        Vector3 randDirection = Random.insideUnitSphere * dist;

        randDirection += origin;

        NavMeshHit navHit;

        NavMesh.SamplePosition(randDirection, out navHit, dist, layermask);

        return navHit.position;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(transform.position, wanderRadius);
    }
}
