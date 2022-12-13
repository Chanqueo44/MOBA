using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Movement : MonoBehaviour
{

    NavMeshAgent agent;

    public float rotateSpeedMovement = 0.1f;
    float rotateVelocity;


    // Start is called before the first frame update
    void Start()
    {
        agent= gameObject.GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        
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
        if(Input.GetKey(KeyCode.Q)){
            GetComponentInParent<Hero>().useAbility1();
        }
    }
}
