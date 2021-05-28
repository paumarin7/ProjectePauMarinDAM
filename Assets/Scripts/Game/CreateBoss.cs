using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateBoss : MonoBehaviour
{
    GameManager gm;

    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        int randomNumber = Random.Range(0, gm.poolOfEnemies.Count);
        var enemy = Instantiate(gm.poolOfBosses[0], transform.position, gm.poolOfBosses[0].transform.rotation);
        enemy.name = gm.poolOfBosses[0].name;
        enemy.transform.SetParent(GetComponentInParent<ActiveEnemy>().transform);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
