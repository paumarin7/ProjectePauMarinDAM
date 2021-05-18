using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddTripleShoot : MonoBehaviour , IItem
{

  //  public IWeapon weapon;
   

    public void Item(GameObject player)
    {
      var v =  player.GetComponentsInChildren<Transform>();

        for (int i = 0; i < v.Length; i++)
        {
            if (v[i].gameObject.name.Equals("Weapon"))
            {
                v[i].gameObject.GetComponent<IWeapon>().Destroy();
                //     v[i].AddComponent((System.Type)(weapon as IWeapon));
                v[i].gameObject.AddComponent<TripleShoot>();
            }
        }
      
    
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.gameObject.CompareTag("Player"))
        {
            Item(other.gameObject);
        }

    }
}
