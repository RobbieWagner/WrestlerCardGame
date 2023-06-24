 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[CreateAssetMenu(menuName = "Card")]
public class Card : MonoBehaviour
{
    [SerializeField] private int power;
    [SerializeField] private int entertainment;
    [SerializeField] private int accuracy = 100;
    [SerializeField] private int cost;

    public virtual void PlayCard(Character user, Character target)
    {
        if(user.CurrentStamina >= cost){user.CurrentStamina -= cost;}
        else
        {
            int staminaRemoved = user.CurrentStamina;
            int healthRemoved = (cost - staminaRemoved)/2;
            if(user.CurrentHealth - healthRemoved > 0)
            {
                user.CurrentStamina = 0;
                user.CurrentHealth -= healthRemoved;
            }
            else
            {
                return;
            }
        }
        AttackUnit(user, target);
    }

    private void AttackUnit(Character user, Character target)
    {
        if(UnityEngine.Random.Range(0, 100) < accuracy)
        {
            target.CurrentHealth -= power;

            int addedUserFame = (int) UnityEngine.Random.Range(0, entertainment);
            int removedTargetFame = entertainment - addedUserFame;
            user.Fame += addedUserFame;
            target.Fame -= removedTargetFame;
        }
    }
}
