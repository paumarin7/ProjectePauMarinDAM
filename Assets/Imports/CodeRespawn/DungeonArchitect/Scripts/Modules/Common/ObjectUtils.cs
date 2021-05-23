﻿using UnityEngine;

namespace DungeonArchitect.Utils
{
    public class ObjectUtils
    {
        public static void DestroyObject(Object go)
        {
            if (Application.isPlaying)
            {
                Object.Destroy(go);
            }
            else
            {
                Object.DestroyImmediate(go);
            }
        }
    }
}