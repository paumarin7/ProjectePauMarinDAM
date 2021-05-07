using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateCorridors : MonoBehaviour
{

    public bool corridor = false;
    public float angle;
    BoxCollider boxCollider;
    public GameObject corridorGameObject;
    public GameObject parent;
    // Start is called before the first frame update
    void Start()
    {
       
        boxCollider = GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {

        if (!corridor)
        {
          GameObject newGameObject =  Instantiate(corridorGameObject, this.transform.position, Quaternion.identity);
            newGameObject.transform.Rotate(0, parent.transform.eulerAngles.y + angle, 0);
            newGameObject.GetComponentInChildren<CreateFloors>().angle = angle;
            corridor = true;
        }
    }


    private void OnTriggerEnter(Collider other)
    {
      
        
        Destroy(this.gameObject);
    }

    private void OnTriggerExit(Collider other)
    {
        
    }
}
