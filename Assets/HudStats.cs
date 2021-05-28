using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HudStats : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private TextMeshProUGUI m_TextComponent;
    public string statToShow;
    public string stringToShow;
    public float stat;

    Stats stats;
    void Start()
    {
        m_TextComponent = GetComponent<TextMeshProUGUI>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.player != null && stats == null)
        {
            stat = GameManager.player.GetComponent<Stats>().GetStatByString(statToShow);
            
        }

        m_TextComponent.text = stringToShow + ":" + stat;
    }
}
