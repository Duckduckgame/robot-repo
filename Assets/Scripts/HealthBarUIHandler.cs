using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class HealthBarUIHandler : MonoBehaviour
{
    public Slider slider;
    public turretController turret;
    public BaseHandler baseHand;
    // Start is called before the first frame update
    void Start()
    {
        if (slider = GetComponentInChildren<Slider>())
        {
            slider = GetComponentInChildren<Slider>();
           
        }
        else
        {
            Debug.Log("There is no slider attached to the Health Bar UI script");
        }

        if(turret = GetComponentInParent<turretController>())
        {
            turret = GetComponentInParent<turretController>();
            if (slider) slider.maxValue = turret.life;
        }
        else
        {
            if(baseHand = GetComponentInParent<BaseHandler>())
            {
                baseHand = GetComponentInParent<BaseHandler>();
                if (slider) slider.maxValue = baseHand.life;
            }
            else
            {
                Debug.Log("There is no or could not find the turret controler for the Health bar UI script");
            }
            
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (slider && turret)
        {
            slider.value = turret.life;
        }

        if(slider && baseHand)
        {
            slider.value = baseHand.life;
        }
    }
}
