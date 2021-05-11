using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    Button abilityButton;
    public static GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
       abilityButton = GameObject.Find("abilityButton").GetComponent<Button>();
    }

    // Update is called once per frame
    void Update()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        abilityButton.onClick.AddListener(player.GetComponentInChildren<IAbility>().Ability);
    }
}
