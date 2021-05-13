using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateEnemy : MonoBehaviour
{
    [SerializeField]
    private GameObject[] enemies;
    // Start is called before the first frame update
    void Start()
    {
      var enemy =  Instantiate(enemies[Random.Range(0, enemies.Length)] , transform.position , Quaternion.identity);
        enemy.transform.SetParent(GetComponentInParent<ActiveEnemy>().transform);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
