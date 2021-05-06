using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicShoot : MonoBehaviour, IWeapon
{


    private GameObject bullet;
    [SerializeField]
    private Vector3 directionShoot;
    private string hitted;


    public void Attack()
    {
        Bullet(new Vector3(transform.position.x, transform.position.y, transform.position.z));
    }

    public void Bullet(Vector3 bulletPosition)
    {
        GameObject bala = Instantiate(bullet);

        bala.AddComponent(GetComponent<IShootable>().GetType());
        bala.AddComponent<WeaponDirectionManager>();
        bala.GetComponent<WeaponDirectionManager>().SetDamage(GetComponentInParent<Stats>().Strength);
        bala.GetComponent<WeaponDirectionManager>().SetAttackSpeed(GetComponentInParent<Stats>().AttackSpeed);
        bala.GetComponent<WeaponDirectionManager>().SetHitted(hitted);

        bala.GetComponent<IShootable>().SetAccuracy(GetComponentInParent<Stats>().Accuracy);
        bala.transform.position = bulletPosition;
        if (directionShoot == null)
        {
        }
        else
        {
            bala.GetComponent<IShootable>().SetEnemyTransform(directionShoot);
        }
    }

    public void SetHitted(string v)
    {
        this.hitted = v;
    }

    public void SetDirectionShoot(Vector3 directionShoot)
    {
        this.directionShoot = directionShoot;
    }

    // Start is called before the first frame update
    void Start()
    {
        bullet = Resources.Load<GameObject>("Diente");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
