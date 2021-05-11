using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ActiveEnemy : MonoBehaviour
{

    public List<Stats> enemy = new List<Stats>();
    BoxCollider boxCollider;
    // Start is called before the first frame update
    void Start()
    {

        enemy = GetComponentsInChildren<Stats>().ToList();
        boxCollider = GetComponent<BoxCollider>();
        boxCollider.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.transform.gameObject.name);
        if (other.transform.gameObject.tag == "Player")
        {
            
            for (int i = 0; i < enemy.Count; i++)
            {
                enemy[i].IsActive = true ;
                Debug.Log(enemy[i].IsActive);
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {

        Debug.Log(other.transform.gameObject.name);
        if (other.transform.gameObject.tag == "Player")
        {
         
            for (int i = 0; i < enemy.Count; i++)
            {
                enemy[i].IsActive = true;
                enemy[i].transform.gameObject.GetComponent<CharacterController>().enabled = true;
                Debug.Log(enemy[i].IsActive);
            }
        }
    }

 
}
