using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{

    [SerializeField] private int maxHealth;
    private int currentHealth;
    public int CurrentHealth
    {
        get {return currentHealth;}
        set {currentHealth = value;
             if(currentHealth > maxHealth) currentHealth = maxHealth;
             if(currentHealth < 0) currentHealth = 0;}
    }

    [SerializeField] private int maxStamina;
    private int currentStamina;
    public int CurrentStamina 
    {
        get {return currentStamina;}
        set {currentStamina = value;
             if(currentStamina > maxStamina) currentStamina = maxStamina;
             if(currentStamina < 0) currentStamina = 0;}
    }

    [SerializeField] private float fame;
    public float Fame
    {
        get {return fame;}
        set {fame = value;}
    }

    // Start is called before the first frame update
    private void Start()
    {
        fame = 0;
        ResetStats();
    }

    public void ResetStats()
    {
        currentHealth = maxHealth;
        currentStamina = maxStamina;
    }
}
