using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySound : MonoBehaviour
{

    AudioSource audiosource;
    // Start is called before the first frame update
    void Awake()
    {

        audiosource = GetComponent<AudioSource>();
        StartCoroutine(DestroyMe());
    }

    // Update is called once per frame
    void Update()
    {
        
    }





    public IEnumerator DestroyMe()
    {

        audiosource.Play();
        yield return new WaitForSeconds(1f);

        Destroy(this.gameObject);


    }
}
