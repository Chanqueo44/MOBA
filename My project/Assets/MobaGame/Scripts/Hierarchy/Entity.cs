using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Entity : MonoBehaviour
{  
    public Slider healthBarUi;

    [SerializeField] protected Vector3 spawnLocation;
    [SerializeField] protected float maxHealth;
    [SerializeField] protected float currentHealth;
    [SerializeField] protected float healthRecovery;
    [SerializeField] protected float defense;
    [SerializeField] protected float armour;
    [SerializeField] protected float magicResistance;
    [SerializeField] protected float visionRange;
    [SerializeField] protected float attackRange;
    [SerializeField] protected float goldReward;
    [SerializeField] protected float expReward;
    [SerializeField] protected float attackDamage;
    [SerializeField] protected float abilityPower;
    
    [SerializeField] protected float speed;

    public Entity currentEnemy;
    protected Entity lastHitBy;
    
    
    protected abstract void basicAttack();

    //override on respawnable entities
    protected void die(){
        this.giveRewards();
        Destroy(this.gameObject);
    }
    public abstract void giveRewards();

    public void increaseHealth(float health){
        if(this.currentHealth+health>=this.maxHealth){
            this.currentHealth= maxHealth;
        }
        else{
            this.currentHealth+= health;
        }
    }
    public void decreaseHealth(float health){
        this.currentHealth-= health;
        if(currentHealth<=0){
            this.die();
        }
    }

    //setters

    public void setSpawnLocation(Vector3 location){
        this.spawnLocation=location;
    }

    public void setMaxHealth(float max){
        this.maxHealth=max;
    }
    public void setHealthRecovery( float recoveryPercentaje){
        this.healthRecovery=recoveryPercentaje;
    }

    public void setDefense(float def){
        this.defense=def;
    }
    public void setArmour(float armourValue){
        this.armour=armourValue;
    }

    public void setMagicResistance( float magRes){
        this.magicResistance=magRes;
    }

    public void setVisionRange(float range){
        this.visionRange=range;
    }
    public void setAttackRange(float range){
        this.attackRange=range;
    }

    public void setGoldReward(float gold){
        this.goldReward=gold;
    }

    public void setExpReward(float exp){
        this.expReward=exp;
    }

    public void setLastHit(Entity enemy){
        this.lastHitBy=enemy;
    }

    public void setSpeed(float speed){
        this.speed = speed;
    }

    public void setCurrentEnemy(Entity enemy){
        this.currentEnemy=enemy;
    }

    //getters

    public Vector3 getSpawnLocation(){
        return this.spawnLocation;
    }

    public float getMaxHealth(){
        return this.maxHealth;
    }
    public float getCurrentHealth(){
        return this.currentHealth;
    }
    public float getHealthRecovery(){
        return this.healthRecovery;
    }
    public float getDefense(){
        return this.defense;
    }
    public float getAttack(){
        return this.attackDamage;
    }
    public float getArmour(){
        return this.armour;
    }
    public float getMagicResistance(){
        return this.magicResistance;
    }
    public float getVisionRange(){
        return this.visionRange;
    }
    public float getAttackRange(){
        return this.attackRange;
    }
    public float getGoldReward(){
        return this.goldReward;
    }
    public float getExpReward(){
        return this.armour;
    }

    public Entity getCurrentEnemy(){
        return this.currentEnemy;
    }
    public Entity getLastHitBy(){
        return this.lastHitBy;
    }

    public float getSpeed(){
        return this.speed;
    }

    /*void Start(){
        healthBarUi.maxValue=maxHealth;
    
    }

    void Update(){
        healthBarUi.value=currentHealth;
    }*/
}

