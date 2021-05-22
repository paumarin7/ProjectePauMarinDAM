using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeWeapon : MonoBehaviour, IWeapon
{
    public string meleWeapon;
     public GameObject positionShoot;

    GameObject weapon;

    

    private string hitted;
    Vector3 directionShoot;

    List<GameObject> positions = new List<GameObject>();


    PlayerAttack playerAttack;

    public void Attack()
    {
        
    }

    public void Bullet(Vector3 bulletPosition)
    {
       
    }

    public void Destroy()
    {
        
    }

    public void SetDirectionShoot(Vector3 directionShoot)
    {
        this.directionShoot = directionShoot;
    }

    public void SetHitted(string v)
    {
        hitted = v;
    }

    // Start is called before the first frame update
    void Start()
    {
       
        playerAttack = GetComponent<PlayerAttack>();
        playerAttack.isMeleeWeapon = true;
        weapon =  Resources.Load<GameObject>(meleWeapon);
        positionShoot = Resources.Load<GameObject>("CenterShoot");
        weapon.AddComponent<MeleeDamage>();
        weapon.GetComponent<MeleeDamage>().SetHitted(hitted);
        weapon.GetComponent<MeleeDamage>().SetDamage(GetComponentInParent<Stats>().Strength);
        positions.Add(Instantiate(positionShoot, transform));
        positions[0].transform.localPosition = new Vector3(-1, -1.54f, -0.3f);
        Instantiate(weapon, positions[0].transform);
    }




    // Update is called once per frame
    void Update()
    {


        //  positions[0].transform.Rotate(directionShoot.z, directionShoot.x, directionShoot.x, Space.Self);
        //  positions[0].transform.RotateAround(directionShoot, transform.up, Time.deltaTime * 90f);
      positions[0].transform.Rotate(new Vector3(0, directionShoot.x * 20, 0));
      //  positions[0].transform.Rotate
        
        
    }

    public void OnDestroy()
    {
        playerAttack.isMeleeWeapon = false;
    }




}

