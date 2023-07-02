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
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        cardAnimator.SetBool("hovering", true);
        transform.SetSiblingIndex(transform.parent.childCount - 1);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        cardAnimator.SetBool("hovering", false);
        transform.SetSiblingIndex(siblingIndex);
    }
}
