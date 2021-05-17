using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartHealthSystem
{
    
    public event EventHandler onDamaged;
    int health;
    private List<Heart> heartList;

   public HeartHealthSystem(int heartAmount, int health)
    {
        this.health = health;
        heartList = new List<Heart>();

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
        if (onDamaged != null) onDamaged(this, EventArgs.Empty);
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
    }
}
