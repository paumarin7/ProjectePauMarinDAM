using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ActivateText : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        GetComponentInChildren<TextMeshProUGUI>().enabled = true;
        GetComponentInChildren<RevealTmpText>().enabled = true;
    }
}
