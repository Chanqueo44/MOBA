using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Movement : MonoBehaviour
{

    NavMeshAgent agent;

    public float rotateSpeedMovement = 0.1f;
    public float rotateVelocity;
    float movementSpeed;

    private Combat combatScript;
    public NavMeshAgent getAgent(){
            return agent;
        }
    public float getRotateVelocity(){
        return this.rotateVelocity;
    }    
    public void setRotateVelocity(float velocity){
        this.rotateVelocity= velocity;
    }

    // Start is called before the first frame update
    void Start()
    {
        agent= gameObject.GetComponent<NavMeshAgent>();
        combatScript = gameObject.GetComponent<Combat>();
    }

    // Update is called once per frame
    void Update()
    {
        movementSpeed = GetComponentInParent<Hero>().getSpeed()/100;
        agent.speed = movementSpeed;
        if(Input.GetMouseButtonDown(1)){
            RaycastHit hit;
            
            //Checking if the raycast shot hits something
            if(Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, Mathf.Infinity)){
                //the player moves to the place that was hit by the raycast
                agent.SetDestination(hit.point);

                //rotation
                Quaternion rotationToLookAt=Quaternion.LookRotation(hit.point- transform.position);
                float rotationY= Mathf.SmoothDampAngle(transform.eulerAngles.y, 
                  rotationToLookAt.eulerAngles.y, ref rotateVelocity, 
             rotateSpeedMovement*(Time.deltaTime*5));

                transform.eulerAngles= new Vector3(0, rotationY,0);
            }
        }

        
    }
}
