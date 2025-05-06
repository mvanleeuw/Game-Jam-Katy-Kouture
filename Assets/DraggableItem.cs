using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.EventSystems;

public class DraggableItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
    private Canvas canvas;
    private Transform homeSlot;
    private Vector3 originalPosition;

    public string itemType = "Torso";
 
    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        canvas = GetComponentInParent<Canvas>();

        originalPosition = rectTransform.anchoredPosition;

        if (homeSlot == null)
            homeSlot = transform.parent;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        originalPosition = rectTransform.anchoredPosition;
        canvasGroup.alpha = 0.6f;
        canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;

        if (!TrySnapToSnapPoint())
        {
            ReturnToOriginalPosition();
        }
    }

    private void ReturnToOriginalPosition()
    {
        rectTransform.SetParent(homeSlot, false);
        rectTransform.anchoredPosition = originalPosition;
        rectTransform.localScale = Vector3.one;
    }
    private bool TrySnapToSnapPoint()
    {
        GameObject[] snapPoints = GameObject.FindGameObjectsWithTag("SnapPoint");

        foreach (GameObject snapPointObj in snapPoints)
        {
            float distance = Vector3.Distance(transform.position, snapPointObj.transform.position);

            if (distance < 50f)
            {
                SnapPoint snapPoint = snapPointObj.GetComponent<SnapPoint>();
                if (snapPoint != null && snapPoint.slotType == this.itemType)
                {
                    RectTransform snapRect = snapPointObj.GetComponent<RectTransform>();


                    rectTransform.SetParent(snapPointObj.transform, false);
                    rectTransform.anchoredPosition = Vector2.zero;

                    ResizeToFitDoll(itemType);
                    transform.SetParent(snapPointObj.transform, false);

                    return true;
                }
            }
        }

        return false;
    }

    private void ResizeToFitDoll(string type)
    {

        switch (type)
        {
            case "Torso":
            case "Neck":
            case "Feet":
            case "Right Hand":
            case "Left Hand":
            case "Full Body":
            case "Legs":
            case "Arm":
                rectTransform.localScale = Vector3.one;
                break;
            default:
                rectTransform.localScale = Vector3.one;
                break;
        }
    }
}
    