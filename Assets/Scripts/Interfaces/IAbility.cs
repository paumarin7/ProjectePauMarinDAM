using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAbility
{
    void Ability();

    bool usingAbility { get ; set; }


    void Destroy();
  
}
