using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Teleport : MonoBehaviour
{

    GameManager gm;

    GameObject minimap;

    public bool walked = false;



    // Start is called before the first frame update
    void Start()
    {

        minimap = GameObject.Find("Minimap");
       
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        gm.Teleport(this.transform);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter(Collider other)
    {

        if (other.transform.gameObject.CompareTag("Player"))
        {
            if (walked == false)
            {
                gm.Teleport(this.transform);
                walked = true;
            }
        }


        

    }


    private void OnTriggerStay(Collider other)
    {

        if (other.transform.gameObject.CompareTag("Player"))
        {
            if (walked == true)
            {

                minimap.transform.localPosition = new Vector3(+100, 0, 0);
                minimap.transform.localScale = new Vector3(7, 10, 10);
                minimap.GetComponent<MiniMapClick>().enabled = true;

            }
        }

    }


    private void OnTriggerExit(Collider other)
    {

        if (other.transform.gameObject.CompareTag("Player"))
        {
            minimap.transform.localPosition = new Vector3(916.0002f, 416, 0);
            minimap.transform.localScale = new Vector3(4f, 4f, 4f);
            minimap.GetComponent<MiniMapClick>().enabled = false;
        }

    }


}
