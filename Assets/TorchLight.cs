using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorchLight : MonoBehaviour
{

    Light light;

    public bool luz = true;

    // Start is called before the first frame update
    void Start()
    {
        light = GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (luz)
        {

            StartCoroutine(Light());
            luz = false;
        }
       
    }


    public IEnumerator Light()
    {
        light.intensity = Random.Range(30, 50);
        yield return new WaitForSeconds(0.08f);
        luz = true;

    }


    
}
