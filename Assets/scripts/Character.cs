using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{

    public Deck characterDeck;

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

    [SerializeField] private float fame;
    public float Fame
    {
        get {return fame;}
        set {fame = value;
             if(OnFameChange != null) OnFameChange();
             Debug.Log("fame");}
    }

    public delegate void OnHealthChangeDelegate();
    public event OnHealthChangeDelegate OnHealthChange;

    public delegate void OnStaminaChangeDelegate();
    public event OnStaminaChangeDelegate OnStaminaChange;

    public delegate void OnFameChangeDelegate();
    public event OnFameChangeDelegate OnFameChange;

    // Start is called before the first frame update
    private void Start()
    {
        ResetStats();
    }

    public void ResetStats()
    {
        CurrentHealth = maxHealth;
        CurrentStamina = maxStamina;
        Fame = 0;
    }
}
