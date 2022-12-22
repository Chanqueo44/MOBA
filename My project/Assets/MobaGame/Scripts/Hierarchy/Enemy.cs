using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : Neutral
{
    protected bool enraged;
    protected float chaseRange;

    protected bool isPerformingAction;

    protected EnemyLocomotionManager myEnemyLocomotionManager;

    private void Awake(){
        myEnemyLocomotionManager= GetComponent<EnemyLocomotionManager>();
    }

    private void Update(){
        this.HandleCurrentAction();
    }
    private void HandleCurrentAction(){
        if(this.GetComponent<Entity>().getCurrentEnemy()==null){
            myEnemyLocomotionManager.HandleDetection();
        }
    }

    //setters
    public void setIsPerformingAction(bool performing){
        this.isPerformingAction=performing;
    }

    //getters

    public bool getIsPerformingAction(){
        return this.isPerformingAction;
    }
}
