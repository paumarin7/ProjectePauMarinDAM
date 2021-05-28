using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChamanBossShoot : MonoBehaviour, IWeapon
{


    private GameObject bullet;
    [SerializeField]
    private Vector3 directionShoot;
    private string hitted;
    public string bulletName;


    public GameObject positionShoot;

    List<GameObject> positions = new List<GameObject>();

    public void Destroy()
    {
        Destroy(this);
    }

    public void Attack()
    {
        Bullet(positions[0].transform.position);
        Bullet(positions[1].transform.position);
        Bullet(positions[2].transform.position);
    }

    public void Bullet(Vector3 bulletPosition)
    {
        GameObject bala = Instantiate(bullet);

        bala.transform.rotation = this.transform.rotation;
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
        positions.Add(Instantiate(positionShoot, transform, false));
        positions.Add(Instantiate(positionShoot, transform, false));
        positions.Add(Instantiate(positionShoot, transform, false));


        // positions[0].transform.position = new Vector3(positions[0].transform.position.x + 1, positions[0].transform.position.y, positions[0].transform.position.z);
        positions[0].transform.localPosition = new Vector3(-1, 0, 0);
        positions[1].transform.localPosition = new Vector3(+1, 0, 0);
        positions[2].transform.localPosition = new Vector3(0, 1, 0);


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
