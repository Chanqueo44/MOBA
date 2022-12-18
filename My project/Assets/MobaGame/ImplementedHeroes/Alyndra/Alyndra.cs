using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alyndra : Hero
{
    [SerializeField] private GameObject DOTAreaAbility3;
    [SerializeField] private GameObject DOTAreaAbility4;
    

    public override void giveRewards(){

    }
    protected override void basicAttack(){
        
    }

    public override void useAbility1(){
        if(this.currentTarget!=null){
           if(currentTarget is NonNeutral){
                NonNeutral target= currentTarget as NonNeutral;
                if(target.getTeam()==this.team){
                    float healing= target.getMaxHealth()*0.2f;;
                    if(target.getCurrentHealth()+healing>= target.getMaxHealth()){
                      healing=target.getMaxHealth()-target.getCurrentHealth();
                    }
                    target.increaseHealth(healing);
                }
            }
        }
    }
    
    public override void useAbility2(){
        if(this.currentTarget!=null){
           if(currentTarget is NonNeutral){
                NonNeutral target= currentTarget as NonNeutral;
                if(target.getTeam()!=this.team){
                    float damage= target.getMaxHealth()*0.1f;;
                    if(target.getCurrentHealth()-damage<= 0){
                         //DEBÍA MORIR*inserte voz de isma 
                        target.decreaseHealth(damage);
                    }
                    target.decreaseHealth(damage);
                }
            }
            else if(currentTarget is Enemy){
                float damage= currentTarget.getMaxHealth()*0.1f;;
                    if(currentTarget.getCurrentHealth()-damage<= 0){
                         //DEBÍA MORIR*inserte voz de isma 
                        currentTarget.decreaseHealth(damage);
                    }
                    currentTarget.decreaseHealth(damage);
            }
        }
    }
    public override void useAbility3(){
        Vector3 position3;
        position3 = mousePosition.getPosition();
        Instantiate(DOTAreaAbility3,position3,Quaternion.identity);
    }
 
    public override void useAbility4(){
        Vector3 position3;
        position3 = mousePosition.getPosition();
        Instantiate(DOTAreaAbility4, position3, Quaternion.identity);
    }
}
