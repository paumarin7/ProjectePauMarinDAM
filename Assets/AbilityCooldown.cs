using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbilityCooldown : MonoBehaviour
{

    Image fa;

    public float amountTime;
    public  float timer;

    // Start is called before the first frame update
    void Start()
    {
       fa= GetComponent<Image>();
       fa.fillAmount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        amountTime -= Time.deltaTime;
        if(fa.fillAmount != 0)
        {
            fa.fillAmount =  amountTime / timer;
        }
    }


    public void SetFillAmount(float fillAmount)
    {
       fa.fillAmount = 1;
    }

    public void SetAmountTime(float time)
    {
        timer = time;
        this.amountTime = time;
    }
}
