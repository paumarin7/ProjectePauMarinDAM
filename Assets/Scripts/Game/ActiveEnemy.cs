using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ActiveEnemy : MonoBehaviour
{
    
    public List<Stats> enemy = new List<Stats>();
    public GameObject[] chains;
    BoxCollider boxCollider;
    // Start is called before the first frame update
    void Start()
    {



        StartCoroutine(waitForEnemy());
        boxCollider = GetComponent<BoxCollider>();
        boxCollider.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
   
        if (enemy.Count == 0)
        {
            for (int i = 0; i < chains.Length; i++)
            {
                if (chains[i].transform.CompareTag("Chain"))
                {

                    chains[i].GetComponent<MeshRenderer>().enabled = false;
                    chains[i].GetComponent<BoxCollider>().enabled = false;
                }

            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.transform.gameObject.name);
        if (other.transform.gameObject.CompareTag( "Player"))
        {

            StartCoroutine(startFight());
        }
    }
        public IEnumerator waitForEnemy()
    {
        yield return new WaitForSeconds(3);
        enemy = GetComponentsInChildren<Stats>().ToList();
    }


    public IEnumerator startFight()
    {
        yield return new WaitForSeconds(1);
        for (int i = 0; i < enemy.Count; i++)
        {
            enemy[i].IsActive = true;
            enemy[i].transform.gameObject.GetComponent<CharacterController>().enabled = true;
            Debug.Log(enemy[i].IsActive);
        }


        for (int i = 0; i < chains.Length; i++)
        {
            if (chains[i].CompareTag("Chain"))
            {

                chains[i].GetComponent<MeshRenderer>().enabled = true;
                chains[i].GetComponent<BoxCollider>().enabled = true;
            }

        }
        Destroy(this.GetComponent<BoxCollider>());
    }

 
}
