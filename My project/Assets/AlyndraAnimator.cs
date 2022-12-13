using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AlyndraAnimator : MonoBehaviour
{
    NavMeshAgent agent;
    public Animator animAlyndra;
    float motionSmoothTime= .1f;
    float speed;
    // Start is called before the first frame update
    void Start()
    {
        agent= gameObject.GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        speed=agent.velocity.magnitude/agent.speed;
        animAlyndra.SetFloat("Speed", speed, motionSmoothTime, Time.deltaTime);
    }
}
