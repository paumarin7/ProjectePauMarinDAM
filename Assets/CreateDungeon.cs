using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CreateDungeon : MonoBehaviour
{

    public GameObject LevelInitializer;


    public bool isFirstCircle = false;


    public List<GameObject> corridors = null;
    public List<GameObject> floors = null;
    public List<GameObject> ExitFloors = null;


    public List<GameObject> secondCycle = new List<GameObject>();
    public List<GameObject> thirdCycle = new List<GameObject>();
     
    public float angle;


    public bool firstFloorDeleted = false;
    public bool isSecondCycle = false;
    public bool isThirdCycle = false;
    public bool prepareSecondCycle = false;
    public bool comprovFirstCicle = false;
    public bool prepareThirdCycle = false;


    public int corridorSelected;
    public int numberOfFloors;


    // Start is called before the first frame update
    void Start()
    {
        Instantiate(LevelInitializer);
      
     //   corridors = GameObject.FindGameObjectsWithTag("Corridor").ToList();

    }

    // Update is called once per frame
    void Update()
    {
        corridors = GameObject.FindGameObjectsWithTag("Corridor").ToList();
        floors = GameObject.FindGameObjectsWithTag("Floor").ToList();

        if (floors.Count <= numberOfFloors)
        {
            if (!isFirstCircle)
            {
                firstCircle();
            }
            else if (!comprovFirstCicle)
            {

                Debug.Log("comprov");
                for (int i = 4; i <= floors.Count; i++)
                {

                    Destroy(floors[i].gameObject);
                    floors.RemoveAt(i);
                }

                comprovFirstCicle = true;




            }
            else if (!prepareSecondCycle)
            {


                secondCycle = GameObject.FindGameObjectsWithTag("SecondCycle").ToList();
                Debug.Log("preparesecond");

                prepareSecondCycle = true;
            }
            else if (!isSecondCycle)
            {
                Debug.Log("secondcycle");
                for (int i = 0; i < secondCycle.Count; i++)
                {
                    secondCycle[i].GetComponent<CreateFloors>().angle = -20;
                    secondCycle[i].GetComponent<CreateFloors>().floorGameObject = ExitFloors[1];
                    secondCycle[i].GetComponent<CreateFloors>().enabled = true;
                }
                isSecondCycle = true;
            }
            else if(!prepareThirdCycle)
            {
                thirdCycle = GameObject.FindGameObjectsWithTag("ThirdCycle").ToList();
                Debug.Log("thirdCycle");


                if(thirdCycle.Count != 0)
                {
                    prepareThirdCycle = true;
                }
           
            }else if (!isThirdCycle)
            {
                Debug.Log("isthirdcycle");
                for (int i = 0; i < thirdCycle.Count; i++)
                {
                    thirdCycle[i].GetComponent<CreateCorridors>().angle = 0;
                    thirdCycle[i].GetComponent<CreateCorridors>().enabled = true;
                }
                isThirdCycle = true;
            }
            else
            {
                
            }
        }
        else
        {
            Debug.Log("Porfin");
            floors[floors.Count-1].GetComponentInChildren<CreateCorridors>().enabled = false;
        }
       
        



    }


    public void firstCircle()
    {
        if (floors.Count == 4)
        {
            floors[3].gameObject.GetComponentInChildren<CreateCorridors>().enabled = true;
        }
        if (floors.Count >= 5)
        {
            isFirstCircle = true;
        }

        corridors[corridors.Count-1].GetComponentInChildren<CreateFloors>().floorGameObject = ExitFloors[0];
        corridors[corridors.Count-1].GetComponentInChildren<CreateFloors>().angle = angle;
        corridors[corridors.Count-1].GetComponentInChildren<CreateFloors>().enabled = true;
        if (!firstFloorDeleted)
        {
            //Destroy(floors[0].gameObject);
           floors[0].gameObject.transform.position = new Vector3(27, 0,2.9f);
            floors[0].gameObject.transform.Rotate(0, -53, 0);
            firstFloorDeleted = true;
        }
        
    }
}
