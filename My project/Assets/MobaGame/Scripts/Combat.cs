using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combat : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject targetedEntity;
    [SerializeField] private Entity Entity;

    private Movement moveScript;
    public bool basicAtkIdle = false;
    public bool performAttack = true;

    public float rotateSpeedForAttack;

    public float rotateVelocity;

    public GameObject getTargetedEntity(){
        return this.targetedEntity;
    }

    //ranged hero
    public GameObject projPrefab;
    public Transform projSpawnPoint;

    void Start(){
        moveScript = GetComponent<Movement>();
    }   

    void Update(){

        if(targetedEntity != null){
            
            if(Vector3.Distance(gameObject.transform.position, targetedEntity.transform.position) > Entity.getAttackRange()){
                 moveScript.getAgent().SetDestination(targetedEntity.transform.position);
                 moveScript.getAgent().stoppingDistance = Entity.getAttackRange();
            
                //Rotation
                 Quaternion rotationToLookAt=Quaternion.LookRotation(targetedEntity.transform.position- transform.position);
                 float rotationY= Mathf.SmoothDampAngle(transform.eulerAngles.y, 
                            rotationToLookAt.eulerAngles.y, ref this.moveScript.rotateVelocity, 
                                                    rotateSpeedForAttack*(Time.deltaTime*5));

                transform.eulerAngles= new Vector3(0, rotationY,0);


            }
            else{
                //attack
            }
        }

    }
}
