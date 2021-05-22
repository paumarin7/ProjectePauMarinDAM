using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserShoot : Bullet
{


    public Vector3 mov;
    public bool movingAlong = true;
    LineRenderer lr;
    MeshCollider meshC;
    Mesh mesh;

    public override void Start()
    {
        base.Start();
        if (gameObject.CompareTag("Bullet"))
        {
            gameObject.AddComponent<LineRenderer>();
            meshC = this.gameObject.AddComponent<MeshCollider>();
            meshC.convex = true;
            meshC.isTrigger = true;
            lr = GetComponent<LineRenderer>();
            lr.startColor = (Color.red);
            lr.endColor = (Color.black);
            lr.useWorldSpace = false;
            var g = gameObject.GetComponent<Rigidbody>();
        }


    }

 
    public override void Update()
    {
        
        if (this.gameObject.CompareTag("Bullet"))
        {
            
            lr.SetPosition(0, Vector3.zero);
            lr.SetPosition(1, enemyTransform * range * 7);
            if(mesh == null)
            {
                mesh = new Mesh();
                lr.BakeMesh(mesh, true);
                meshC.sharedMesh = mesh;
            }
           
        }
    }
    public override IEnumerator rangeDistance()
    {
        yield return new WaitForSeconds(0.2f);

        Destroy(this.gameObject);
    }


    private void OnTriggerEnter(Collider other)
    {
        IDamageable trigger = other.GetComponent<IDamageable>();


        if (other.tag == hitted || other.tag == "Bullet" || other.tag == "Untagged" || other.tag == "SecondCycle" || other.tag == "ThirdCycle" || other.tag == "Minimap")
        {

        }
        else
        {
            //Collider[] hitColliders = Physics.OverlapSphere(transform.position, 7);
            //foreach (var hitCollider in hitColliders)
            //{
            //    Debug.Log(hitCollider.transform.gameObject.name);
            //    if (hitCollider.transform.gameObject.GetComponent<IDamageable>() == null)
            //    {

            //    }
            //    else
            //    {
            if(other.transform.gameObject.GetComponent<IDamageable>() != null)
            {
                other.transform.gameObject.GetComponent<IDamageable>().TakeHealth(damage);
            }

            //    }

            StartCoroutine(rangeDistance());
            //}
        }

    }
}
