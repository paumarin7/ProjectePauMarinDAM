using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChamanBossBullet : MonoBehaviour, IShootable
{
    [SerializeField]
    private Vector3 enemyTransform;
    
    private WeaponDirectionManager weaponDirectionManager;
    private float Accuracy;
    private Sprite imageSprite;


    public void SetEnemyTransform(Vector3 enemyTransform)
    {
        this.enemyTransform = enemyTransform;
    }
    public void SetAccuracy(float Accuracy)
    {
        this.Accuracy = Accuracy;
    }
    void Start()
    {
        if (enemyTransform != null)
        {
            weaponDirectionManager = GetComponent<WeaponDirectionManager>();
           

            var x = enemyTransform.x+1;
            var z = enemyTransform.z;
            var f = enemyTransform - transform.position;



         //   x *= 2;
         //   z *= 2;


       //     rb.AddForce(enemyTransform, ForceMode.Impulse);
            //if (Vector3.Distance(enemyTransform, transform.position) < 1.5f)
            //{
            //    enemyTransform = new Vector3(Random.Range(x, x), 0, Random.Range(z, z)).normalized;

            //    Debug.Log("1.5");
            //}
            //else if (Vector3.Distance(enemyTransform, transform.position) < 3f)
            //{
            //    enemyTransform = new Vector3(Random.Range(x - (Accuracy % 4), x + (Accuracy % 4)), 0, Random.Range(z - (Accuracy % 4), z + (Accuracy % 4))).normalized;
            //    Debug.Log("3");

            //}
            //else if (Vector3.Distance(enemyTransform, transform.position) < 5f)
            //{
            //    enemyTransform = new Vector3(Random.Range(x - Accuracy, x + Accuracy), 0, Random.Range(z - Accuracy, z + Accuracy)).normalized;
            //    Debug.Log("5");
            //}
            //else if (Vector3.Distance(enemyTransform, transform.position) < 7f)
            //{
            //    enemyTransform = new Vector3(Random.Range(x - (Accuracy * 1.2f), x + (Accuracy * 1.2f)), 0, Random.Range(z - (Accuracy * 1.2f), z + (Accuracy * 1.2f))).normalized;
            //    Debug.Log("7");
            //}
        }



        // enemyTransform = new Vector3(Random.Range(enemyTransform.x - Accuracy, enemyTransform.x + Accuracy), enemyTransform.y, Random.Range(enemyTransform.z - Accuracy, enemyTransform.z + Accuracy));
        //  enemyTransform = new Vector3(enemyTransform.x - transform.position.x, 0, enemyTransform.z - transform.position.z);

        Debug.DrawRay(transform.position, enemyTransform, Color.red, 1f);


  
    }

    // Update is called once per frame
    void Update()
    {


        if (weaponDirectionManager != null)
        {
            weaponDirectionManager.SetShootDirection(enemyTransform);
        }
    }



}
