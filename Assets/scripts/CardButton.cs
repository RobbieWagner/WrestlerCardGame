using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;

public class CardButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private Animator cardAnimator;

    private int siblingIndex;

    private void Awake() 
    {
        siblingIndex = transform.GetSiblingIndex();
        Debug.Log(siblingIndex);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        cardAnimator.SetBool("hovering", true);
        transform.SetSiblingIndex(transform.parent.childCount - 1);
        Debug.Log(transform.GetSiblingIndex());
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        cardAnimator.SetBool("hovering", false);
        transform.SetSiblingIndex(siblingIndex);
        Debug.Log(transform.GetSiblingIndex());
    }
}
