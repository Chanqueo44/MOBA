using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIAbilities : MonoBehaviour
{
    public Hero myHero;
    protected Image abilityImage1, abilityImage1Dark;
    protected Image abilityImage2, abilityImage2Dark;
    protected Image abilityImage3, abilityImage3Dark;
    protected Image abilityImage4, abilityImage4Dark;

    private float cooldown1, cooldown2, cooldown3, cooldown4;
        public KeyCode ability1;
        public KeyCode ability2;
        public KeyCode ability3;
        public KeyCode ability4;

    // Start is called before the first frame update
    void Start()
    {
        abilityImage1= myHero.getAbility1Image();
        this.abilityImage1Dark=myHero.getAbility1ImageDark();
        abilityImage1Dark.fillAmount=0;
        cooldown1=myHero.getCoolDown1();


        abilityImage2= myHero.getAbility2Image();
        this.abilityImage2Dark=myHero.getAbility2ImageDark();
        abilityImage2Dark.fillAmount=0;
        cooldown2=myHero.getCoolDown2();


        abilityImage3= myHero.getAbility3Image();
        this.abilityImage3Dark=myHero.getAbility3ImageDark();
        abilityImage3Dark.fillAmount=0;
        cooldown3=myHero.getCoolDown3();


        abilityImage4= myHero.getAbility4Image();
        this.abilityImage4Dark=myHero.getAbility4ImageDark();
        abilityImage4Dark.fillAmount=0;
        cooldown4=myHero.getCoolDown4();
        
    }

    // Update is called once per frame
    void Update()
    {
        Ability1();
        Ability2();
        Ability3();
        Ability4();

        
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
    
    private void Ability2(){
        if(Input.GetKey(ability2) && myHero.getIsCoolDown2()==false){
            myHero.setIsCoolDown2(true);
            abilityImage2Dark.fillAmount=1;
        }
        if(myHero.getIsCoolDown2()==true){
            abilityImage2Dark.fillAmount-=1/ cooldown1*Time.deltaTime;

            if(abilityImage2Dark.fillAmount<=0){
                abilityImage2Dark.fillAmount=0;
                myHero.setIsCoolDown2(false);
            }
        }

    }
    private void Ability3(){
        if(Input.GetKey(ability3) && myHero.getIsCoolDown3()==false){
            myHero.setIsCoolDown3(true);
            abilityImage3Dark.fillAmount=1;
        }
        if(myHero.getIsCoolDown3()==true){
            abilityImage3Dark.fillAmount-=1/ cooldown1*Time.deltaTime;

            if(abilityImage3Dark.fillAmount<=0){
                abilityImage3Dark.fillAmount=0;
                myHero.setIsCoolDown3(false);
            }
        }

    }
    private void Ability4(){
        if(Input.GetKey(ability4) && myHero.getIsCoolDown4()==false){
            myHero.setIsCoolDown4(true);
            abilityImage4Dark.fillAmount=1;
        }
        if(myHero.getIsCoolDown4()==true){
            abilityImage4Dark.fillAmount-=1/ cooldown1*Time.deltaTime;

            if(abilityImage4Dark.fillAmount<=0){
                abilityImage4Dark.fillAmount=0;
                myHero.setIsCoolDown4(false);
            }
        }

    }

}
