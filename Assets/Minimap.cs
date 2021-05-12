using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minimap : MonoBehaviour
{

    public Material visited;
    public Material NoVisited;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {


        
        if (other.transform.gameObject.CompareTag("Player"))
        {

            Collider[] hitColliders = Physics.OverlapSphere(transform.position, 30, 1 << 10);
            foreach (var hitCollider in hitColliders)
            {
                Debug.Log(hitCollider.transform.gameObject.name);
                hitCollider.transform.gameObject.GetComponent<MeshRenderer>().material = NoVisited;
                hitCollider.transform.gameObject.layer = 9;


            }

            GetComponent<MeshRenderer>().material = visited;
            gameObject.layer = 8;
        }
    }
}
