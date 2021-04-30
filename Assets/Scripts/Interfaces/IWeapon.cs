using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IWeapon
{
    void Attack();
    void SetDirectionShoot(Vector3 directionShoot);

    void Bullet(Vector3 bulletPosition);
    void SetHitted(string v);
}
