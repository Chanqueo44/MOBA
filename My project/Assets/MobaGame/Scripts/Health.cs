using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public Slider playerSlider3D;
    Slider playerSlider2D;

    public Hero myHero;

    public float myHeroHealth;
    // Start is called before the first frame update
    void Start()
    {
        myHeroHealth = myHero.getMaxHealth();
        playerSlider2D = GetComponent<Slider>();
        playerSlider2D.maxValue = myHeroHealth;
        playerSlider3D.maxValue = myHeroHealth;
    }

    // Update is called once per frame
    void Update()
    {
        playerSlider2D.value = myHero.getCurrentHealth();
        playerSlider3D.value = playerSlider2D.value;
    }
}
