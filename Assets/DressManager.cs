using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DressManager : MonoBehaviour
{
    public Transform clothingLayer; 

    public void EquipItem(GameObject clothingItem)
    {
        //Clear old clothes
        foreach (Transform child in clothingLayer)
        {
            Destroy(child.gameObject);
        }

        //Add new clothes to the doll 
        GameObject newClothing = Instantiate(clothingItem, clothingLayer);
        RectTransform rt = newClothing.GetComponent<RectTransform>();

        //Reset position and scale 
        rt.anchoredPosition = Vector2.zero;
        rt.localScale = Vector3.one;
    }
}
