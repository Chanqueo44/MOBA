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
           if(currentTarget.getTeam()==this.team){
                float healing= currentTarget.getMaxHealth()*0.2f;;
                if(currentTarget.getCurrentHealth()+healing>= currentTarget.getMaxHealth()){
                    healing=currentTarget.getMaxHealth()-currentTarget.getCurrentHealth();
                }
                currentTarget.increaseHealth(healing);
            }
        }
    }
    
    public override void useAbility2(){
         if(this.currentTarget!=null){
           if(currentTarget.getTeam()!=this.team){
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
