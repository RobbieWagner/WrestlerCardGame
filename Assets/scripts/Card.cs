using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

//[CreateAssetMenu(menuName = "Card")]
public class Card : MonoBehaviour
{

    public string cardTitle;

    public int power;
    public int entertainment;
    public int accuracy = 100;
    public int cost;

    public TextMeshProUGUI titleText;

    public TextMeshProUGUI powerText;
    public TextMeshProUGUI accuracyText;
    public TextMeshProUGUI entertainmentText;
    public TextMeshProUGUI staminaCostText;

    public virtual void PlayCard()
    {
        Character user = Game.Instance.activeCharacter;
        Character target = Game.Instance.targetCharacter;

        PlayCard(user, target);

        Game.Instance.SwapTurns();
    }

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
