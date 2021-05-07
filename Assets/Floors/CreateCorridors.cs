using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateCorridors : MonoBehaviour
{

    public bool corridor = false;
    BoxCollider boxCollider;
    public GameObject corridorGameObject;
    public GameObject parent;
    // Start is called before the first frame update
    void Start()
    {
        parent = GetComponentInParent<GameObject>();
        boxCollider = GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!corridor)
        {
          GameObject newGameObject =  Instantiate(corridorGameObject, this.transform.position, Quaternion.identity);
            newGameObject.transform.Rotate(0, this.transform.rotation.y + 90, 0);
        }
    }


    private void OnTriggerEnter(Collider other)
    {
      
        corridor = true;
        Destroy(this.gameObject);
    }

    private void OnTriggerExit(Collider other)
    {
        
    }
}
