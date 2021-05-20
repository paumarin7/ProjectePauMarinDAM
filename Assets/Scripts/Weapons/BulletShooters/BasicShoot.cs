using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicShoot : MonoBehaviour, IWeapon
{


    public string bulletName;
    private GameObject bullet;
    [SerializeField]
    private Vector3 directionShoot;
    private string hitted;
    public GameObject positionShoot;

    List<GameObject> positions = new List<GameObject>();


    public void Destroy()
    {
        Destroy(this);
    }

    public void Attack()
    {
        Bullet(positions[0].transform.position);
        
    }

    public void Bullet(Vector3 bulletPosition)
    {
        GameObject bala = Instantiate(bullet);
        bala.AddComponent(GetComponent<IShootable>().GetType());
        bala.GetComponent<Bullet>().SetDamage(GetComponentInParent<Stats>().Strength);
        bala.GetComponent<Bullet>().SetAttackSpeed(GetComponentInParent<Stats>().AttackSpeed);
        bala.GetComponent<Bullet>().Range = GetComponentInParent<Stats>().Range;
        bala.name = bulletName;
        bala.GetComponent<Bullet>().SetHitted(hitted);

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
        
        bullet = Resources.Load<GameObject>(bulletName);

        positionShoot = Resources.Load<GameObject>("CenterShoot");
        positions.Add (Instantiate(positionShoot, transform));


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDestroy()
    {
        for (int i = 0; i < positions.Count; i++)
        {
            Destroy(positions[i].gameObject);
        }
    }
}
