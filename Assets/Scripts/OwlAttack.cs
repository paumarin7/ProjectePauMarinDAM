using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OwlAttack : MonoBehaviour
{
    List<GameObject> enemies = new List<GameObject>();
    public GameObject focus;
    CharacterController ch;
    public float speed = 10;

    

    // Start is called before the first frame update
    void Start()
    {
        ch = GetComponent<CharacterController>();
        ch.detectCollisions = false;
        StartCoroutine(searchingEnemies());


    }

    // Update is called once per frame
    void Update()
    {
        if(focus == null)
        {
            if(enemies.Count == 0)
            {
                var direction =  new Vector3(GameManager.player.transform.position.x - transform.position.x,0, GameManager.player.transform.position.z - transform.position.z);
               
                transform.LookAt(new Vector3(GameManager.player.transform.position.x, transform.position.y , GameManager.player.transform.position.z));
                //  ch.Move(direction * Time.deltaTime * speed);
                transform.Translate(direction * Time.deltaTime * speed);
            }
            else
            {
                focus = enemies[Random.Range(0, enemies.Count)];
            }
           
        }
        else
        {
            transform.LookAt(focus.transform);
                var direction = focus.transform.position - this.gameObject.transform.position;
            Debug.Log(direction.magnitude);
            transform.Translate(direction * Time.deltaTime * speed);
            //  ch.Move(new Vector3(direction.x,direction.y -10,direction.z) * Time.deltaTime * speed);
            if (direction.magnitude < 1f)
            {
                Collider[] hitColliders = Physics.OverlapSphere(transform.position, 7);
                foreach (var hitCollider in hitColliders)
                {
                    Debug.Log(hitCollider.transform.gameObject.name);
                    if (hitCollider.transform.gameObject.GetComponent<IDamageable>() == null)
                    {

                    }
                    else
                    {
                        
                        hitCollider.transform.gameObject.GetComponent<IDamageable>().TakeHealth(5);
                        GameObject n = Resources.Load<GameObject>("Sounds/Audio");
                        n.GetComponent<AudioSource>().clip = Resources.Load<AudioClip>("Sounds/chickenExplode");
                        Instantiate(n, GameManager.player.transform.position, Quaternion.identity);

                    }
              
                }
                Instantiate(Resources.Load<GameObject>("Particles/ArtilleryExplosion"), this.transform.position, Quaternion.identity);
                Destroy(this.gameObject);

            }
        }
    }

    public void searchEnemy()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, 20);
        foreach (var hitCollider in hitColliders)
        {

            if (hitCollider.transform.gameObject.CompareTag("Enemy"))
            {
                enemies.Add(hitCollider.transform.gameObject);
            }
        }
    }

    public IEnumerator searchingEnemies()
    {
        searchEnemy();
        yield return new WaitForSeconds(1);
        StartCoroutine(re());
    }

    public IEnumerator re()
    {

        yield return new WaitForSeconds(1);
        StartCoroutine(searchingEnemies());
    }
}
