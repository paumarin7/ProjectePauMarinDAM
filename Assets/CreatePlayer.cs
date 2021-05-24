using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatePlayer : MonoBehaviour
{

    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(createPlayer());
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public IEnumerator createPlayer()
    {
        yield return new WaitForSeconds(0.2f);

        Debug.Log("HUIHGUODGFHOFDGJOFHI");
        Instantiate(player , transform.position, Quaternion.identity);
        
    }
}
