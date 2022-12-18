using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Hero : NonNeutral
{
    public GameObject resourceUI;
    protected int gold;
    protected int kills;
    protected int deaths;
    protected int assistances;
    [SerializeField] protected float resource;
    [SerializeField] protected string ability1Name, ability2Name, ability3Name, ability4Name;
    [SerializeField] protected int exp;
    [SerializeField] protected int lvl;

    //Ability Variables
    public Image ability1Image,ability2Image, ability3Image, ability4Image;
    public Image ability1ImageDark,ability2ImageDark, ability3ImageDark, ability4ImageDark;
    [SerializeField] protected float cooldown1, cooldown2, cooldown3, cooldown4;
    protected bool isCoolDown1=false, isCoolDown2=false, isCoolDown3=false, isCoolDown4=false;
    protected bool isAbilityActive1=false, isAbilityActive2=false, isAbilityActive3=false, isAbilityActive4=false;
    public GameObject abilityEffect1, abilityEffect2, abilityEffect3, abilityEffect4;
    

    protected Entity currentTarget;

    



   
    
    protected void levelUp(){}

    protected void decreaseResource(float decrease){
        this.resource-=decrease;
    }
    
    public void increaseXP(int expinc){
        this.exp+=expinc;
        
    }

    public void increaseGold(int g){
        this.gold+=g;
        Debug.Log(this.gold);
    }
    public void  increaseKillCount(){
        this.kills++;
    }
    public void  increaseDeathCount(){
        this.deaths++;
    }
    public void  increaseAssistancesCount(){
        this.assistances++;
    }

    public abstract void useAbility1();
    public abstract void useAbility2();
    public abstract void useAbility3();
    public abstract void useAbility4();

    //Setters

    public void setCurrentTarget(Entity target){
        this.currentTarget=target;
    }
   
    public void setIsCoolDown1(bool cool){
       this.isCoolDown1=cool;
    }
    public void setIsCoolDown2(bool cool){
       this.isCoolDown2=cool;
    }
    public void setIsCoolDown3(bool cool){
       this.isCoolDown3=cool;
    }
    public void setIsCoolDown4(bool cool){
       this.isCoolDown4=cool;
    }


   //getters
    public Image getAbility1Image(){
        return this.ability1Image;
    }
    public Image getAbility2Image(){
        return this.ability2Image;
    }
    public Image getAbility3Image(){
        return this.ability3Image;
    }
    public Image getAbility4Image(){
        return this.ability4Image;
    }
     public Image getAbility1ImageDark(){
        return this.ability1ImageDark;
    }
    public Image getAbility2ImageDark(){
        return this.ability2ImageDark;
    }
    public Image getAbility3ImageDark(){
        return this.ability3ImageDark;
    }
    public Image getAbility4ImageDark(){
        return this.ability4ImageDark;
    }

    public float getCoolDown1(){
        return this.cooldown1;
    }
    public float getCoolDown2(){
        return this.cooldown2;
    }
    public float getCoolDown3(){
        return this.cooldown3;
    }
    public float getCoolDown4(){
        return this.cooldown4;
    }
    public bool getIsCoolDown1(){
        return this.isCoolDown1;
    }
    public bool getIsCoolDown2(){
        return this.isCoolDown2;
    }
    public bool getIsCoolDown3(){
        return this.isCoolDown3;
    }
    public bool getIsCoolDown4(){
        return this.isCoolDown4;
    }
   

    public Entity getCurrentTarget(){
        return this.currentTarget;
    }
    public GameObject getAbilityEffect1(){
        return this.abilityEffect1;
    }
    public GameObject getAbilityEffect2(){
        return this.abilityEffect2;
    }
    public GameObject getAbilityEffect3(){
        return this.abilityEffect3;
    }
    public GameObject getAbilityEffect4(){
        return this.abilityEffect4;
    }
  

}
