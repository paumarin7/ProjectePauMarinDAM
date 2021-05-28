using DungeonArchitect;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RuntimeDungeonBuilder : MonoBehaviour
{
    public Dungeon dungeon;

    void Start()
    {
        if (dungeon != null)
        {
            dungeon.Config.Seed = (uint)(Random.value * int.MaxValue);
            dungeon.Build();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
