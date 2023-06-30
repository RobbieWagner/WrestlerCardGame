using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterUI : MonoBehaviour
{
    [SerializeField] private Slider healthBar;
    [SerializeField] private Slider staminaBar;
    [SerializeField] private Slider fameBar;

    private Character associatedCharacter;

    public void SetCharacter(Character character)
    {
        associatedCharacter = character;

        healthBar.maxValue = associatedCharacter.maxHealth;
        healthBar.value = associatedCharacter.CurrentHealth;
        staminaBar.maxValue = associatedCharacter.maxStamina;
        staminaBar.value = associatedCharacter.CurrentStamina;
        fameBar.maxValue = Game.Instance.fameNeededForWin;

        associatedCharacter.OnHealthChange += EditHealthBar;
        associatedCharacter.OnStaminaChange += EditStaminaBar;
        associatedCharacter.OnFameChange += EditFameBar;
    }

    private void EditHealthBar(){healthBar.value = associatedCharacter.CurrentHealth;}

    private void EditStaminaBar(){staminaBar.value = associatedCharacter.CurrentStamina;}

    private void EditFameBar(){
        Debug.Log("fame bar");fameBar.value = associatedCharacter.Fame;}
}
