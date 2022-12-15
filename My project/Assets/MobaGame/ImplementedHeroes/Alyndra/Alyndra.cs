using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alyndra : Hero
{
    
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
        
    }
    public override void useAbility3(){
        
    }
    public override void useAbility4(){
        
    }
   
}
