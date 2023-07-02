using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{

    public Deck characterDeck;

    [HideInInspector] public bool canAct;

    public int maxHealth;
    private int currentHealth;
    public int CurrentHealth
    {
        get {return currentHealth;}
        set {currentHealth = value;
             if(currentHealth > maxHealth) currentHealth = maxHealth;
             if(currentHealth < 0) currentHealth = 0;
             if(OnHealthChange != null) OnHealthChange();}
    }

    public int maxStamina;
    private int currentStamina;
    public int CurrentStamina 
    {
        get {return currentStamina;}
        set {currentStamina = value;
             if(currentStamina > maxStamina) currentStamina = maxStamina;
             if(currentStamina < 0) currentStamina = 0;
             if(OnStaminaChange != null) OnStaminaChange();}
    }

    public delegate void OnHealthChangeDelegate();
    public event OnHealthChangeDelegate OnHealthChange;

    public delegate void OnStaminaChangeDelegate();
    public event OnStaminaChangeDelegate OnStaminaChange;

    // Start is called before the first frame update
    private void Start()
    {
        ResetStats();
    }

    public void ResetStats()
    {
        CurrentHealth = maxHealth;
        CurrentStamina = maxStamina;

        canAct = true;
    }
}
