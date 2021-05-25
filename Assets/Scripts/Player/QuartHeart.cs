using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuartHeart : MonoBehaviour
{

    [SerializeField]
    private Sprite heartSprite0;
    [SerializeField]
    private Sprite heartSprite1;
    [SerializeField]
    private Sprite heartSprite2;
    [SerializeField]
    private Sprite heartSprite3;
    [SerializeField]
    private Sprite heartSprite4;

    public HeartHealthSystem heartHealthSystem;

    private Stats playerStats;



    float lastMaxHealth;

    private List<HeartImage> heartImageList;

    private void Awake()
    {
        heartImageList = new List<HeartImage>();
    }

    // Start is called before the first frame update
    void Start()
    {

        StartCoroutine(addHearts());
        

    }

    public IEnumerator addHearts()
    {


        yield return new WaitForSeconds(1);

        HeartHealthSystem heartHealthSystem = new HeartHealthSystem((int)Mathf.Ceil(playerStats.MaxHealth / 4f),(int)playerStats.Health);
        SetHeartsHealthSystem(heartHealthSystem);
        lastMaxHealth = playerStats.MaxHealth;


    }

    public void SetHeartsHealthSystem(HeartHealthSystem heartHealthSystem)
    {
        if(heartImageList.Count!= 0)
        {
            for (int i = 0; i < heartImageList.Count; i++)
            {
                Destroy(heartImageList[i].GetTransform().gameObject);
                
            }
            heartImageList.Clear();
        }
        this.heartHealthSystem = heartHealthSystem;
        List<HeartHealthSystem.Heart> heartList = heartHealthSystem.GetHeartList();
        Vector2 heartAnchoredPosition = new Vector2(0, 0);
        for (int i = 0; i < heartList.Count; i++)
        {
            HeartHealthSystem.Heart heart = heartList[i];
            CreateHeartImage(heartAnchoredPosition).SetHeartFragments(heart.GetFragmentAmount());
            heartAnchoredPosition += new Vector2(170, 0);

        }
        heartHealthSystem.onDamaged += HeartHealthSystem_onDamaged;
        heartHealthSystem.onHealed += HeartHealthSystem_onHealed;

        }

    private void HeartHealthSystem_onHealed(object sender, System.EventArgs e)
    {
        //Hearts health system was healed
        RefreshAllHearts();
    }

    private void HeartHealthSystem_onDamaged(object sender, System.EventArgs e)
    {
        //Hearts health system was damaged
        Instantiate(Resources.Load<GameObject>("Particles/Blood"), new Vector3(playerStats.transform.position.x, playerStats.transform.position.y+3, playerStats.transform.position.z) , Quaternion.identity);
        RefreshAllHearts();

    }

    private void RefreshAllHearts()
    {
        List<HeartHealthSystem.Heart> heartList = heartHealthSystem.GetHeartList();
        for (int i = 0; i < heartImageList.Count; i++)
        {
            HeartImage heartImage = heartImageList[i];
            HeartHealthSystem.Heart heart = heartList[i];

            heartImage.SetHeartFragments(heart.GetFragmentAmount());
        }
    }


    // Update is called once per frame
    void Update()
    {
        if(GameManager.player!= null)
        {
            playerStats = GameManager.player.GetComponent<Stats>();
        }

        if(playerStats!= null)
        {
            if(lastMaxHealth!= 0)
            {
                if (playerStats.MaxHealth != lastMaxHealth)
                {
                    heartHealthSystem.AddHeart((int)(playerStats.MaxHealth - lastMaxHealth));
                    SetHeartsHealthSystem(heartHealthSystem);
                    lastMaxHealth = playerStats.MaxHealth;
                    
                }
            } 
        }



        RefreshAllHearts();


    }



    private HeartImage CreateHeartImage(Vector2 anchoredPosition)
    {
        GameObject heartGameObject = new GameObject("Heart", typeof(Image));
        //Child of this transform
        heartGameObject.transform.parent = transform;
        heartGameObject.transform.localPosition = Vector3.zero;
        //Locate and size heart
        heartGameObject.GetComponent<RectTransform>().anchoredPosition = anchoredPosition;
        heartGameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(500, 500);
        //Set heart sprite
        Image heartImageUI = heartGameObject.GetComponent<Image>();
        heartImageUI.sprite = heartSprite0;

        HeartImage heartImage = new HeartImage(this,heartImageUI);
        heartImageList.Add(heartImage);
        return heartImage;
    }

    //Represents a heartImage
    public class HeartImage
    {
        private QuartHeart quartHeart;
        private Image heartImage;
        
        public HeartImage(QuartHeart quartHeart,Image heartImage)
        {
            this.quartHeart = quartHeart;
            this.heartImage = heartImage;
        }

        public void SetHeartFragments(int fragments)
        {
            switch (fragments)
            {
                case 0: heartImage.sprite = quartHeart.heartSprite0;break;
                case 1: heartImage.sprite = quartHeart.heartSprite1;break;
                case 2: heartImage.sprite = quartHeart.heartSprite2;break;
                case 3: heartImage.sprite = quartHeart.heartSprite3;break;
                case 4: heartImage.sprite = quartHeart.heartSprite4;break;
            }
        }

        public Transform GetTransform()
        {
            return heartImage.transform;
        }
    }

}
