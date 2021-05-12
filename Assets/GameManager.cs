using System.Collections;

using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    Button abilityButton;
    public static GameObject player;
    IAbility ability;
    public bool eventAdded = false;
    // Start is called before the first frame update
    void Start()
    {
        
       abilityButton = GameObject.Find("abilityButton").GetComponent<Button>();
   
        StartCoroutine(addEvent());
    }

    // Update is called once per frame
    void Update()
    {
        if(player == null) player = GameObject.FindGameObjectWithTag("Player");

        // UnityEventTools.AddObjectPersistentListener<GameObject>()
        //    abilityButton.onClick.AddListener(player.GetComponentInChildren<IAbility>().Ability);
        //if(player != null && !eventAdded)
        //{
        //    UnityEventTools.AddPersistentListener(abilityButton.onClick, new UnityEngine.Events.UnityAction(player.GetComponent<IAbility>().Ability));
        //    eventAdded = true;
        //}

    }

    public IEnumerator addEvent()
    {
      

        yield return new WaitForSeconds(5);

        //  UnityAction<GameObject> action = new UnityAction<GameObject>(abilityButton.OnButtonClick);

     
        //  abilityButton.onClick.AddListener(delegate() { player.GetComponentInChildren<IAbility>().Ability(); });
        //abilityButton.onClick.RemoveAllListeners();

    }

    public void ActionTriggerPlayer()
    {
        player.GetComponentInChildren<IAbility>().Ability();
    }
}
