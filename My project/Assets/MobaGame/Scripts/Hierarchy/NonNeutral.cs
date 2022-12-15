using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class NonNeutral : Entity
{
    public int team=1;

    public void setTeam(int t){
        this.team=t;
    }

    public int getTeam(){
        return this.team;
    }
}
