using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    Button abilityButton;
    public GameObject[] players;
    // Start is called before the first frame update
    void Start()
    {
        players = GameObject.FindGameObjectsWithTag("Player");
       abilityButton = GameObject.Find("abilityButton").GetComponent<Button>();
    }

    // Update is called once per frame
    void Update()
    {
        abilityButton.onClick.AddListener(players[0].GetComponentInChildren<IAbility>().Ability);
    }
}
