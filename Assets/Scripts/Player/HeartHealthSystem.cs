using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartHealthSystem: MonoBehaviour
{

    public static int maxFragmentAmount;

    public event EventHandler onDamaged;
    public event EventHandler onHealed;
    int health;
    private List<Heart> heartList;

   public HeartHealthSystem(int heartAmount, int health)
    {
        this.health = health;
        heartList = new List<Heart>();
        maxFragmentAmount = heartAmount;

        for (int i = 0; i < heartAmount; i++)
        {
            if (health >= 4)
            {
                Heart heart = new Heart(4);
                heartList.Add(heart);
            }
            else
            {
                Heart heart = new Heart(health);
                heartList.Add(heart);
            }
            health -= 4;
         
           
        }


        
    }


    public void AddHeart(int health)
    {
        this.health += health;
        int hearts = (int)Mathf.Ceil(health / 4f);
        if (hearts == 0) hearts++;
        Debug.Log(hearts);

        for (int i = 0; i < hearts; i++)
        {
            if (health >= 4)
            {
                Heart heart = new Heart(4);
                heartList.Add(heart);
            }
            else
            {
                Heart heart = new Heart(health);
                heartList.Add(heart);
            }
            health -= 4;


        }
    }

    public void Damage(int damageAmount)
    {
        //Cycle through all hearts starting from the end
        for (int i = heartList.Count -1; i >= 0; i--)
        {
            Heart heart = heartList[i];
            //test if this heart can absorb damageAmount
            if (damageAmount > heart.GetFragmentAmount())
            {
                //Heart cannot absorb full damage, damage heart and keep going to next heart
                damageAmount -= heart.GetFragmentAmount();
                heart.Damage(heart.GetFragmentAmount());
            }
            else
            {
                //heart can absorb full damage amount, absorb and break out of the cycle
                heart.Damage(damageAmount);
                break;
            }
        }
        if(!GameManager.player.GetComponent<Stats>().IsAlive)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        }
   

        if (onDamaged != null) onDamaged(this, EventArgs.Empty);
    }


    public void Heal(int healAmount)
    {
        for (int i = 0; i < heartList.Count; i++)
        {
            Heart heart = heartList[i];
            int missingFragments = maxFragmentAmount - heart.GetFragmentAmount();
            if(healAmount > missingFragments)
            {
                healAmount -= missingFragments;
                heart.Heal(missingFragments);

            }
            else
            {
                heart.Heal(healAmount);
                break;
            }
        }
        if (onHealed != null) onHealed(this, EventArgs.Empty);
    }


    public List<Heart> GetHeartList()
    {
        return heartList;
    }


    public class Heart
    {
        private int fragments;

        public Heart(int fragments)
        {
            this.fragments = fragments;
        }

        public int GetFragmentAmount()
        {
            return fragments;
        }

        public void SetFragments(int fragments)
        {
            this.fragments = fragments;
        }

        public void Damage(int damageAmount)
        {
            if(damageAmount >= fragments)
            {
                fragments = 0;
            }
            else
            {
                fragments -= damageAmount;
            }
        }


        public void Heal(int healAmount)
        {
            if(fragments + healAmount > maxFragmentAmount)
            {
                fragments = maxFragmentAmount;
            }
            else
            {
                fragments += healAmount;
            }
        }
    }
}
