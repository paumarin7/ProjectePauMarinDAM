using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ActiveEnemy : MonoBehaviour
{

    public List<Stats> enemy = new List<Stats>();
    // Start is called before the first frame update
    void Start()
    {
        enemy = GetComponentsInChildren<Stats>().ToList();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if(other.transform.gameObject.tag == "Player")
        {
            Debug.Log(other.transform.gameObject.tag);
            for (int i = 0; i < enemy.Count; i++)
            {
                enemy[i].IsActive = true ;
                Debug.Log(enemy[i].IsActive);
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.transform.gameObject.tag == "Player")
        {
            Debug.Log(other.transform.gameObject.tag);
            for (int i = 0; i < enemy.Count; i++)
            {
                enemy[i].IsActive = true;
                Debug.Log(enemy[i].IsActive);
            }
        }
    }
}
