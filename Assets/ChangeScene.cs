﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ChangeScene : MonoBehaviour
{

    public int scene;
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
        UnityEngine.SceneManagement.SceneManager.LoadScene(scene);
    }
}
