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
        var enemy =  Instantiate(gm.poolOfEnemies[Random.Range(0, gm.poolOfEnemies.Count)] , transform.position , Quaternion.identity);
        enemy.transform.SetParent(GetComponentInParent<ActiveEnemy>().transform);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
