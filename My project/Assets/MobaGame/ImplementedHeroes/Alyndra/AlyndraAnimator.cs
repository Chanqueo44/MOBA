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

    
    public void ability1Trigger(){
        this.animAlyndra.SetTrigger("Ability1");
    }
    public void ability2Trigger(){
        this.animAlyndra.SetTrigger("Ability2");
    }
    public void ability3Trigger(){
        this.animAlyndra.SetTrigger("Ability3");
    }
    public void ability4Trigger(){
        this.animAlyndra.SetTrigger("Ability4");
    }
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
