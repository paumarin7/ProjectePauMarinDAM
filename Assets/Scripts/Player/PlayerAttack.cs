using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private GameObject nearestEnemy;
    private float fireRate = 0;
    private float fireRefreshRate = 1f;
    private PlayerManager playerManager;
    [SerializeField]
    private bool canShoot = true;

    float horizontalMove = 0f;
    float verticalMove = 0f;
    Joystick shootButton;

     public List<AudioClip> shoots = new List<AudioClip>();


    AudioSource audioSource;

    public bool isMeleeWeapon = false;


    private Vector3 rotation;
    private Vector3 lastRotation;

    public GameObject NearestEnemy { get => nearestEnemy; set => nearestEnemy = value; }


    // Start is called before the first frame update
    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        playerManager = GetComponentInParent<PlayerManager>();
        shootButton = GameObject.Find("ShooterJoystick").GetComponent<Joystick>();

        //      nearestEnemy = GameObject.Find("Focus");
    }

    // Update is called once per frame
    void Update()
    {

        //Debug.Log(transform.position +"Position");
        //Debug.Log(transform.localPosition +"localPosition");
        //  NearestEnemy = GameObject.FindGameObjectsWithTag("Enemy").OrderBy(t => Vector3.Distance(transform.position, t.transform.position)).FirstOrDefault();
        //if (NearestEnemy == null)
        //{
        //    playerManager.playerAnimations.FocusedOnEnemy = false;
        //    GetComponent<IWeapon>().SetNearestEnemy(null);
        //}
        //else
        //{
        //   playerManager.playerAnimations.FocusedOnEnemy = true;                   Aqui esta

        
        horizontalMove = shootButton.Horizontal;
        verticalMove = shootButton.Vertical;  
        
        if(horizontalMove != 0 && verticalMove != 0 && !isMeleeWeapon)
        {

            rotation = new Vector3(0, Mathf.Atan2(horizontalMove, verticalMove) * 180 / Mathf.PI, 0);
            playerManager.playerAnimations.Shooting = true;
            playerManager.playerAnimations.AttackRotation=rotation ;
            Attacking();
        }
        else
        {
            playerManager.playerAnimations.Shooting = false;
            GetComponent<IWeapon>().SetDirectionShoot(new Vector3(horizontalMove, 0, verticalMove).normalized);
        }
        //    GetComponent<IWeapon>().SetNearestEnemy(nearestEnemy);


        //    }
    }
    public IEnumerator Attack()
    {
        ////  fireRate = Time.time + fireRefreshRate;
        //if (NearestEnemy == null)
        //{

        //    GetComponent<IWeapon>().Attack();

        //}
        //else
        //{

        SoundEffect();

        GetComponent<IWeapon>().SetDirectionShoot(new Vector3(horizontalMove, 0, verticalMove).normalized);


        IWeapon weapon = GetComponent<IWeapon>();
        weapon.SetHitted("Player");
        
        weapon.Attack();
            

       // }
        canShoot = false;

        yield return new WaitForSeconds(fireRate);
        canShoot = true;
    }

    public void SetFireRate(float fireRate)
    {
        this.fireRate = fireRate;
    }


    public void SoundEffect()
    {
        audioSource.clip = shoots[Random.Range(0, shoots.Count)];
        audioSource.Play();
   
    }


    public void Attacking()
    {
        if (canShoot)
        {
            StartCoroutine(Attack());
        }

    }
}
