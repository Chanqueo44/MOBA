using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHpAndResources : MonoBehaviour
{
    public Entity myEntity;
    public Slider entityHPSlider;
   
    // Start is called before the first frame update
    void Start()
    {
        entityHPSlider.maxValue= myEntity.getMaxHealth();
        entityHPSlider.value= myEntity.getCurrentHealth();
    }

    // Update is called once per frame
    void Update()
    {
        entityHPSlider.value= myEntity.getCurrentHealth();
    }
}
