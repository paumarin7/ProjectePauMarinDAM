using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateFloors : MonoBehaviour
{
    public bool floor = false;
    BoxCollider boxCollider;

    public float angle;
    public GameObject floorGameObject;
    public GameObject parent;
    // Start is called before the first frame update
    void Start()
    {
        
        boxCollider = GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!floor)
        {
            GameObject newGameObject = Instantiate(floorGameObject, this.transform.position, Quaternion.identity);
            newGameObject.transform.Rotate(0, parent.transform.eulerAngles.y + angle, 0);
            newGameObject.GetComponentInChildren<CreateCorridors>().angle = angle;
            floor = true;
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
