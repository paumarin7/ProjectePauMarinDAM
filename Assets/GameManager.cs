using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    Button shootButton;
    public GameObject[] players;
    // Start is called before the first frame update
    void Start()
    {
        players = GameObject.FindGameObjectsWithTag("Player");
       //shootButton = GameObject.Find("ShooterJoystick").GetComponent<Button>();
    }

    // Update is called once per frame
    void Update()
    {
      //  shootButton.onClick.AddListener(players[0].GetComponentInChildren<PlayerAttack>().Attacking);
    }
}
