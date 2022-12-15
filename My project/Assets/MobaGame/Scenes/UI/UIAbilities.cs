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

     // variables for using Ability1   

   
    public Canvas ability1Canvas;
   
    public Canvas ability3Canvas;
    public Image ability3Range;
    private Vector3 posUp;
    public Canvas ability4Canvas;
    public Image ability4Range;
    public float maxAbility3Distance;


    // Start is called before the first frame update
    void Start()
    {
           
        //starting UI variables
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

        ability3Range.GetComponent<Image>().enabled = false;
        ability4Range.GetComponent<Image>().enabled = false;  
        


        abilityImage4= myHero.getAbility4Image();
        this.abilityImage4Dark=myHero.getAbility4ImageDark();
        abilityImage4Dark.fillAmount=0;
        cooldown4=myHero.getCoolDown4();

        this.ability1Canvas.enabled=false;
     
        
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
        if(Input.GetKey(ability1) && myHero.getIsCoolDown1()==false ){
            StartCoroutine(chooseTargetAbility1());
            ability1Canvas.enabled=true;
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

    public IEnumerator chooseTargetAbility1(){
        while(!Input.GetMouseButton(0)){
            yield return null;
        }
        if(Input.GetMouseButton(0)){
            myHero.GetComponentInChildren<AlyndraAnimator>().ability1Trigger();
            RaycastHit hit;
            if(Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, Mathf.Infinity)){
                    Collider gotHit= hit.transform.GetComponent<Collider>();
                    if(gotHit.GetComponentInParent<NonNeutral>()){
                            myHero.setCurrentTarget(gotHit.GetComponentInParent<NonNeutral>());
                            myHero.useAbility1();
                    }
            }
        }
    }
    
    private void Ability2(){
        if(Input.GetKey(ability2) && myHero.getIsCoolDown2()==false){
            StartCoroutine(chooseTargetAbility2());
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
            ability3Range.GetComponent<Image>().enabled = true; 
            StartCoroutine(choseAreaAbility3());
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
            ability4Range.GetComponent<Image>().enabled = true;
            StartCoroutine(choseAreaAbility4());
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
    public IEnumerator chooseTargetAbility2(){
        while(!Input.GetMouseButton(0)){
            yield return null;
        }
        if(Input.GetMouseButton(0)){
            myHero.GetComponentInChildren<AlyndraAnimator>().ability2Trigger();
            RaycastHit hit;
            if(Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, Mathf.Infinity)){
                    Collider gotHit= hit.transform.GetComponent<Collider>();
                    if(gotHit.GetComponentInParent<NonNeutral>()){
                            myHero.setCurrentTarget(gotHit.GetComponentInParent<NonNeutral>());
                            myHero.useAbility2();
                    }
            }
        }
    }

    public IEnumerator choseAreaAbility3(){
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Vector3 position;
        
        
        
        while(!Input.GetMouseButton(0)){

            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(ray,out hit,Mathf.Infinity)){
                if(hit.collider.gameObject != this.gameObject){
                    posUp = new Vector3(hit.point.x,10f,hit.point.z);
                    position = hit.point;
                }
            }
         

            var hitPosDir = hit.point;
            float distance =  Vector3.Distance(hit.point, transform.position);
            distance = Mathf.Min(distance, maxAbility3Distance);

            var newHitPos =  hitPosDir;
            ability3Canvas.transform.position = newHitPos;
            yield return null;
        }
        if(Input.GetMouseButton(0)){
            if(Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, Mathf.Infinity)){
                ability3Range.GetComponent<Image>().enabled = false; 
                myHero.GetComponentInChildren<AlyndraAnimator>().ability3Trigger();
                myHero.useAbility3();

            }
        }
        
    }


    public IEnumerator choseAreaAbility4(){
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Vector3 position;
        
        
        
        while(!Input.GetMouseButton(0)){

            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(ray,out hit,Mathf.Infinity)){
                
                    posUp = new Vector3(hit.point.x,10f,hit.point.z);
                    position = hit.point;
                
            }
         

            var hitPosDir = hit.point;
            float distance =  Vector3.Distance(hit.point, transform.position);
            distance = Mathf.Min(distance, maxAbility3Distance);

            var newHitPos =  hitPosDir;
            ability4Canvas.transform.position = newHitPos;
            yield return null;
        }
        if(Input.GetMouseButton(0)){
            if(Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, Mathf.Infinity)){
                ability4Range.GetComponent<Image>().enabled = false; 
                myHero.GetComponentInChildren<AlyndraAnimator>().ability4Trigger();
                myHero.useAbility4();
            }
        }
        
    }

}
