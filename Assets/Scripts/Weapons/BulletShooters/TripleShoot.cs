using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TripleShoot : MonoBehaviour, IWeapon
{
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
        Bullet(positions[1].transform.position);
        Bullet(positions[2].transform.position);
    }

    public void Bullet(Vector3 bulletPosition)
    {
        GameObject bala = Instantiate(bullet);

        bala.AddComponent(GetComponent<IShootable>().GetType());
        bala.AddComponent<WeaponDirectionManager>();
        bala.GetComponent<WeaponDirectionManager>().SetDamage(GetComponentInParent<Stats>().Strength);
        bala.GetComponent<WeaponDirectionManager>().SetAttackSpeed(GetComponentInParent<Stats>().AttackSpeed);
        bala.GetComponent<WeaponDirectionManager>().Range = GetComponentInParent<Stats>().Range;
        bala.name = "Diente";
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
        positionShoot = Resources.Load<GameObject>("CenterShoot");
        positions.Add(Instantiate(positionShoot, transform));
        positions[0].transform.position = new Vector3(positions[0].transform.position.x - 1f, positions[0].transform.position.y, positions[0].transform.position.z);
        positions.Add(Instantiate(positionShoot, transform));
        positions[1].transform.position = new Vector3(positions[1].transform.position.x + 1f, positions[1].transform.position.y, positions[1].transform.position.z);
        positions.Add(Instantiate(positionShoot, transform));
        positions[2].transform.position = new Vector3(positions[2].transform.position.x , positions[2].transform.position.y +1, positions[2].transform.position.z);
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
