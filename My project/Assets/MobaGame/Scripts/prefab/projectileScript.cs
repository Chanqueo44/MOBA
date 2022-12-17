using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectileScript : MonoBehaviour
{
    [SerializeField] Hero player;
    [SerializeField] float damage;
    [SerializeField] Entity target;
    [SerializeField] float velocity=0.1f;
    [SerializeField] bool stopProjectile;
    
    // Update is called once per frame
    void start(){
        damage = player.getAttack();
    }
    
    void Update()
    {
        if(target){
            if(target==null)
                Destroy(gameObject);
            if(!stopProjectile){
                if(Vector3.Distance(transform.position,target.transform.position)<0.1f){
                    target.decreaseHealth(damage);
                    stopProjectile = true;
                    Destroy(gameObject);
                }
            }
        }
    }
}
