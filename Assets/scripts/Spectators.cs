using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spectators : MonoBehaviour
{
    public static Spectators Instance { get; private set; }
    private void Awake() 
    { 
        if (Instance != null && Instance != this) 
        { 
            Destroy(this); 
        } 
        else 
        { 
            Instance = this; 
        } 
    }
}
