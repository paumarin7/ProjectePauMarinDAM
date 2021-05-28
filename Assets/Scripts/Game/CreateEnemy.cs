using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateEnemy : MonoBehaviour
{
    GameManager gm;
    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        int randomNumber = Random.Range(0, gm.poolOfEnemies.Count);
        var enemy =  Instantiate(gm.poolOfEnemies[randomNumber] , transform.position , gm.poolOfEnemies[randomNumber].transform.rotation);
        enemy.name = gm.poolOfEnemies[randomNumber].name;
        enemy.transform.SetParent(GetComponentInParent<ActiveEnemy>().transform);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
