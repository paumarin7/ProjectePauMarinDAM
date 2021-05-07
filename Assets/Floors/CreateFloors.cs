using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateFloors : MonoBehaviour
{
    public bool floor = false;
    BoxCollider boxCollider;
    public GameObject floorGameObject;
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
        if (!floor)
        {
            GameObject newGameObject = Instantiate(floorGameObject, this.transform.position, Quaternion.identity);
            newGameObject.transform.Rotate(0, this.transform.rotation.y + 90, 0);
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        floor = true;
        Destroy(this.gameObject);
    }

    private void OnTriggerExit(Collider other)
    {

    }
}
