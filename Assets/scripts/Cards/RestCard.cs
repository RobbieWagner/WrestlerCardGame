using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestCard : Card
{
    public override void PlayCard(Character user, Character target)
    {
        user.CurrentStamina += user.maxStamina/2;
    }
}
