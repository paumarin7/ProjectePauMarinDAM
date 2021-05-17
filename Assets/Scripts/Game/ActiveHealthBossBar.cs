using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class ActiveHealthBossBar : MonoBehaviour
{
    [SerializeField]
    Transform bossBar;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(bossBar == null)
        {
            bossBar = GameObject.Find("BossBar").GetComponent<RectTransform>();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.gameObject.CompareTag("Player"))
        {
            List<Image> image = new List<Image>();
            image = bossBar.GetComponentsInChildren<Image>().ToList();
            for (int i = 0; i < image.Count; i++)
            {
                image[i].enabled = true;
            }
        }
    }
}
