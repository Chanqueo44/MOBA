using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHpAndResources : MonoBehaviour
{
    public Hero myHero;
    public Slider playerHPSlider;
   
    // Start is called before the first frame update
    void Start()
    {
        playerHPSlider.maxValue= myHero.getMaxHealth();
        playerHPSlider.value= myHero.getCurrentHealth();
    }

    // Update is called once per frame
    void Update()
    {
        playerHPSlider.value= myHero.getCurrentHealth();
    }
}
