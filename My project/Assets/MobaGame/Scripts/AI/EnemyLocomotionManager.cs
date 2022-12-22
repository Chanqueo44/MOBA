using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLocomotionManager : MonoBehaviour
{
    protected Entity myEntity;

    public float maximumDetectionAngle=50;
    public float minimumDetectionAngle=-50;
    public LayerMask detectionLayer;
    private void Awake(){
        myEntity = this.GetComponent<Entity>();
    }
    public void HandleDetection(){
        Collider[] colliders= Physics.OverlapSphere(transform.position , myEntity.getVisionRange(), detectionLayer);
    
        for(int i=0; i<colliders.Length; i++){
            NonNeutral entityDetected= colliders[i].transform.GetComponent<NonNeutral>();
            if(entityDetected != null){
                Vector3 targetDirection= entityDetected.transform.position- this.transform.position;
                float viewableAngle=Vector3.Angle(targetDirection, transform.forward);
                myEntity.setCurrentEnemy(entityDetected);
            }
        }    
    }
}
