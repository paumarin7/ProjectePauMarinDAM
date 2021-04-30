using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lampara : MonoBehaviour, IDamageable
{
    public void TakeHealth(float damage)
    {
        Destroy(this.gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
