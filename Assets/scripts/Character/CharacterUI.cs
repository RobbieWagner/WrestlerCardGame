using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterUI : MonoBehaviour
{
    [SerializeField] private Slider healthBar;
    [SerializeField] private Slider staminaBar;

    private Character associatedCharacter;

    public void SetCharacter(Character character)
    {
        associatedCharacter = character;

        healthBar.maxValue = associatedCharacter.maxHealth;
        healthBar.value = associatedCharacter.CurrentHealth;
        staminaBar.maxValue = associatedCharacter.maxStamina;
        staminaBar.value = associatedCharacter.CurrentStamina;

        associatedCharacter.OnHealthChange += EditHealthBar;
        associatedCharacter.OnStaminaChange += EditStaminaBar;
    }

    private void EditHealthBar(){healthBar.value = associatedCharacter.CurrentHealth;}

    private void EditStaminaBar(){staminaBar.value = associatedCharacter.CurrentStamina;}
}
