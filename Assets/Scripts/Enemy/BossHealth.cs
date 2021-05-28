using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHealth : MonoBehaviour
{
    public Image bossHealth;
    GameObject boss;
    // Start is called before the first frame update
    void Start()
    {
        bossHealth = GameObject.FindGameObjectWithTag("Respawn").GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if(boss == null)
        {
            boss = GameObject.FindGameObjectWithTag("Boss");
        }

        if (boss.GetComponent<Stats>().IsActive)
        {
            var currentValue = Map(boss.GetComponent<Stats>().Health, 0, boss.GetComponent<Stats>().MaxHealth, 0, 1);
            Debug.Log(boss.GetComponent<Stats>().Health);
            bossHealth.fillAmount = Mathf.Lerp(bossHealth.fillAmount, currentValue, Time.deltaTime);
        }
   
    }


    private float Map(float value , float inMin , float inMax, float outMin, float outMax)
    {
        return (value - inMin) * (outMax - outMin) / (inMax - inMin) + outMin;
    }
}


