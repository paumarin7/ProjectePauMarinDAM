using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomTreasure : MonoBehaviour
{


    public GameObject[] treasures;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(treasures[Random.Range(0, treasures.Length)],this.transform.position, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
