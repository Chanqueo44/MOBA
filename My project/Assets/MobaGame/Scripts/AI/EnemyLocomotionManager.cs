using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLocomotionManager : MonoBehaviour
{
    protected Entity myEntity;
    public void HandleDetection(){
        Collider[] colliders= Physics.OverlapCapsule(transform.position, myEntity.getVisionRange(), detectionLayer);
    }
}
