using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class alyndraAbiliity3 : MonoBehaviour
{   
        public Hero myHero;
        List<Entity> target= new List<Entity>();
        public float damageOutput = 0.5f;
        private float currentTimer;
        private bool timerRunning = false;
        private bool firstExecution= true;
        [SerializeField]  float damage;

    private void OnTriggerEnter(Collider other){
        Entity current = other.gameObject.GetComponent<Entity>();
        if(current != null){
            target.Add(current);
        }
    }

    private void onTriggerStay(Collider other){
        if(!firstExecution)
            return;
        Entity current = other.gameObject.GetComponent<Entity>();
        if(current != null){
            target.Add(current);
        }
        
    }

    private void OnTriggerExit(Collider other){
         Entity current = other.gameObject.GetComponent<Entity>();
        if(current != null ){
            target.Remove(current);
        }
    }
    private void doDamage(){
        
        for(int i =0;i<target.Count; i++){
            Entity current = target[i];
            if(current != null){
                if(current.GetType().IsSubclassOf(typeof(NonNeutral))){
                    NonNeutral currentVar=current as NonNeutral;
                    if(currentVar.getTeam()!=myHero.getTeam()){
                        current.decreaseHealth(damage);
                        checkedForDeath(current);   
                    }
                }
            }
            
        }
        restartTimer();
    }

    private bool checkedForDeath(Entity enemy){
        bool death = false;
        if(enemy.getCurrentHealth()<=0){
            death = true;
            target.Remove(enemy);
        }
        return death;
    }
    private void restartTimer(){
        timerRunning = true;
        currentTimer=damageOutput;
    }
    void Start(){
        restartTimer();
    }

    void Update(){
        if(!timerRunning)
            return;
        currentTimer-=Time.deltaTime;
        if(currentTimer<=0){
            timerRunning=false;
            doDamage();
        }

    }
}
