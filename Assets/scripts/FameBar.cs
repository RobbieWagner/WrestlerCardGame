using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FameBar : MonoBehaviour
{
    [SerializeField] private Slider fameSlider;
    public float fameNeededForWin;
    private float currentFame;

    public float Fame
    {
        get {return currentFame;}
        set{currentFame = value;
            if(currentFame > fameNeededForWin) currentFame = fameNeededForWin;
            if(currentFame < 0) currentFame = 0;
            if(OnFameChange != null) OnFameChange(currentFame);}
    }

    public delegate void OnFameChangeDelegate(float fame);
    public event OnFameChangeDelegate OnFameChange;


    public static FameBar Instance{get; private set;}

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

        OnFameChange += DisplayFameValue;

        fameSlider.maxValue = fameNeededForWin;
        fameSlider.minValue = 0;
        Fame = fameNeededForWin/2;
    }

    private void DisplayFameValue(float fame)
    {
        fameSlider.value = fame;
    }
}
