using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class CreateDungeon : MonoBehaviour
{

    public GameObject player;


    public GameObject LevelInitializer;


    public bool isFirstCircle = false;

    public GameObject prizeRoom;
    public GameObject BossRoom;


    public List<GameObject> corridors = null;
    public List<GameObject> floors = null;
    public List<GameObject> salaFirstCycle = null;


    public List<GameObject> salaThirdCycle = null;


    private List<GameObject> secondCycle = new List<GameObject>();
    private List<GameObject> thirdCycle = new List<GameObject>();
     
    public float angle;


    public bool firstFloorDeleted = false;
    public bool isSecondCycle = false;
    public bool isThirdCycle = false;
    public bool prepareSecondCycle = false;
    public bool comprovFirstCicle = false;
    public bool comprovThirdCycle = false;
    public bool prepareThirdCycle = false;
    public bool finishThirdCycle = false;


    public bool priceRoomPicked = false;
    public bool bossRoomPicked = false;


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

        if (!finishThirdCycle)
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
             //   var randomAngle = Random.Range(20, 60);
                for (int i = 0; i < secondCycle.Count; i++)
                {
                   
                    secondCycle[i].GetComponent<CreateFloors>().angle = 0;
                    secondCycle[i].GetComponent<CreateFloors>().floorGameObject = salaThirdCycle[Random.Range(0,salaThirdCycle.Count)];
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
           //     var randomAngle = Random.Range(20, 60);
                for (int i = 0; i < thirdCycle.Count; i++)
                {
                    
                    thirdCycle[i].GetComponent<CreateCorridors>().angle = 0;
                    thirdCycle[i].GetComponent<CreateCorridors>().enabled = true;
                }
                isThirdCycle = true;
                finishThirdCycle = true;
            }
            else
            {
                
            }
        }
        else
        {
            Debug.Log("Porfin");
            floors[floors.Count - 1].GetComponentInChildren<CreateCorridors>().enabled = false;
            corridors[corridors.Count - 1].GetComponentInChildren<CreateFloors>().enabled = false;
            if (!comprovThirdCycle)
            {
                Debug.Log("ComprovThird");
                for (int i = numberOfFloors; i < floors.Count; i++)
                {
                    Destroy(floors[i].gameObject);
                    floors.RemoveAt(i);
                }

                for (int j = numberOfFloors - 4; j < corridors.Count; j++)
                {
                    Destroy(corridors[j].gameObject);
                    corridors.RemoveAt(j);
                }

                comprovThirdCycle = true;
            }else if (!priceRoomPicked)
            {
                Debug.Log("price");
                var roomPrizeNumber = Random.Range(1, floors.Count-2);
                prizeRoom.transform.position = floors[roomPrizeNumber].transform.position;
                prizeRoom.transform.rotation = floors[roomPrizeNumber].transform.rotation;
                prizeRoom.transform.position = new Vector3(prizeRoom.transform.position.x, prizeRoom.transform.position.y + 0.01f, prizeRoom.transform.position.z);
                Destroy(floors[roomPrizeNumber].gameObject);
                Instantiate(prizeRoom);
                priceRoomPicked = true;
            }else if (!bossRoomPicked)
            {
                Debug.Log("boss");

                var roomPrizeNumber = Random.Range(corridors.Count-3, corridors.Count-1);
                BossRoom.transform.position = corridors[roomPrizeNumber].transform.position;
                BossRoom.transform.rotation = corridors[roomPrizeNumber].transform.rotation;
                BossRoom.transform.position = new Vector3(BossRoom.transform.position.x, BossRoom.transform.position.y +0.02f, BossRoom.transform.position.z);
                Destroy(corridors[roomPrizeNumber].gameObject);
                Instantiate(BossRoom);
                bossRoomPicked = true;
                for (int i = 0; i < floors.Count; i++)
                {
                  var boxes =   floors[i].gameObject.GetComponentsInChildren<Rigidbody>();
                    for (int l = 0; l < boxes.Length; l++)
                    {
                        if(boxes[l].transform.gameObject.CompareTag("Enemy") || boxes[l].transform.gameObject.CompareTag("Minimap"))
                        {

                        }
                        else
                        {
                            Destroy(boxes[l]);// boxes[l].enabled = false;
                        }
                    }
                }
                for (int j = 0; j < corridors.Count; j++)
                {
                    var boxes = corridors[j].gameObject.GetComponentsInChildren<BoxCollider>();
                    for (int l = 0; l < boxes.Length; l++)
                    {

                        if ( boxes[l].transform.gameObject.CompareTag("Minimap"))
                        {

                        }
                        else
                        {
                            boxes[l].enabled = false;
                        }
                        
                        
                    }
                }


                Instantiate(player);
                Destroy(this);
            }
           

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

        corridors[corridors.Count-1].GetComponentInChildren<CreateFloors>().floorGameObject = salaFirstCycle[Random.Range(0,salaFirstCycle.Count)];
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
