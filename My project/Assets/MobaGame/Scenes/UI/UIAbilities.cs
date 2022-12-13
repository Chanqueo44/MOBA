using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIAbilities : MonoBehaviour
{
    public Hero myHero;
    protected Image abilityImage1, abilityImage1Dark;

    private float cooldown1, cooldown2, cooldown3, cooldown4;
        public KeyCode ability1;

    // Start is called before the first frame update
    void Start()
    {
        abilityImage1= myHero.getAbility1Image();
        this.abilityImage1Dark=myHero.getAbility1ImageDark();
        abilityImage1Dark.fillAmount=0;
        cooldown1=myHero.getCoolDown1();
        
    }

    // Update is called once per frame
    void Update()
    {
        Ability1();
    }

    private void Ability1(){
        if(Input.GetKey(ability1) && myHero.getIsCoolDown1()==false){
            myHero.setIsCoolDown1(true);
            abilityImage1Dark.fillAmount=1;
        }
        if(myHero.getIsCoolDown1()==true){
            abilityImage1Dark.fillAmount-=1/ cooldown1*Time.deltaTime;

            if(abilityImage1Dark.fillAmount<=0){
                abilityImage1Dark.fillAmount=0;
                myHero.setIsCoolDown1(false);
            }
        }
    }
}
